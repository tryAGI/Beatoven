#nullable enable

using System.CommandLine;

namespace Beatoven.CLI.Commands;

internal static class ApiCommand
{
    public static Command Create()
    {
        var command = new Command("api", "Generated endpoint commands.");

                         command.Subcommands.Add(TasksApiGroupCommand.Create());
                         command.Subcommands.Add(TracksApiGroupCommand.Create());
        return command;
    }
}