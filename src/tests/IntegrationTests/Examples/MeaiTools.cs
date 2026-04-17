/*
order: 40
title: MEAI Tools
slug: meai-tools

Shows how to expose Beatoven operations as AIFunction tools that any
Microsoft.Extensions.AI IChatClient can invoke.
*/

using Microsoft.Extensions.AI;

namespace Beatoven.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public void Example_AsComposeTrackTool()
    {
        //// Expose the compose-track operation as an AIFunction tool that a chat model
        //// can call. It accepts `prompt`, optional `format` ("wav", "mp3", "aac") and `looping`.

        using var client = GetAuthenticatedClient();

        AIFunction tool = client.AsComposeTrackTool();

        tool.Name.Should().Be("BeatovenComposeTrack");
        tool.Description.Should().Contain("prompt");
    }

    [TestMethod]
    public void Example_AsGetTaskStatusTool()
    {
        //// Expose the poll-status operation as an AIFunction tool.

        using var client = GetAuthenticatedClient();

        AIFunction tool = client.AsGetTaskStatusTool();

        tool.Name.Should().Be("BeatovenGetTaskStatus");
        tool.Description.Should().Contain("composition");
    }

    [TestMethod]
    public void Example_AsWaitForTrackTool()
    {
        //// Expose a polling helper that waits until the composition finishes.

        using var client = GetAuthenticatedClient();

        AIFunction tool = client.AsWaitForTrackTool();

        tool.Name.Should().Be("BeatovenWaitForTrack");
        tool.Description.Should().Contain("Polls");
    }

    [TestMethod]
    public void Example_AsListMoodsTool()
    {
        //// Expose a curated list of moods/genres that can be used inside a compose prompt.

        using var client = GetAuthenticatedClient();

        AIFunction tool = client.AsListMoodsTool();

        tool.Name.Should().Be("BeatovenListMoods");
        tool.Description.Should().Contain("mood");
    }
}
