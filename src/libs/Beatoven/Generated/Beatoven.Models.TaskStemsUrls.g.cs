
#nullable enable

namespace Beatoven
{
    /// <summary>
    /// Signed download URLs for individual stems of the composed track.
    /// </summary>
    public sealed partial class TaskStemsUrls
    {
        /// <summary>
        /// URL for the bass stem.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("bass")]
        public string? Bass { get; set; }

        /// <summary>
        /// URL for the chords stem.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("chords")]
        public string? Chords { get; set; }

        /// <summary>
        /// URL for the melody stem.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("melody")]
        public string? Melody { get; set; }

        /// <summary>
        /// URL for the percussion stem.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("percussion")]
        public string? Percussion { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskStemsUrls" /> class.
        /// </summary>
        /// <param name="bass">
        /// URL for the bass stem.
        /// </param>
        /// <param name="chords">
        /// URL for the chords stem.
        /// </param>
        /// <param name="melody">
        /// URL for the melody stem.
        /// </param>
        /// <param name="percussion">
        /// URL for the percussion stem.
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public TaskStemsUrls(
            string? bass,
            string? chords,
            string? melody,
            string? percussion)
        {
            this.Bass = bass;
            this.Chords = chords;
            this.Melody = melody;
            this.Percussion = percussion;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskStemsUrls" /> class.
        /// </summary>
        public TaskStemsUrls()
        {
        }
    }
}