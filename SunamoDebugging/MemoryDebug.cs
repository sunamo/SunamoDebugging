namespace SunamoDebugging;

public class MemoryDebug
{
    public static StreamWriter? AllocatedMemoryWriter { get; set; }

    public static bool Initialized { get; set; }

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
        AllocatedMemoryWriter?.WriteLine(memoryValue);

        lastMemoryValue = memoryValue;
    }

    public static long OverallConsumedByThisMethod()
    {
        var memoryDifference = lastMemoryValue - firstMemoryValue;
        return memoryDifference;
    }
}
