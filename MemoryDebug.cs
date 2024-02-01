
namespace SunamoDebugging;
using SunamoEnums.Enums;



public class MemoryDebug
{
    public static StreamWriter swAllocatedMemory;
    public static bool initialized = false;

    public static void Init(string pathWithoutFn)
    {
        var p = Path.Combine(pathWithoutFn, "AllocatedMemory.txt");
        if (!initialized)
        {
            initialized = true;
            File.WriteAllTextAsync(p, string.Empty);
            swAllocatedMemory = new StreamWriter(p);
            swAllocatedMemory.AutoFlush = true;
        }
    }

    static long l2 = 0;
    static long last = 0;

    public static void WriteLine(long l)
    {
        if (l2 == 0)
        {
            l2 = l;
        }
        swAllocatedMemory.WriteLine(l);

        last = l;
    }

    public static void OverallConsumedByThisMethod()
    {
        var l = last - l2;
        //swAllocatedMemory.WriteLine("Difference between first and latest: " + FS.GetSizeInAutoString(l, ComputerSizeUnits.B));
    }
}
