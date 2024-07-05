
namespace SunamoDebugging.System.Text;



public class StringBuilderDebug2 : DebugStringBuilderAbstract<StringBuilderDebug2>
{
    StringBuilder sb = new StringBuilder();
    public static List<string> captureForAdding = null;
    Func<string, bool> checkValidity;
    Action<StringBuilder> processBeforeValidity;
    string fInvalidJs = null;
    public string fActualJsAfterFormatting = null;
    public string fActualJsBeforeFormatting = null;
    Func<StringBuilder, string, bool> canAppend;
    public int actualLine = 0;
    public int lastWrittenLine = -1;

    public void CheckValidity()
    {
        StringBuilderDebug.CheckValidityWorker(checkValidity, fInvalidJs, sb.ToString());
    }

    public StringBuilderDebug2()
    {

    }

    public StringBuilderDebug2(Func<string, bool> checkValidity, Func<string, string, string> getFileAppData, Action<StringBuilder> processBeforeValidity, Func<StringBuilder, string, bool> canAppend)
    {
        this.checkValidity = checkValidity;
        this.processBeforeValidity = processBeforeValidity;
        this.canAppend = canAppend;
        //if (checkValidity != null)
        //{
        //    fInvalidJs = getFileAppData(AppFoldersStrings.Cache, "InvalidJs.js");
        //    fActualJsAfterFormatting = getFileAppData(AppFoldersStrings.Cache, "ActualJsAfterFormatting.js");
        //    fActualJsBeforeFormatting = getFileAppData(AppFoldersStrings.Cache, "ActualJsBeforeFormatting.js");
        //}
    }

#if DEBUG
    private void CheckForSearchingTerms(string value)
    {
        if (captureForAdding != null)
        {
            if (captureForAdding.Any(d => value.Contains(d))) //CA.ContainsAnyFromElementBool(value, captureForAdding))
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
        sb.AppendLine();
        return this;
    }

    public override StringBuilderDebug2 AppendLine(string value)
    {
        return Append(sb.AppendLine, value);
    }

    private StringBuilderDebug2 Append(Func<string, StringBuilder> Append, string value)
    {
        if (value.Contains("methods:"))
        {

        }
#if DEBUG
        CheckForSearchingTerms(value);
#endif
        bool ca = canAppend(sb, value);
        if (ca)
        {
            lastWrittenLine = actualLine;
            sb = Append(value);
        }

        if (value.Trim().TrimEnd(AllChars.comma) == AllStrings.rcub)
        {

        }

        if (value == "  beforeMount() {")
        {

        }

        if (sb.ToString().Contains("methods:"))
        {

        }

        processBeforeValidity(sb);

#if DEBUG
        File.WriteAllText(fActualJsAfterFormatting, sb.ToString());
#endif

        CheckValidity();
        return this;
    }

    public override StringBuilderDebug2 Append(string value)
    {
        return Append(sb.Append, value);
    }

    public override StringBuilderDebug2 Clear()
    {
        sb.Clear();
        return this;
    }

    public override string ToString()
    {
        var r = sb.ToString();
        return r;
    }
}
