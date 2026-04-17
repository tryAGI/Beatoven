
#nullable enable

#pragma warning disable CS0618 // Type or member is obsolete
#pragma warning disable CS3016 // Arrays as attribute arguments is not CLS-compliant

namespace Beatoven
{
    /// <summary>
    /// 
    /// </summary>
    [global::System.Text.Json.Serialization.JsonSourceGenerationOptions(
        DefaultIgnoreCondition = global::System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        Converters = new global::System.Type[]
        {
            typeof(global::Beatoven.JsonConverters.ComposeTrackFormatJsonConverter),

            typeof(global::Beatoven.JsonConverters.ComposeTrackFormatNullableJsonConverter),

            typeof(global::Beatoven.JsonConverters.ComposeTrackStatusJsonConverter),

            typeof(global::Beatoven.JsonConverters.ComposeTrackStatusNullableJsonConverter),

            typeof(global::Beatoven.JsonConverters.TaskStatusJsonConverter),

            typeof(global::Beatoven.JsonConverters.TaskStatusNullableJsonConverter),

            typeof(global::Beatoven.JsonConverters.UnixTimestampJsonConverter),
        })]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Beatoven.JsonSerializerContextTypes))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Beatoven.ComposeTrackPrompt))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(string))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Beatoven.ComposeTrackFormat), TypeInfoPropertyName = "ComposeTrackFormat2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Beatoven.ComposeTrackRequest))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(bool))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Beatoven.ComposeTrackStatus), TypeInfoPropertyName = "ComposeTrackStatus2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Beatoven.ComposeTrackResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Beatoven.TaskStatus), TypeInfoPropertyName = "TaskStatus2")]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Beatoven.TaskStemsUrls))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Beatoven.TaskMeta))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(int))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Beatoven.TaskStatusResponse))]
    [global::System.Text.Json.Serialization.JsonSerializable(typeof(global::Beatoven.ErrorResponse))]
    public sealed partial class SourceGenerationContext : global::System.Text.Json.Serialization.JsonSerializerContext
    {
    }
}