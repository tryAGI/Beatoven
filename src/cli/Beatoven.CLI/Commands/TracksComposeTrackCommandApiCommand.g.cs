#nullable enable
#pragma warning disable CS0618

using System.CommandLine;

namespace Beatoven.CLI.Commands;

internal static partial class TracksComposeTrackCommandApiCommand
{
    private static Option<global::Beatoven.ComposeTrackPrompt> Prompt { get; } = new(
        name: @"--prompt")
    {
        Description = @"Natural-language prompt describing the desired track.",
        Required = true,
    };

    private static Option<global::Beatoven.ComposeTrackFormat?> Format { get; } = new(
        name: @"--format")
    {
        Description = @"Output audio format for the composed track and stems.",
    };

    private static Option<bool?> Looping { get; } = CliRuntime.CreateNullableBoolOption(
        name: @"--looping",
        description: @"Set `true` for a higher amount of looping. Default `false`.");
      private static Option<string?> Input { get; } = new(@"--input")
      {
          Description = "Load request JSON from a file path, '-' for stdin, or an inline JSON object/array string.",
      };

      private static Option<string?> RequestJson { get; } = new(@"--request-json")
      {
          Description = "Request body as JSON.",
          Hidden = true,
      };

      private static Option<string?> RequestFile { get; } = new(@"--request-file")
      {
          Description = "Path to a JSON request file, or '-' for stdin.",
          Hidden = true,
      };

                    private static string FormatResponse(ParseResult parseResult, global::Beatoven.ComposeTrackResponse value, global::System.Text.Json.Serialization.JsonSerializerContext context, bool truncateLongStrings)
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

                    static partial void CustomizeResponseText(ParseResult parseResult, global::Beatoven.ComposeTrackResponse value, ref string? text);
                    static partial void CustomizeResponseFormatHints(Dictionary<string, CliFormatHint> hints);


    public static Command Create()
    {
        var command = new Command(@"compose-track", @"Compose a new AI music track
Starts an asynchronous composition task from a natural-language prompt.
Returns a task ID that can be polled via `GET /api/v1/tasks/{task_id}`
until `status` becomes `composed`.
");
                        command.Options.Add(Prompt);
                        command.Options.Add(Format);
                        command.Options.Add(Looping);
          command.Options.Add(Input);
          command.Options.Add(RequestJson);
          command.Options.Add(RequestFile);
          command.Validators.Add(result =>
          {
              var hasInput = result.GetResult(Input) is not null;
              var hasRequestJson = result.GetResult(RequestJson) is not null;
              var hasRequestFile = result.GetResult(RequestFile) is not null;
              var specifiedCount = (hasInput ? 1 : 0) + (hasRequestJson ? 1 : 0) + (hasRequestFile ? 1 : 0);
              if (specifiedCount > 1)
              {
                  result.AddError(@"Specify at most one of --input, --request-json, or --request-file.");
              }
          });

        command.SetAction(async (ParseResult parseResult, CancellationToken cancellationToken) =>
            await CliRuntime.RunAsync(async () =>
            {
                        var __requestBase = await CliRuntime.ReadRequestOrDefaultAsync<global::Beatoven.ComposeTrackRequest>(
                            parseResult,
                            Input,
                            RequestJson,
                            RequestFile,
                            global::Beatoven.SourceGenerationContext.Default,
                            cancellationToken).ConfigureAwait(false);
                        var prompt = parseResult.GetRequiredValue(Prompt);
                        var format = CliRuntime.WasSpecified(parseResult, Format) ? parseResult.GetValue(Format) : (__requestBase is { } __FormatBaseValue ? __FormatBaseValue.Format : default);
                        var looping = CliRuntime.WasSpecified(parseResult, Looping) ? parseResult.GetValue(Looping) : (__requestBase is { } __LoopingBaseValue ? __LoopingBaseValue.Looping : default);
                using var client = await CliRuntime.CreateClientAsync(parseResult, cancellationToken).ConfigureAwait(false);


                                var response = await client.Tracks.ComposeTrackAsync(
                                    prompt: prompt,
                                    format: format,
                                    looping: looping,
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