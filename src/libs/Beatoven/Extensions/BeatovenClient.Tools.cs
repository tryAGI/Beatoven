#nullable enable

using Microsoft.Extensions.AI;

namespace Beatoven;

/// <summary>
/// Extensions for using <see cref="BeatovenClient"/> as MEAI tools with any
/// <see cref="Microsoft.Extensions.AI.IChatClient"/>.
/// </summary>
public static class BeatovenToolExtensions
{
    /// <summary>
    /// Creates an <see cref="AIFunction"/> that starts an asynchronous composition
    /// task from a natural-language prompt and returns the <c>task_id</c> to poll.
    /// </summary>
    /// <param name="client">The Beatoven client.</param>
    [CLSCompliant(false)]
    public static AIFunction AsComposeTrackTool(this BeatovenClient client)
    {
        ArgumentNullException.ThrowIfNull(client);

        return AIFunctionFactory.Create(
            async (string prompt, string? format, bool? looping, CancellationToken cancellationToken) =>
            {
                ComposeTrackFormat? formatEnum = format switch
                {
                    _ when string.Equals(format, "wav", StringComparison.OrdinalIgnoreCase) => ComposeTrackFormat.Wav,
                    _ when string.Equals(format, "mp3", StringComparison.OrdinalIgnoreCase) => ComposeTrackFormat.Mp3,
                    _ when string.Equals(format, "aac", StringComparison.OrdinalIgnoreCase) => ComposeTrackFormat.Aac,
                    _ => null,
                };

                var response = await client.Tracks.ComposeTrackAsync(
                    prompt: new ComposeTrackPrompt { Text = prompt },
                    format: formatEnum,
                    looping: looping,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return $"Composition started. task_id: {response.TaskId}. " +
                    $"Poll with BeatovenGetTaskStatus until status is 'composed'.";
            },
            name: "BeatovenComposeTrack",
            description:
                "Starts an asynchronous AI music composition from a natural-language prompt describing " +
                "the desired track (e.g. '30 seconds peaceful lo-fi chill hop track'). Returns a task_id " +
                "that should be polled via BeatovenGetTaskStatus until composition completes. " +
                "Optional: format ('wav' default, 'mp3', 'aac'), looping (bool).");
    }

    /// <summary>
    /// Creates an <see cref="AIFunction"/> that returns the current status of a
    /// composition task, including download URLs when the task is complete.
    /// </summary>
    /// <param name="client">The Beatoven client.</param>
    [CLSCompliant(false)]
    public static AIFunction AsGetTaskStatusTool(this BeatovenClient client)
    {
        ArgumentNullException.ThrowIfNull(client);

        return AIFunctionFactory.Create(
            async (string taskId, CancellationToken cancellationToken) =>
            {
                var response = await client.Tasks.GetTaskStatusAsync(
                    taskId: taskId,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                return FormatTaskStatus(taskId, response);
            },
            name: "BeatovenGetTaskStatus",
            description:
                "Gets the current status of a Beatoven composition task. When status is 'composed' " +
                "the response includes signed download URLs for the full track and individual stems " +
                "(bass, chords, melody, percussion). Status values: composing, running, composed, failed.");
    }

    /// <summary>
    /// Creates an <see cref="AIFunction"/> that polls a composition task until it
    /// finishes and returns the download URL for the mixed track.
    /// </summary>
    /// <param name="client">The Beatoven client.</param>
    [CLSCompliant(false)]
    public static AIFunction AsWaitForTrackTool(this BeatovenClient client)
    {
        ArgumentNullException.ThrowIfNull(client);

        return AIFunctionFactory.Create(
            async (string taskId, int? timeoutSeconds, CancellationToken cancellationToken) =>
            {
                var timeout = TimeSpan.FromSeconds(timeoutSeconds ?? 300);
                using var timeoutCts = new CancellationTokenSource(timeout);
                using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(
                    cancellationToken, timeoutCts.Token);

                while (!linkedCts.IsCancellationRequested)
                {
                    var response = await client.Tasks.GetTaskStatusAsync(
                        taskId: taskId,
                        cancellationToken: linkedCts.Token).ConfigureAwait(false);

                    if (response.Status == TaskStatus.Composed)
                    {
                        return FormatTaskStatus(taskId, response);
                    }

                    if (response.Status == TaskStatus.Failed)
                    {
                        return $"Task {taskId} failed.";
                    }

                    try
                    {
                        await Task.Delay(TimeSpan.FromSeconds(5), linkedCts.Token).ConfigureAwait(false);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                }

                return $"Timed out waiting for task {taskId} to finish.";
            },
            name: "BeatovenWaitForTrack",
            description:
                "Polls a Beatoven composition task every 5 seconds until status is 'composed' or 'failed'. " +
                "Returns the final status and, on success, the track and stem URLs. " +
                "Optional: timeoutSeconds (default 300).");
    }

    /// <summary>
    /// Creates an <see cref="AIFunction"/> that returns a curated list of common
    /// moods/genres that can be mentioned inside a compose prompt.
    /// Beatoven does not expose a mood enumeration endpoint, so the list is static.
    /// </summary>
    /// <param name="client">The Beatoven client.</param>
    [CLSCompliant(false)]
    public static AIFunction AsListMoodsTool(this BeatovenClient client)
    {
        ArgumentNullException.ThrowIfNull(client);

        return AIFunctionFactory.Create(
            (CancellationToken cancellationToken) =>
            {
                string[] moods =
                [
                    "happy", "sad", "peaceful", "calm", "uplifting", "energetic", "epic",
                    "dramatic", "tense", "mysterious", "romantic", "nostalgic", "dark",
                    "playful", "inspiring", "melancholic", "triumphant", "relaxing",
                ];

                string[] genres =
                [
                    "cinematic", "lo-fi", "chill-hop", "hip-hop", "pop", "rock", "electronic",
                    "ambient", "jazz", "orchestral", "piano", "acoustic", "folk", "edm", "house",
                ];

                return Task.FromResult(
                    "Beatoven has no mood enumeration endpoint. Use any of these keywords in the " +
                    "compose prompt text (example: '30 seconds peaceful lo-fi chill hop track'):\n" +
                    $"Moods: {string.Join(", ", moods)}\n" +
                    $"Genres: {string.Join(", ", genres)}");
            },
            name: "BeatovenListMoods",
            description:
                "Lists moods and genre keywords commonly used inside Beatoven compose prompts. " +
                "Beatoven uses freeform prompts, so any of these terms can be included in the " +
                "text passed to BeatovenComposeTrack.");
    }

    private static string FormatTaskStatus(string taskId, TaskStatusResponse response)
    {
        var lines = new List<string>
        {
            $"Task: {taskId}",
            $"Status: {response.Status}",
        };

        if (response.Meta is { } meta)
        {
            if (!string.IsNullOrWhiteSpace(meta.TrackId))
            {
                lines.Add($"Track ID: {meta.TrackId}");
            }
            if (meta.Version.HasValue)
            {
                lines.Add($"Version: {meta.Version}");
            }
            if (!string.IsNullOrWhiteSpace(meta.TrackUrl))
            {
                lines.Add($"Track URL: {meta.TrackUrl}");
            }
            if (meta.StemsUrl is { } stems)
            {
                if (!string.IsNullOrWhiteSpace(stems.Bass))
                {
                    lines.Add($"Bass stem: {stems.Bass}");
                }
                if (!string.IsNullOrWhiteSpace(stems.Chords))
                {
                    lines.Add($"Chords stem: {stems.Chords}");
                }
                if (!string.IsNullOrWhiteSpace(stems.Melody))
                {
                    lines.Add($"Melody stem: {stems.Melody}");
                }
                if (!string.IsNullOrWhiteSpace(stems.Percussion))
                {
                    lines.Add($"Percussion stem: {stems.Percussion}");
                }
            }
        }

        return string.Join("\n", lines);
    }
}
