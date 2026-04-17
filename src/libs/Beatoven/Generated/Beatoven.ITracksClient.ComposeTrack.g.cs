#nullable enable

namespace Beatoven
{
    public partial interface ITracksClient
    {
        /// <summary>
        /// Compose a new AI music track<br/>
        /// Starts an asynchronous composition task from a natural-language prompt.<br/>
        /// Returns a task ID that can be polled via `GET /api/v1/tasks/{task_id}`<br/>
        /// until `status` becomes `composed`.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Beatoven.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Beatoven.ComposeTrackResponse> ComposeTrackAsync(

            global::Beatoven.ComposeTrackRequest request,
            global::Beatoven.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
        /// <summary>
        /// Compose a new AI music track<br/>
        /// Starts an asynchronous composition task from a natural-language prompt.<br/>
        /// Returns a task ID that can be polled via `GET /api/v1/tasks/{task_id}`<br/>
        /// until `status` becomes `composed`.
        /// </summary>
        /// <param name="prompt">
        /// Natural-language prompt describing the desired track.
        /// </param>
        /// <param name="format">
        /// Output audio format for the composed track and stems.<br/>
        /// Default Value: wav
        /// </param>
        /// <param name="looping">
        /// Set `true` for a higher amount of looping. Default `false`.<br/>
        /// Default Value: false
        /// </param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::System.InvalidOperationException"></exception>
        global::System.Threading.Tasks.Task<global::Beatoven.ComposeTrackResponse> ComposeTrackAsync(
            global::Beatoven.ComposeTrackPrompt prompt,
            global::Beatoven.ComposeTrackFormat? format = default,
            bool? looping = default,
            global::Beatoven.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}