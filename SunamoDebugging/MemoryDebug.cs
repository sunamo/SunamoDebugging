namespace SunamoDebugging;

/// <summary>
/// Provides debugging utilities for tracking memory allocation over time.
/// </summary>
public class MemoryDebug
{
    /// <summary>
    /// Gets or sets the StreamWriter used to log memory values to a file.
    /// </summary>
    public static StreamWriter? AllocatedMemoryWriter { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the MemoryDebug class has been initialized.
    /// </summary>
    public static bool Initialized { get; set; }

    private static long firstMemoryValue;
    private static long lastMemoryValue;

    /// <summary>
    /// Initializes the memory debug logging system by creating a log file in the specified directory.
    /// </summary>
    /// <param name="directoryPath">The directory path where the AllocatedMemory.txt log file will be created.</param>
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
    /// Writes a memory value to the log file and updates internal tracking.
    /// </summary>
    /// <param name="memoryValue">The memory value in bytes to log.</param>
    public static void WriteLine(long memoryValue)
    {
        if (firstMemoryValue == 0) firstMemoryValue = memoryValue;
        AllocatedMemoryWriter?.WriteLine(memoryValue);

        lastMemoryValue = memoryValue;
    }

    /// <summary>
    /// Calculates the overall memory consumed between the first and last recorded memory values.
    /// This method is intended for debugging purposes to track memory consumption in a method.
    /// </summary>
    /// <returns>The difference in bytes between the last and first memory values.</returns>
    public static long OverallConsumedByThisMethod()
    {
        var memoryDifference = lastMemoryValue - firstMemoryValue;
        return memoryDifference;
    }
}