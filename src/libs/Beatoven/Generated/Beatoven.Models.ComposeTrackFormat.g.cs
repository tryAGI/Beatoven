
#nullable enable

namespace Beatoven
{
    /// <summary>
    /// Output audio format for the composed track and stems.<br/>
    /// Default Value: wav
    /// </summary>
    public enum ComposeTrackFormat
    {
        /// <summary>
        /// 
        /// </summary>
        Aac,
        /// <summary>
        /// 
        /// </summary>
        Mp3,
        /// <summary>
        /// 
        /// </summary>
        Wav,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ComposeTrackFormatExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ComposeTrackFormat value)
        {
            return value switch
            {
                ComposeTrackFormat.Aac => "aac",
                ComposeTrackFormat.Mp3 => "mp3",
                ComposeTrackFormat.Wav => "wav",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ComposeTrackFormat? ToEnum(string value)
        {
            return value switch
            {
                "aac" => ComposeTrackFormat.Aac,
                "mp3" => ComposeTrackFormat.Mp3,
                "wav" => ComposeTrackFormat.Wav,
                _ => null,
            };
        }
    }
}