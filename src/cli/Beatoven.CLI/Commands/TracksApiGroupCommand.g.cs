#nullable enable

using System.CommandLine;

namespace Beatoven.CLI.Commands;

internal static partial class TracksApiGroupCommand
{
    static partial void CustomizeCommand(ref Command command);

    public static Command Create()
    {
        var command = new Command(@"tracks", @"tracks endpoint commands.");
                         command.Subcommands.Add(TracksComposeTrackCommandApiCommand.Create());
        CustomizeCommand(ref command);
        return command;
    }
}