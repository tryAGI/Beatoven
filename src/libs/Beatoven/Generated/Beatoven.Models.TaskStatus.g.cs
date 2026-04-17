
#nullable enable

namespace Beatoven
{
    /// <summary>
    /// Task lifecycle state.<br/>
    ///   - `composing`: queued<br/>
    ///   - `running`: in progress<br/>
    ///   - `composed`: finished, assets available<br/>
    ///   - `failed`: composition failed
    /// </summary>
    public enum TaskStatus
    {
        /// <summary>
        /// finished, assets available
        /// </summary>
        Composed,
        /// <summary>
        /// queued
        /// </summary>
        Composing,
        /// <summary>
        /// composition failed
        /// </summary>
        Failed,
        /// <summary>
        /// in progress
        /// </summary>
        Running,
    }

    /// <summary>
    /// Enum extensions to do fast conversions without the reflection.
    /// </summary>
    public static class TaskStatusExtensions
    {
        /// <summary>
        /// Converts an enum to a string.
        /// </summary>
        public static string ToValueString(this TaskStatus value)
        {
            return value switch
            {
                TaskStatus.Composed => "composed",
                TaskStatus.Composing => "composing",
                TaskStatus.Failed => "failed",
                TaskStatus.Running => "running",
                _ => throw new global::System.ArgumentOutOfRangeException(nameof(value), value, null),
            };
        }
        /// <summary>
        /// Converts an string to a enum.
        /// </summary>
        public static TaskStatus? ToEnum(string value)
        {
            return value switch
            {
                "composed" => TaskStatus.Composed,
                "composing" => TaskStatus.Composing,
                "failed" => TaskStatus.Failed,
                "running" => TaskStatus.Running,
                _ => null,
            };
        }
    }
}