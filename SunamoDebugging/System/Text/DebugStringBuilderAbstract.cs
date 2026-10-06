namespace SunamoDebugging.System.Text;

public abstract class DebugStringBuilderAbstract<T>
{
    public abstract T Append(string value);

    public abstract T AppendLine();

    public abstract T AppendLine(string value);

    public abstract T Clear();

    public abstract override string ToString();
}
