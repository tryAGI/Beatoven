
#nullable enable

namespace Beatoven
{
    /// <summary>
    /// Metadata about the composed track (present when `status` is `composed`).
    /// </summary>
    public sealed partial class TaskMeta
    {
        /// <summary>
        /// Beatoven project UUID.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("project_id")]
        public string? ProjectId { get; set; }

        /// <summary>
        /// Beatoven track UUID.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("track_id")]
        public string? TrackId { get; set; }

        /// <summary>
        /// Natural-language prompt describing the desired track.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("prompt")]
        public global::Beatoven.ComposeTrackPrompt? Prompt { get; set; }

        /// <summary>
        /// Track version number.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("version")]
        public int? Version { get; set; }

        /// <summary>
        /// Signed URL to download the full mixed track.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("track_url")]
        public string? TrackUrl { get; set; }

        /// <summary>
        /// Signed download URLs for individual stems of the composed track.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("stems_url")]
        public global::Beatoven.TaskStemsUrls? StemsUrl { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskMeta" /> class.
        /// </summary>
        /// <param name="projectId">
        /// Beatoven project UUID.
        /// </param>
        /// <param name="trackId">
        /// Beatoven track UUID.
        /// </param>
        /// <param name="prompt">
        /// Natural-language prompt describing the desired track.
        /// </param>
        /// <param name="version">
        /// Track version number.
        /// </param>
        /// <param name="trackUrl">
        /// Signed URL to download the full mixed track.
        /// </param>
        /// <param name="stemsUrl">
        /// Signed download URLs for individual stems of the composed track.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public TaskMeta(
            string? projectId,
            string? trackId,
            global::Beatoven.ComposeTrackPrompt? prompt,
            int? version,
            string? trackUrl,
            global::Beatoven.TaskStemsUrls? stemsUrl)
        {
            this.ProjectId = projectId;
            this.TrackId = trackId;
            this.Prompt = prompt;
            this.Version = version;
            this.TrackUrl = trackUrl;
            this.StemsUrl = stemsUrl;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskMeta" /> class.
        /// </summary>
        public TaskMeta()
        {
        }
    }
}