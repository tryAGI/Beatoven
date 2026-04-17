
#nullable enable

namespace Beatoven
{
    /// <summary>
    /// Initial composition task status.
    /// </summary>
    public enum ComposeTrackStatus
    {
        /// <summary>
        /// 
        /// </summary>
        Started,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class ComposeTrackStatusExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this ComposeTrackStatus value)
        {
            return value switch
            {
                ComposeTrackStatus.Started => "started",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static ComposeTrackStatus? ToEnum(string value)
        {
            return value switch
            {
                "started" => ComposeTrackStatus.Started,
                _ => null,
            };
        }
    }
}