namespace SunamoDebugging.System.Text;

public class StringBuilderDebug2 : DebugStringBuilderAbstract<StringBuilderDebug2>
{
    StringBuilder stringBuilder = new StringBuilder();
    public static List<string> CaptureForAdding { get; set; } = null;
    Func<string, bool> checkValidity;
    Action<StringBuilder> processBeforeValidity;
    string invalidJavaScriptFilePath = null;
    public string ActualJavaScriptAfterFormattingFilePath { get; set; } = null;
    public string ActualJavaScriptBeforeFormattingFilePath { get; set; } = null;
    Func<StringBuilder, string, bool> canAppend;
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
        //if (checkValidity != null)
        //{
        //    invalidJavaScriptFilePath = getFileAppData(AppFoldersStrings.Cache, "InvalidJs.js");
        //    ActualJavaScriptAfterFormattingFilePath = getFileAppData(AppFoldersStrings.Cache, "ActualJsAfterFormatting.js");
        //    ActualJavaScriptBeforeFormattingFilePath = getFileAppData(AppFoldersStrings.Cache, "ActualJsBeforeFormatting.js");
        //}
    }

#if DEBUG
    private void CheckForSearchingTerms(string value)
    {
        if (CaptureForAdding != null)
        {
            if (CaptureForAdding.Any(searchTerm => value.Contains(searchTerm))) //CA.ContainsAnyFromElementBool(value, CaptureForAdding))
            {
                int i = 0;
                if (value == "{")
                {

                }
            }
        }
    }
#endif

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
        if (value.Contains("methods:"))
        {

        }
#if DEBUG
        CheckForSearchingTerms(value);
#endif
        bool shouldAppend = canAppend(stringBuilder, value);
        if (shouldAppend)
        {
            LastWrittenLine = ActualLine;
            stringBuilder = append(value);
        }

        if (value.Trim().TrimEnd(',') == "}")
        {

        }

        if (value == "  beforeMount() {")
        {

        }

        if (stringBuilder.ToString().Contains("methods:"))
        {

        }

        processBeforeValidity(stringBuilder);

#if DEBUG
        File.WriteAllText(ActualJavaScriptAfterFormattingFilePath, stringBuilder.ToString());
#endif

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
        var result = stringBuilder.ToString();
        return result;
    }
}