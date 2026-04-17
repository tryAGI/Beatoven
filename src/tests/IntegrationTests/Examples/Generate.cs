/*
order: 10
title: Compose Track
slug: compose-track

Shows how to start an asynchronous composition task from a natural-language
prompt and receive the task_id to poll for results.
*/

namespace Beatoven.IntegrationTests;

public partial class Tests
{
    [TestMethod]
    public async Task Example_ComposeTrack()
    {
        //// Beatoven composition is asynchronous. POST /api/v1/tracks/compose returns a task_id
        //// that you then poll via GET /api/v1/tasks/{task_id} until status is "composed".

        using var client = GetAuthenticatedClient();

        var response = await client.Tracks.ComposeTrackAsync(
            prompt: new ComposeTrackPrompt { Text = "30 seconds peaceful lo-fi chill hop track" },
            format: ComposeTrackFormat.Mp3,
            looping: false);

        response.TaskId.Should().NotBeNullOrWhiteSpace();
        response.Status.Should().Be(ComposeTrackStatus.Started);
    }
}
