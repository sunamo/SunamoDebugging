namespace SunamoDebugging;

/// <summary>
/// Represents the name value collection debug type.
/// </summary>
public class NameValueCollectionDebug
{
    /// <summary>
    /// Print.
    /// </summary>
    /// <param name="collection">The collection.</param>
    public static void Print(NameValueCollection collection)
    {
        foreach (var item in collection.AllKeys) WriteDebugLine(item + ": " + collection[item]);
    }

    private static void WriteDebugLine(string message)
    {
        Debug.WriteLine(message);
    }
}
