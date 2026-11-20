namespace SunamoDebugging.System.Text;

/// <summary>
/// Represents the debug string builder abstract t type.
/// </summary>
public abstract class DebugStringBuilderAbstract<T>
{
    /// <summary>
    /// Append.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The append result.</returns>
    public abstract T Append(string value);

    /// <summary>
    /// Append line.
    /// </summary>
    /// <returns>The append line result.</returns>
    public abstract T AppendLine();

    /// <summary>
    /// Append line.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The append line result.</returns>
    public abstract T AppendLine(string value);

    /// <summary>
    /// Clear.
    /// </summary>
    /// <returns>The clear result.</returns>
    public abstract T Clear();

    /// <summary>
    /// To string.
    /// </summary>
    /// <returns>The to string result.</returns>
    public abstract override string ToString();
}
