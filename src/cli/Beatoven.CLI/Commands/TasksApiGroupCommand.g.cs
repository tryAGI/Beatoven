#nullable enable

using System.CommandLine;

namespace Beatoven.CLI.Commands;

internal static partial class TasksApiGroupCommand
{
    static partial void CustomizeCommand(ref Command command);

    public static Command Create()
    {
        var command = new Command(@"tasks", @"tasks endpoint commands.");
                         command.Subcommands.Add(TasksGetTaskStatusCommandApiCommand.Create());
        CustomizeCommand(ref command);
        return command;
    }
}