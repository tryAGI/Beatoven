
#nullable enable

namespace Beatoven
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class TaskStatusResponse
    {
        /// <summary>
        /// Task lifecycle state.<br/>
        ///   - `composing`: queued<br/>
        ///   - `running`: in progress<br/>
        ///   - `composed`: finished, assets available<br/>
        ///   - `failed`: composition failed
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("status")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Beatoven.JsonConverters.TaskStatusJsonConverter))]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Beatoven.TaskStatus Status { get; set; }

        /// <summary>
        /// Metadata about the composed track (present when `status` is `composed`).
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("meta")]
        public global::Beatoven.TaskMeta? Meta { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskStatusResponse" /> class.
        /// </summary>
        /// <param name="status">
        /// Task lifecycle state.<br/>
        ///   - `composing`: queued<br/>
        ///   - `running`: in progress<br/>
        ///   - `composed`: finished, assets available<br/>
        ///   - `failed`: composition failed
        /// </param>
        /// <param name="meta">
        /// Metadata about the composed track (present when `status` is `composed`).
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public TaskStatusResponse(
            global::Beatoven.TaskStatus status,
            global::Beatoven.TaskMeta? meta)
        {
            this.Status = status;
            this.Meta = meta;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskStatusResponse" /> class.
        /// </summary>
        public TaskStatusResponse()
        {
        }

    }
}