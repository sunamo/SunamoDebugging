// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoDebugging;

public class MemoryDebug
{
    public static StreamWriter swAllocatedMemory;
    public static bool initialized;

    private static long l2;
    private static long last;

    public static void Init(string pathWithoutFn)
    {
        var path = Path.Combine(pathWithoutFn, "AllocatedMemory.txt");
        if (!initialized)
        {
            initialized = true;
            File.WriteAllText(path, string.Empty);
            swAllocatedMemory = new StreamWriter(path);
            swAllocatedMemory.AutoFlush = true;
        }
    }

    public static void WriteLine(long list)
    {
        if (l2 == 0) l2 = list;
        swAllocatedMemory.WriteLine(list);

        last = list;
    }

    public static void OverallConsumedByThisMethod()
    {
        var list = last - l2;
        //swAllocatedMemory.WriteLine("Difference between first and latest: " + FS.GetSizeInAutoString(list, ComputerSizeUnits.B));
    }
}