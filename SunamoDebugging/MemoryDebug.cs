namespace SunamoDebugging;

/// <summary>
/// Represents the memory debug type.
/// </summary>
public class MemoryDebug
{
    /// <summary>
    /// Gets or sets the allocated memory writer.
    /// </summary>
    public static StreamWriter? AllocatedMemoryWriter { get; set; }

    /// <summary>
    /// Gets or sets the initialized.
    /// </summary>
    public static bool Initialized { get; set; }

    private static long firstMemoryValue;
    private static long lastMemoryValue;

    /// <summary>
    /// Init.
    /// </summary>
    /// <param name="directoryPath">The directory path.</param>
    /// <returns>The init result.</returns>
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

    /// <summary>
    /// Initializes a new instance of the write line class.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="string.Empty">The string empty.</param>
    public static void WriteLine(long memoryValue)
    {
        if (firstMemoryValue == 0) firstMemoryValue = memoryValue;
        AllocatedMemoryWriter?.WriteLine(memoryValue);

        lastMemoryValue = memoryValue;
    }

    /// <summary>
    /// Initializes a new instance of the overall consumed by this method class.
    /// </summary>
    /// <param name="firstMemoryValue">The first memory value.</param>
    public static long OverallConsumedByThisMethod()
    {
        var memoryDifference = lastMemoryValue - firstMemoryValue;
        return memoryDifference;
    }
}
