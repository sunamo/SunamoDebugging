namespace SunamoDebugging.System.Text;

/// <summary>
/// A StringBuilder implementation with built-in validation support for debugging purposes.
/// Commonly used for JavaScript code generation with real-time syntax validation.
/// </summary>
public class StringBuilderDebug : DebugStringBuilderAbstract<StringBuilderDebug>
{
    private string content = string.Empty;

    /// <summary>
    /// Gets the current length of the content.
    /// </summary>
    public int Length => content.Length;

    private Func<string, bool>? checkValidity;
    private string? invalidJavaScriptFilePath = null;

    /// <summary>
    /// Initializes a new instance of the <see cref="StringBuilderDebug"/> class without validation.
    /// </summary>
    public StringBuilderDebug()
    {

    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StringBuilderDebug"/> class with validation support.
    /// </summary>
    /// <param name="checkValidity">A function that validates the content and returns true if valid.</param>
    /// <param name="getFileAppData">A function that returns the path to the application data file for storing invalid content.</param>
    public StringBuilderDebug(Func<string, bool> checkValidity, Func<string, string> getFileAppData)
    {
        this.checkValidity = checkValidity;
        if (checkValidity != null)
        {
            invalidJavaScriptFilePath = getFileAppData("InvalidJs.js");
        }
    }

    /// <summary>
    /// Returns the current content as a string.
    /// </summary>
    /// <returns>The current content.</returns>
    public override string ToString()
    {
        return content;
    }

    /// <summary>
    /// Appends a line terminator to the content.
    /// </summary>
    /// <returns>The current instance for method chaining.</returns>
    public override StringBuilderDebug AppendLine()
    {
        content += Environment.NewLine;
        return this;
    }

    /// <summary>
    /// Appends a string followed by a line terminator to the content, then validates it.
    /// </summary>
    /// <param name="value">The string to append.</param>
    /// <returns>The current instance for method chaining.</returns>
    public override StringBuilderDebug AppendLine(string value)
    {
        content += value + Environment.NewLine;
        CheckValidity();
        return this;
    }

    /// <summary>
    /// Validates the current content using the validation function provided in the constructor.
    /// </summary>
    public void CheckValidity()
    {
        CheckValidityWorker(checkValidity, invalidJavaScriptFilePath, content);
    }

    /// <summary>
    /// Worker method that performs content validation and writes invalid content to a file.
    /// </summary>
    /// <param name="checkValidity">The validation function.</param>
    /// <param name="invalidJavaScriptFilePath">The file path where invalid content will be written.</param>
    /// <param name="content">The content to validate.</param>
    public static void CheckValidityWorker(Func<string, bool>? checkValidity, string? invalidJavaScriptFilePath, string content)
    {
        if (checkValidity != null && invalidJavaScriptFilePath != null)
        {
            if (!checkValidity(content))
            {
                File.WriteAllText(invalidJavaScriptFilePath, content);

                ThrowEx.Custom("Invalid JS, written to " + invalidJavaScriptFilePath);
            }
        }
    }

    /// <summary>
    /// Clears all content from the builder.
    /// </summary>
    /// <returns>The current instance for method chaining.</returns>
    public override StringBuilderDebug Clear()
    {
        content = string.Empty;
        return this;
    }

    /// <summary>
    /// Appends a string to the content, then validates it.
    /// </summary>
    /// <param name="value">The string to append.</param>
    /// <returns>The current instance for method chaining.</returns>
    public override StringBuilderDebug Append(string value)
    {
        content += value;
        CheckValidity();
        return this;
    }
}