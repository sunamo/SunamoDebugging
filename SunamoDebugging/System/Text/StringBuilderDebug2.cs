namespace SunamoDebugging.System.Text;

/// <summary>
/// An advanced StringBuilder implementation with validation, formatting, and conditional append support for debugging.
/// Commonly used for JavaScript code generation with line-by-line tracking and syntax validation.
/// </summary>
public class StringBuilderDebug2 : DebugStringBuilderAbstract<StringBuilderDebug2>
{
    private StringBuilder stringBuilder = new StringBuilder();

    /// <summary>
    /// Gets or sets a list of search terms to capture for debugging purposes.
    /// When any appended value contains these terms, a breakpoint can be triggered.
    /// </summary>
    public static List<string>? CaptureForAdding { get; set; } = null;

    private Func<string, bool>? checkValidity;
    private Action<StringBuilder>? processBeforeValidity;
    private string? invalidJavaScriptFilePath = null;

    /// <summary>
    /// Gets or sets the file path where the actual JavaScript content is written after formatting (DEBUG only).
    /// </summary>
    public string? ActualJavaScriptAfterFormattingFilePath { get; set; } = null;

    /// <summary>
    /// Gets or sets the file path where the actual JavaScript content is written before formatting (DEBUG only).
    /// </summary>
    public string? ActualJavaScriptBeforeFormattingFilePath { get; set; } = null;

    private Func<StringBuilder, string, bool>? canAppend;

    /// <summary>
    /// Gets or sets the current line number being processed.
    /// </summary>
    public int ActualLine { get; set; } = 0;

    /// <summary>
    /// Gets or sets the line number that was last written to the builder.
    /// </summary>
    public int LastWrittenLine { get; set; } = -1;

    /// <summary>
    /// Validates the current content using the validation function provided in the constructor.
    /// </summary>
    public void CheckValidity()
    {
        StringBuilderDebug.CheckValidityWorker(checkValidity, invalidJavaScriptFilePath, stringBuilder.ToString());
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StringBuilderDebug2"/> class without validation.
    /// </summary>
    public StringBuilderDebug2()
    {

    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StringBuilderDebug2"/> class with validation and processing support.
    /// </summary>
    /// <param name="checkValidity">A function that validates the content and returns true if valid.</param>
    /// <param name="processBeforeValidity">An action to process the StringBuilder before validation.</param>
    /// <param name="canAppend">A function that determines whether a value can be appended.</param>
    public StringBuilderDebug2(Func<string, bool> checkValidity, Action<StringBuilder> processBeforeValidity, Func<StringBuilder, string, bool> canAppend)
    {
        this.checkValidity = checkValidity;
        this.processBeforeValidity = processBeforeValidity;
        this.canAppend = canAppend;
    }

    /// <summary>
    /// Appends a line terminator to the content.
    /// </summary>
    /// <returns>The current instance for method chaining.</returns>
    public override StringBuilderDebug2 AppendLine()
    {
        stringBuilder.AppendLine();
        return this;
    }

    /// <summary>
    /// Appends a string followed by a line terminator to the content, then validates it.
    /// </summary>
    /// <param name="value">The string to append.</param>
    /// <returns>The current instance for method chaining.</returns>
    public override StringBuilderDebug2 AppendLine(string value)
    {
        return Append(stringBuilder.AppendLine, value);
    }

    private StringBuilderDebug2 Append(Func<string, StringBuilder> append, string value)
    {
        bool shouldAppend = canAppend?.Invoke(stringBuilder, value) ?? true;
        if (shouldAppend)
        {
            LastWrittenLine = ActualLine;
            stringBuilder = append(value);
        }

        processBeforeValidity?.Invoke(stringBuilder);

#if DEBUG
        if (ActualJavaScriptAfterFormattingFilePath != null)
        {
            File.WriteAllText(ActualJavaScriptAfterFormattingFilePath, stringBuilder.ToString());
        }
#endif

        CheckValidity();
        return this;
    }

    /// <summary>
    /// Appends a string to the content, then validates it.
    /// </summary>
    /// <param name="value">The string to append.</param>
    /// <returns>The current instance for method chaining.</returns>
    public override StringBuilderDebug2 Append(string value)
    {
        return Append(stringBuilder.Append, value);
    }

    /// <summary>
    /// Clears all content from the builder.
    /// </summary>
    /// <returns>The current instance for method chaining.</returns>
    public override StringBuilderDebug2 Clear()
    {
        stringBuilder.Clear();
        return this;
    }

    /// <summary>
    /// Returns the current content as a string.
    /// </summary>
    /// <returns>The current content.</returns>
    public override string ToString()
    {
        var result = stringBuilder.ToString();
        return result;
    }
}