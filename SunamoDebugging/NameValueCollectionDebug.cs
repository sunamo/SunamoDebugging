// variables names: ok
namespace SunamoDebugging;

/// <summary>
/// Provides debugging utilities for NameValueCollection instances.
/// </summary>
public class NameValueCollectionDebug
{
    /// <summary>
    /// Prints all key-value pairs from the collection to the debug output.
    /// </summary>
    /// <param name="collection">The NameValueCollection to print.</param>
    public static void Print(NameValueCollection collection)
    {
        foreach (var item in collection.AllKeys) WriteDebugLine(item + ": " + collection[item]);
    }

    private static void WriteDebugLine(string message)
    {
        Debug.WriteLine(message);
    }
}