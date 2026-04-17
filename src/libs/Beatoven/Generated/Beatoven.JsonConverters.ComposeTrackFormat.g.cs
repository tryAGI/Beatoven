#nullable enable

namespace Beatoven.JsonConverters
{
    /// <inheritdoc />
    public sealed class ComposeTrackFormatJsonConverter : global::System.Text.Json.Serialization.JsonConverter<global::Beatoven.ComposeTrackFormat>
    {
        /// <inheritdoc />
        public override global::Beatoven.ComposeTrackFormat Read(
            ref global::System.Text.Json.Utf8JsonReader reader,
            global::System.Type typeToConvert,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case global::System.Text.Json.JsonTokenType.String:
                {
                    var stringValue = reader.GetString();
                    if (stringValue != null)
                    {
                        return global::Beatoven.ComposeTrackFormatExtensions.ToEnum(stringValue) ?? default;
                    }
                    
                    break;
                }
                case global::System.Text.Json.JsonTokenType.Number:
                {
                    var numValue = reader.GetInt32();
                    return (global::Beatoven.ComposeTrackFormat)numValue;
                }
                case global::System.Text.Json.JsonTokenType.Null:
                {
                    return default(global::Beatoven.ComposeTrackFormat);
                }
                default:
                    throw new global::System.ArgumentOutOfRangeException(nameof(reader));
            }

            return default;
        }

        /// <inheritdoc />
        public override void Write(
            global::System.Text.Json.Utf8JsonWriter writer,
            global::Beatoven.ComposeTrackFormat value,
            global::System.Text.Json.JsonSerializerOptions options)
        {
            writer = writer ?? throw new global::System.ArgumentNullException(nameof(writer));

            writer.WriteStringValue(global::Beatoven.ComposeTrackFormatExtensions.ToValueString(value));
        }
    }
}
