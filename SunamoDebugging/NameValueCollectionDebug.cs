namespace SunamoDebugging;

public class NameValueCollectionDebug
{
    public static void Print(NameValueCollection collection)
    {
        foreach (var item in collection.AllKeys) WriteDebugLine(item + ": " + collection[item]);
    }

    private static void WriteDebugLine(string message)
    {
        Debug.WriteLine(message);
    }
}