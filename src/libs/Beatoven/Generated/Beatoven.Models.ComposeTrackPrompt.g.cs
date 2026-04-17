
#nullable enable

namespace Beatoven
{
    /// <summary>
    /// Natural-language prompt describing the desired track.
    /// </summary>
    public sealed partial class ComposeTrackPrompt
    {
        /// <summary>
        /// Freeform prompt, e.g. `30 seconds peaceful lo-fi chill hop track`.<br/>
        /// Example: 30 seconds peaceful lo-fi chill hop track
        /// </summary>
        /// <example>30 seconds peaceful lo-fi chill hop track</example>
        [global::System.Text.Json.Serialization.JsonPropertyName("text")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required string Text { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ComposeTrackPrompt" /> class.
        /// </summary>
        /// <param name="text">
        /// Freeform prompt, e.g. `30 seconds peaceful lo-fi chill hop track`.<br/>
        /// Example: 30 seconds peaceful lo-fi chill hop track
        /// </param>
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ComposeTrackPrompt(
            string text)
        {
            this.Text = text ?? throw new global::System.ArgumentNullException(nameof(text));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComposeTrackPrompt" /> class.
        /// </summary>
        public ComposeTrackPrompt()
        {
        }
    }
}