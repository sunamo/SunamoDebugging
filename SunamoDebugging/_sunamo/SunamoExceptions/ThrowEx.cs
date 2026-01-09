// variables names: ok
namespace SunamoDebugging._sunamo.SunamoExceptions;

/// <summary>
/// Internal helper class for throwing exceptions with automatic context information.
/// </summary>
internal partial class ThrowEx
{
    /// <summary>
    /// Throws a "Not implemented method" exception with automatic context information.
    /// </summary>
    /// <returns>Always returns true after throwing the exception.</returns>
    internal static bool NotImplementedMethod() { return ThrowIsNotNull(Exceptions.NotImplementedMethod); }

    #region Other
    /// <summary>
    /// Gets the full name of the currently executing code (type.method).
    /// </summary>
    /// <returns>A string in the format "Namespace.Type.MethodName".</returns>
    internal static string FullNameOfExecutedCode()
    {
        Tuple<string, string, string> placeOfException = Exceptions.PlaceOfException();
        string fullName = FullNameOfExecutedCode(placeOfException.Item1, placeOfException.Item2, true);
        return fullName;
    }

    /// <summary>
    /// Constructs the full name of executing code from type and method information.
    /// </summary>
    /// <param name="type">The type object (can be Type, MethodBase, string, or any object).</param>
    /// <param name="methodName">The method name (if null, will be determined from stack trace).</param>
    /// <param name="isFromThrowEx">If true, adjusts the stack frame depth for calls from ThrowEx methods.</param>
    /// <returns>A string in the format "Namespace.Type.MethodName".</returns>
    static string FullNameOfExecutedCode(object type, string methodName, bool isFromThrowEx = false)
    {
        if (methodName == null)
        {
            int depth = 2;
            if (isFromThrowEx)
            {
                depth++;
            }

            methodName = Exceptions.CallingMethod(depth);
        }
        string typeFullName;
        if (type is Type typeInstance)
        {
            typeFullName = typeInstance.FullName ?? "Type cannot be get via type is Type typeInstance";
        }
        else if (type is MethodBase method)
        {
            typeFullName = method.ReflectedType?.FullName ?? "Type cannot be get via type is MethodBase method";
            methodName = method.Name;
        }
        else if (type is string)
        {
            typeFullName = type.ToString() ?? "Type cannot be get via type is string";
        }
        else
        {
            Type actualType = type.GetType();
            typeFullName = actualType.FullName ?? "Type cannot be get via type.GetType()";
        }
        return string.Concat(typeFullName, ".", methodName);
    }

    /// <summary>
    /// Throws an exception if the exception message is not null.
    /// </summary>
    /// <param name="exception">The exception message to throw (null means no exception).</param>
    /// <param name="isReallyThrow">If true, actually throws the exception; if false, only breaks in debugger.</param>
    /// <returns>True if an exception message was provided, false otherwise.</returns>
    internal static bool ThrowIsNotNull(string? exception, bool isReallyThrow = true)
    {
        if (exception != null)
        {
            Debugger.Break();
            if (isReallyThrow)
            {
                throw new Exception(exception);
            }
            return true;
        }
        return false;
    }

    #region For avoid FullNameOfExecutedCode
    /// <summary>
    /// Throws an exception created by the factory function, automatically providing context information.
    /// </summary>
    /// <param name="exceptionFactory">A function that takes the full name of executing code and returns an exception message.</param>
    /// <returns>Always returns true after throwing the exception.</returns>
    internal static bool ThrowIsNotNull(Func<string, string?> exceptionFactory)
    {
        string? exception = exceptionFactory(FullNameOfExecutedCode());
        return ThrowIsNotNull(exception);
    }

    /// <summary>
    /// Throws a custom exception with automatic context information.
    /// </summary>
    /// <param name="message">The primary exception message.</param>
    /// <param name="isReallyThrow">If true, actually throws the exception; if false, only breaks in debugger.</param>
    /// <param name="secondMessage">An optional secondary message to append.</param>
    /// <returns>True if the exception was thrown, false otherwise.</returns>
    internal static bool Custom(string message, bool isReallyThrow = true, string secondMessage = "")
    {
        string joined = string.Join(" ", message, secondMessage);
        string? exceptionMessage = Exceptions.Custom(FullNameOfExecutedCode(), joined);
        return ThrowIsNotNull(exceptionMessage, isReallyThrow);
    }
    #endregion
    #endregion
}