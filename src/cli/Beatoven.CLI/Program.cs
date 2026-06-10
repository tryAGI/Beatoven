#nullable enable

using System.CommandLine;
using Beatoven.CLI;
using Beatoven.CLI.Commands;

var rootCommand = new RootCommand(@"CLI tool for the Beatoven SDK.");
rootCommand.Options.Add(CliOptions.ApiKey);
rootCommand.Options.Add(CliOptions.BaseUrl);
rootCommand.Options.Add(CliOptions.Json);
rootCommand.Options.Add(CliOptions.Output);
rootCommand.Options.Add(CliOptions.OutputDirectory);
rootCommand.Subcommands.Add(AuthCommand.Create());
rootCommand.Subcommands.Add(TasksApiGroupCommand.Create());
rootCommand.Subcommands.Add(TracksApiGroupCommand.Create());

return await rootCommand.Parse(args).InvokeAsync().ConfigureAwait(false);