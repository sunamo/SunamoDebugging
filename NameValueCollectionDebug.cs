namespace SunamoDebugging;

public class NameValueCollectionDebug
{
    public static void Print(NameValueCollection nvc)
    {
        foreach (var item in nvc.AllKeys)
        {
            d(item + ": " + nvc[item]);
        }
    }

    private static void d(string v)
    {
        Debug.WriteLine(v);
    }
}
