namespace SunamoDebugging._sunamo.SunamoExceptions;

// © www.sunamo.cz. All Rights Reserved.
/// <summary>
/// Internal helper class for building exception messages with context information.
/// </summary>
internal sealed partial class Exceptions
{
    #region Other
    /// <summary>
    /// Formats a prefix string for exception messages by appending ": " if the prefix is not empty.
    /// </summary>
    /// <param name="before">The prefix string to check and format.</param>
    /// <returns>An empty string if the prefix is null or whitespace, otherwise the prefix followed by ": ".</returns>
    internal static string CheckBefore(string before)
    {
        return string.IsNullOrWhiteSpace(before) ? string.Empty : before + ": ";
    }

    /// <summary>
    /// Extracts the location where an exception occurred from the stack trace.
    /// </summary>
    /// <param name="shouldFillFirstTwo">If true, extracts the type and method name from the first non-ThrowEx frame.</param>
    /// <returns>A tuple containing the type name, method name, and full stack trace text.</returns>
    internal static Tuple<string, string, string> PlaceOfException(bool shouldFillFirstTwo = true)
    {
        StackTrace stackTrace = new();
        var stackTraceText = stackTrace.ToString();
        var lines = stackTraceText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        lines.RemoveAt(0);
        var i = 0;
        string type = string.Empty;
        string methodName = string.Empty;
        for (; i < lines.Count; i++)
        {
            var item = lines[i];
            if (shouldFillFirstTwo)
                if (!item.StartsWith("   at ThrowEx"))
                {
                    TypeAndMethodName(item, out type, out methodName);
                    shouldFillFirstTwo = false;
                }
            if (item.StartsWith("at System."))
            {
                lines.Add(string.Empty);
                lines.Add(string.Empty);
                break;
            }
        }
        return new Tuple<string, string, string>(type, methodName, string.Join(Environment.NewLine, lines));
    }

    /// <summary>
    /// Parses a stack trace line to extract the type and method name.
    /// </summary>
    /// <param name="stackTraceLine">A single line from a stack trace.</param>
    /// <param name="type">The extracted type name.</param>
    /// <param name="methodName">The extracted method name.</param>
    internal static void TypeAndMethodName(string stackTraceLine, out string type, out string methodName)
    {
        var trimmedPart = stackTraceLine.Split("at ")[1].Trim();
        var methodPath = trimmedPart.Split("(")[0];
        var parts = methodPath.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        methodName = parts[^1];
        parts.RemoveAt(parts.Count - 1);
        type = string.Join(".", parts);
    }

    /// <summary>
    /// Gets the name of the calling method from the stack trace.
    /// </summary>
    /// <param name="frameIndex">The stack frame index (default is 1 for immediate caller).</param>
    /// <returns>The name of the calling method, or an error message if the method cannot be determined.</returns>
    internal static string CallingMethod(int frameIndex = 1)
    {
        StackTrace stackTrace = new();
        var methodBase = stackTrace.GetFrame(frameIndex)?.GetMethod();
        if (methodBase == null)
        {
            return "Method name cannot be get";
        }
        var methodName = methodBase.Name;
        return methodName;
    }
    #endregion

    #region IsNullOrWhitespace
    /// <summary>
    /// StringBuilder for storing inner additional information in exception messages.
    /// </summary>
    internal readonly static StringBuilder AdditionalInfoInnerStringBuilder = new();

    /// <summary>
    /// StringBuilder for storing additional information in exception messages.
    /// </summary>
    internal readonly static StringBuilder AdditionalInfoStringBuilder = new();
    #endregion

    #region OnlyReturnString
    /// <summary>
    /// Creates a custom exception message with an optional prefix.
    /// </summary>
    /// <param name="before">The prefix to prepend to the message.</param>
    /// <param name="message">The exception message.</param>
    /// <returns>The formatted exception message.</returns>
    internal static string? Custom(string before, string message)
    {
        return CheckBefore(before) + message;
    }

    /// <summary>
    /// Creates a "Not implemented method" exception message with an optional prefix.
    /// </summary>
    /// <param name="before">The prefix to prepend to the message.</param>
    /// <returns>The formatted exception message.</returns>
    internal static string? NotImplementedMethod(string before)
    {
        return CheckBefore(before) + "Not implemented method.";
    }
    #endregion
}