#nullable enable

namespace Beatoven
{
    public partial interface ITasksClient
    {
        /// <summary>
        /// Get composition task status<br/>
        /// Returns the current status of a composition task.<br/>
        /// When `status` is `composed`, the response includes download URLs<br/>
        /// for the full track and individual stems.
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="requestOptions">Per-request overrides such as headers, query parameters, timeout, retries, and response buffering.</param>
        /// <param name="cancellationToken">The token to cancel the operation with</param>
        /// <exception cref="global::Beatoven.ApiException"></exception>
        global::System.Threading.Tasks.Task<global::Beatoven.TaskStatusResponse> GetTaskStatusAsync(
            string taskId,
            global::Beatoven.AutoSDKRequestOptions? requestOptions = default,
            global::System.Threading.CancellationToken cancellationToken = default);
    }
}