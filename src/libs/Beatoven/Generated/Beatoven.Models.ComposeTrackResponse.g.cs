
#nullable enable

namespace Beatoven
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ComposeTrackResponse
    {
        /// <summary>
        /// Initial composition task status.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("status")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Beatoven.JsonConverters.ComposeTrackStatusJsonConverter))]
        public global::Beatoven.ComposeTrackStatus Status { get; set; }

        /// <summary>
        /// Unique task ID. Poll via `GET /api/v1/tasks/{task_id}`.<br/>
        /// Example: ccb84650-7b4a-4d00-9f80-8a6427ca21aa_1
        /// </summary>
        /// <example>ccb84650-7b4a-4d00-9f80-8a6427ca21aa_1</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("task_id")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string TaskId { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ComposeTrackResponse" /> class.
        /// </summary>
        /// <param name="taskId">
        /// Unique task ID. Poll via `GET /api/v1/tasks/{task_id}`.<br/>
        /// Example: ccb84650-7b4a-4d00-9f80-8a6427ca21aa_1
        /// </param>
        /// <param name="status">
        /// Initial composition task status.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ComposeTrackResponse(
            string taskId,
            global::Beatoven.ComposeTrackStatus status)
        {
            this.Status = status;
            this.TaskId = taskId ?? throw new global::System.ArgumentNullException(nameof(taskId));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComposeTrackResponse" /> class.
        /// </summary>
        public ComposeTrackResponse()
        {
        }
    }
}