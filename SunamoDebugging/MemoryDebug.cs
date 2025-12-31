namespace SunamoDebugging;

public class MemoryDebug
{
    public static StreamWriter AllocatedMemoryWriter;
    public static bool Initialized;

    private static long firstMemoryValue;
    private static long lastMemoryValue;

    public static void Init(string directoryPath)
    {
        var path = Path.Combine(directoryPath, "AllocatedMemory.txt");
        if (!Initialized)
        {
            Initialized = true;
            File.WriteAllText(path, string.Empty);
            AllocatedMemoryWriter = new StreamWriter(path);
            AllocatedMemoryWriter.AutoFlush = true;
        }
    }

    public static void WriteLine(long memoryValue)
    {
        if (firstMemoryValue == 0) firstMemoryValue = memoryValue;
        AllocatedMemoryWriter.WriteLine(memoryValue);

        lastMemoryValue = memoryValue;
    }

    public static void OverallConsumedByThisMethod()
    {
        var memoryDifference = lastMemoryValue - firstMemoryValue;
        //AllocatedMemoryWriter.WriteLine("Difference between first and latest: " + FS.GetSizeInAutoString(memoryDifference, ComputerSizeUnits.B));
    }
}