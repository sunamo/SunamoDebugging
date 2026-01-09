// variables names: ok
namespace SunamoDebugging.System.Text;

/// <summary>
/// Abstract base class for debug-enabled StringBuilder implementations.
/// Defines the minimal interface required for debugging string building operations.
/// </summary>
/// <typeparam name="T">The derived class type for method chaining.</typeparam>
public abstract class DebugStringBuilderAbstract<T>
{
    /// <summary>
    /// Appends a string to the builder.
    /// </summary>
    /// <param name="value">The string to append.</param>
    /// <returns>The current instance for method chaining.</returns>
    public abstract T Append(string value);

    /// <summary>
    /// Appends a line terminator to the builder.
    /// </summary>
    /// <returns>The current instance for method chaining.</returns>
    public abstract T AppendLine();

    /// <summary>
    /// Appends a string followed by a line terminator to the builder.
    /// </summary>
    /// <param name="value">The string to append.</param>
    /// <returns>The current instance for method chaining.</returns>
    public abstract T AppendLine(string value);

    /// <summary>
    /// Clears all content from the builder.
    /// </summary>
    /// <returns>The current instance for method chaining.</returns>
    public abstract T Clear();

    /// <summary>
    /// Returns the current content as a string.
    /// </summary>
    /// <returns>The current content.</returns>
    public abstract override string ToString();
}