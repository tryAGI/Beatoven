#nullable enable

using System.CommandLine;

namespace Beatoven.CLI.Commands;

internal static class TasksApiGroupCommand
{
    public static Command Create()
    {
        var command = new Command(@"tasks", @"tasks endpoint commands.");
                         command.Subcommands.Add(TasksGetTaskStatusCommandApiCommand.Create());
        return command;
    }
}