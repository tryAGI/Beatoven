/*
order: 20
title: Poll Task Status
slug: poll-task-status

Shows how to poll the status of a composition task until the track is composed
and the download URLs for the full track and individual stems are available.
*/

namespace Beatoven.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Example_PollTaskStatus()
    {
        //// Compose a short track and poll until it finishes, then read the track + stem URLs
        //// from the response metadata.

        using var client = GetAuthenticatedClient();

        var composeResponse = await client.Tracks.ComposeTrackAsync(
            prompt: new ComposeTrackPrompt { Text = "15 seconds calm piano melody" });

        composeResponse.TaskId.Should().NotBeNullOrWhiteSpace();

        using var timeoutCts = new CancellationTokenSource(TimeSpan.FromMinutes(5));
        TaskStatusResponse? status = null;
        while (!timeoutCts.IsCancellationRequested)
        {
            status = await client.Tasks.GetTaskStatusAsync(
                taskId: composeResponse.TaskId,
                cancellationToken: timeoutCts.Token);

            if (status.Status is Beatoven.TaskStatus.Composed or Beatoven.TaskStatus.Failed)
            {
                break;
            }

            await Task.Delay(TimeSpan.FromSeconds(5), timeoutCts.Token);
        }

        status.Should().NotBeNull();
        status!.Status.Should().Be(Beatoven.TaskStatus.Composed);
        status.Meta.Should().NotBeNull();
        status.Meta!.TrackUrl.Should().NotBeNullOrWhiteSpace();
    }
}
