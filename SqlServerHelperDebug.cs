namespace SunamoDebugging;

public class SqlServerHelperDebug
{
    private static Type type = typeof(SqlServerHelperDebug);

    /// <summary>
    ///     Musím zde předat přímo Dict a nezjištovat si počty řádků až zde - to bych musel referencovat SunamoSqlServer a
    ///     nemohl bych tak používat SunamoDebugging in SunamoSqlServer
    ///     The same TextOutputGenerator in sunamo -
    /// </summary>
    /// <param name="l"></param>
    /// <returns></returns>
    public static void RowsInTables(Dictionary<string, int> l)
    {
        ThrowEx.NotImplementedMethod();
    }
}