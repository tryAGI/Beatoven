#nullable enable

using System.CommandLine;

namespace Beatoven.CLI.Commands;

internal static class TracksApiGroupCommand
{
    public static Command Create()
    {
        var command = new Command(@"tracks", @"tracks endpoint commands.");
                         command.Subcommands.Add(TracksComposeTrackCommandApiCommand.Create());
        return command;
    }
}