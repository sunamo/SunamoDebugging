namespace SunamoDebugging.System.Text;

public class StringBuilderDebug2 : DebugStringBuilderAbstract<StringBuilderDebug2>
{
    private StringBuilder stringBuilder = new StringBuilder();

    public static List<string>? CaptureForAdding { get; set; } = null;

    private Func<string, bool>? checkValidity;
    private Action<StringBuilder>? processBeforeValidity;
    private string? invalidJavaScriptFilePath = null;

    public string? ActualJavaScriptAfterFormattingFilePath { get; set; } = null;

    public string? ActualJavaScriptBeforeFormattingFilePath { get; set; } = null;

    private Func<StringBuilder, string, bool>? canAppend;

    public int ActualLine { get; set; } = 0;

    public int LastWrittenLine { get; set; } = -1;

    public void CheckValidity()
    {
        StringBuilderDebug.CheckValidityWorker(checkValidity, invalidJavaScriptFilePath, stringBuilder.ToString());
    }

    public StringBuilderDebug2()
    {

    }

    public StringBuilderDebug2(Func<string, bool> checkValidity, Action<StringBuilder> processBeforeValidity, Func<StringBuilder, string, bool> canAppend)
    {
        this.checkValidity = checkValidity;
        this.processBeforeValidity = processBeforeValidity;
        this.canAppend = canAppend;
    }

    public override StringBuilderDebug2 AppendLine()
    {
        stringBuilder.AppendLine();
        return this;
    }

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


        CheckValidity();
        return this;
    }

    public override StringBuilderDebug2 Append(string value)
    {
        return Append(stringBuilder.Append, value);
    }

    public override StringBuilderDebug2 Clear()
    {
        stringBuilder.Clear();
        return this;
    }

    public override string ToString()
    {
        return stringBuilder.ToString();
    }
}
