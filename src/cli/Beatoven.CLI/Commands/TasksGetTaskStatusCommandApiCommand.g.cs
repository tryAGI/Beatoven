#nullable enable
#pragma warning disable CS0618

using System.CommandLine;

namespace Beatoven.CLI.Commands;

internal static partial class TasksGetTaskStatusCommandApiCommand
{
    private static Argument<string> TaskId { get; } = new(
        name: @"task-id")
    {
        Description = @"Task ID returned from `composeTrack`.",
    };

                    private static string FormatResponse(ParseResult parseResult, global::Beatoven.TaskStatusResponse value, global::System.Text.Json.Serialization.JsonSerializerContext context, bool truncateLongStrings)
                    {
                        string? text = null;
                        CustomizeResponseText(parseResult, value, ref text);
                        if (!string.IsNullOrWhiteSpace(text))
                        {
                            return text;
                        }

                        var hints = new Dictionary<string, CliFormatHint>(StringComparer.OrdinalIgnoreCase)
                        {
                        };
                        CustomizeResponseFormatHints(hints);
                        return CliRuntime.FormatHumanReadable(value, context, truncateLongStrings, hints);
                    }

                    static partial void CustomizeResponseText(ParseResult parseResult, global::Beatoven.TaskStatusResponse value, ref string? text);
                    static partial void CustomizeResponseFormatHints(Dictionary<string, CliFormatHint> hints);


    public static Command Create()
    {
        var command = new Command(@"get-task-status", @"Get composition task status
Returns the current status of a composition task.
When `status` is `composed`, the response includes download URLs
for the full track and individual stems.
");
                        command.Arguments.Add(TaskId);


        command.SetAction(async (ParseResult parseResult, CancellationToken cancellationToken) =>
            await CliRuntime.RunAsync(async () =>
            {
                        var taskId = parseResult.GetRequiredValue(TaskId);
                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);


                                var response = await client.Tasks.GetTaskStatusAsync(
                                    taskId: taskId,
                                    cancellationToken: cancellationToken).ConfigureAwait(false);


                                await CliRuntime.WriteResponseAsync(
                                    parseResult,
                                    response,
                                    global::Beatoven.SourceGenerationContext.Default,
                                    FormatResponse,
                                    cancellationToken).ConfigureAwait(false);
            }, cancellationToken).ConfigureAwait(false));
        return command;
    }
}