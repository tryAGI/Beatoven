
#nullable enable

namespace Beatoven
{
    /// <summary>
    /// Example: {"prompt":{"text":"30 seconds peaceful lo-fi chill hop track"},"format":"wav","looping":false}
    /// </summary>
    public sealed partial class ComposeTrackRequest
    {
        /// <summary>
        /// Natural-language prompt describing the desired track.
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("prompt")]
        [global::System.Text.Json.Serialization.JsonRequired]
        public required global::Beatoven.ComposeTrackPrompt Prompt { get; set; }

        /// <summary>
        /// Output audio format for the composed track and stems.<br/>
        /// Default Value: wav
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("format")]
        [global::System.Text.Json.Serialization.JsonConverter(typeof(global::Beatoven.JsonConverters.ComposeTrackFormatJsonConverter))]
        public global::Beatoven.ComposeTrackFormat? Format { get; set; }

        /// <summary>
        /// Set `true` for a higher amount of looping. Default `false`.<br/>
        /// Default Value: false
        /// </summary>
        [global::System.Text.Json.Serialization.JsonPropertyName("looping")]
        public bool? Looping { get; set; }

        /// <summary>
        /// Additional properties that are not explicitly defined in the schema
        /// </summary>
        [global::System.Text.Json.Serialization.JsonExtensionData]
        public global::System.Collections.Generic.IDictionary<string, object> AdditionalProperties { get; set; } = new global::System.Collections.Generic.Dictionary<string, object>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ComposeTrackRequest" /> class.
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
#if NET7_0_OR_GREATER
        [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
        public ComposeTrackRequest(
            global::Beatoven.ComposeTrackPrompt prompt,
            global::Beatoven.ComposeTrackFormat? format,
            bool? looping)
        {
            this.Prompt = prompt ?? throw new global::System.ArgumentNullException(nameof(prompt));
            this.Format = format;
            this.Looping = looping;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComposeTrackRequest" /> class.
        /// </summary>
        public ComposeTrackRequest()
        {
        }
    }
}