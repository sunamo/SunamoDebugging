namespace SunamoDebugging.System.Text;

/// <summary>
/// Represents the string builder debug type.
/// </summary>
public class StringBuilderDebug : DebugStringBuilderAbstract<StringBuilderDebug>
{
    private string content = string.Empty;

    /// <summary>
    /// Gets the length.
    /// </summary>
    public int Length => content.Length;

    private Func<string, bool>? checkValidity;
    private string? invalidJavaScriptFilePath = null;

    /// <summary>
    /// String builder debug.
    /// </summary>
    /// <returns>The string builder debug result.</returns>
    public StringBuilderDebug()
    {

    }

    /// <summary>
    /// String builder debug.
    /// </summary>
    /// <param name="checkValidity">The check validity.</param>
    /// <param name="getFileAppData">The get file app data.</param>
    /// <returns>The string builder debug result.</returns>
    public StringBuilderDebug(Func<string, bool> checkValidity, Func<string, string> getFileAppData)
    {
        this.checkValidity = checkValidity;
        if (checkValidity != null)
        {
            invalidJavaScriptFilePath = getFileAppData("InvalidJs.js");
        }
    }

    /// <summary>
    /// To string.
    /// </summary>
    /// <returns>The to string result.</returns>
    public override string ToString()
    {
        return content;
    }

    /// <summary>
    /// Append line.
    /// </summary>
    /// <returns>The append line result.</returns>
    public override StringBuilderDebug AppendLine()
    {
        content += Environment.NewLine;
        return this;
    }

    /// <summary>
    /// Append line.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The append line result.</returns>
    public override StringBuilderDebug AppendLine(string value)
    {
        content += value + Environment.NewLine;
        CheckValidity();
        return this;
    }

    /// <summary>
    /// Check validity.
    /// </summary>
    /// <returns>The check validity result.</returns>
    public void CheckValidity()
    {
        CheckValidityWorker(checkValidity, invalidJavaScriptFilePath, content);
    }

    /// <summary>
    /// Initializes a new instance of the check validity worker class.
    /// </summary>
    /// <param name="checkValidity">The check validity.</param>
    /// <param name="invalidJavaScriptFilePath">The invalid java script file path.</param>
    /// <param name="content">The content.</param>
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
    /// Clear.
    /// </summary>
    /// <returns>The clear result.</returns>
    public override StringBuilderDebug Clear()
    {
        content = string.Empty;
        return this;
    }

    /// <summary>
    /// Append.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The append result.</returns>
    public override StringBuilderDebug Append(string value)
    {
        content += value;
        CheckValidity();
        return this;
    }
}
