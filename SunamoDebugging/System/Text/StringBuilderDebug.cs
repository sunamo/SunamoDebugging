namespace SunamoDebugging.System.Text;

public class StringBuilderDebug : DebugStringBuilderAbstract<StringBuilderDebug>
{
    //StringBuilder stringBuilder = new StringBuilder();
    string content = string.Empty;
    public int Length => content.Length;

    Func<string, bool> checkValidity;
    string invalidJavaScriptFilePath = null;

    public StringBuilderDebug()
    {

    }

    public StringBuilderDebug(Func<string, bool> checkValidity, Func<string, string> getFileAppData)
    {
        this.checkValidity = checkValidity;
        if (checkValidity != null)
        {
            invalidJavaScriptFilePath = getFileAppData("InvalidJs.js");
        }
    }

    public override string ToString()
    {
        return content;
    }

    public override StringBuilderDebug AppendLine()
    {
        content += Environment.NewLine;
        return this;
    }

    public override StringBuilderDebug AppendLine(string value)
    {
        content += value + Environment.NewLine;
        CheckValidity();
        return this;
    }

    public void CheckValidity()
    {
        CheckValidityWorker(checkValidity, invalidJavaScriptFilePath, content);
    }

    public static void CheckValidityWorker(Func<string, bool> checkValidity, string invalidJavaScriptFilePath, string content)
    {
        if (checkValidity != null)
        {
            if (!checkValidity(content))
            {
                // Zde je lep�� sync metoda
                File.WriteAllText(invalidJavaScriptFilePath, content);

                ThrowEx.Custom("Invalid JS, written to " + invalidJavaScriptFilePath);
            }
        }
    }

    public override StringBuilderDebug Clear()
    {
        content = string.Empty;
        return this;
    }

    public override StringBuilderDebug Append(string value)
    {
        content += value;
        CheckValidity();
        return this;
    }
}