namespace SunamoDebugging.System.Text;



public class StringBuilderDebug : DebugStringBuilderAbstract<StringBuilderDebug>
{
    //StringBuilder sb = new StringBuilder();
    string s = string.Empty;
    public int Length => s.Length;

    Func<string, bool> checkValidity;
    string fInvalidJs = null;

    public StringBuilderDebug()
    {

    }

    public StringBuilderDebug(Func<string, bool> checkValidity, Func<string, string> getFileAppData)
    {
        this.checkValidity = checkValidity;
        if (checkValidity != null)
        {
            fInvalidJs = getFileAppData("InvalidJs.js");
        }
    }

    public override string ToString()
    {
        return s;
    }

    public override StringBuilderDebug AppendLine()
    {
        s += Environment.NewLine;
        return this;
    }

    public override StringBuilderDebug AppendLine(string value)
    {
        s += value + Environment.NewLine;
        CheckValidity();
        return this;
    }

    public void CheckValidity()
    {
        CheckValidityWorker(checkValidity, fInvalidJs, s);
    }

    public static void CheckValidityWorker(Func<string, bool> checkValidity, string fInvalidJs, string s)
    {
        if (checkValidity != null)
        {
            if (!checkValidity(s))
            {
                // Zde je lep�� sync metoda
                File.WriteAllText(fInvalidJs, s);

                ThrowEx.Custom("Invalid JS, written to " + fInvalidJs);
            }
        }
    }

    public override StringBuilderDebug Clear()
    {
        s = string.Empty;
        return this;
    }

    public override StringBuilderDebug Append(string value)
    {
        s += value;
        CheckValidity();
        return this;
    }
}
