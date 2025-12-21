namespace SunamoDebugging.System.Text;

public abstract  class DebugStringBuilderAbstract<T>
    {
    #region Ctor
    //public abstract StringBuilder();
    //public abstract StringBuilder(int capacity);
    //public abstract StringBuilder(string value);
    //public abstract StringBuilder(string value, int capacity);
    //public abstract StringBuilder(int capacity, int maxCapacity);
    //public abstract StringBuilder(string value, int startIndex, int length, int capacity); 
    #endregion

    #region Properties and indexer
    //public abstract char this[int index] { get; set; }

    //public abstract int MaxCapacity { get; }
    //public abstract int Length { get; set; }
    //public abstract int Capacity { get; set; } 
    #endregion

    #region Append
    public abstract T Append(string value);
    //public abstract T Append(double value);
    //public abstract T Append(char[] value);
    //public abstract T Append(object value);
    //public abstract T Append(ulong value);
    //public abstract T Append(uint value);
    //public abstract T Append(ushort value);
    //public abstract T Append(decimal value);
    //public abstract T Append(float value);
    //public abstract T Append(int value);
    //public abstract T Append(short value);
    //public abstract T Append(char value);
    //public abstract T Append(long value);
    //public abstract T Append(sbyte value);
    //public abstract T Append(byte value);
    //public abstract T Append(char[] value, int startIndex, int charCount);
    //public abstract T Append(string value, int startIndex, int count);
    //public abstract T Append(char value, int repeatCount);
    ////public abstract StringBuilder Append(char* value, int valueCount);
    //public abstract T Append(bool value); 
    #endregion
    #region AppendFormat
    //public abstract T AppendFormat(IFormatProvider provider, string format, params object[] args);
    //public abstract T AppendFormat(string format, object arg0, object arg1, object arg2);
    //public abstract T AppendFormat(string format, params object[] args);
    //public abstract T AppendFormat(IFormatProvider provider, string format, object arg0);
    //public abstract T AppendFormat(IFormatProvider provider, string format, object arg0, object arg1);
    //public abstract T AppendFormat(IFormatProvider provider, string format, object arg0, object arg1, object arg2);
    //public abstract T AppendFormat(string format, object arg0);
    //public abstract T AppendFormat(string format, object arg0, object arg1); 
    #endregion

    public abstract T AppendLine();
        public abstract T AppendLine(string value);
        public abstract T Clear();
    //public abstract void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count);
    //public abstract int EnsureCapacity(int capacity);
    //public abstract bool Equals(StringBuilder sb);

    #region Insert
    //public abstract T Insert(int index, object value);
    //public abstract T Insert(int index, byte value);
    //public abstract T Insert(int index, ulong value);
    //public abstract T Insert(int index, uint value);
    //public abstract T Insert(int index, string value);
    //public abstract T Insert(int index, decimal value);
    //public abstract T Insert(int index, string value, int count);
    //public abstract T Insert(int index, bool value);
    //public abstract T Insert(int index, ushort value);
    //public abstract T Insert(int index, short value);
    //public abstract T Insert(int index, char value);
    //public abstract T Insert(int index, sbyte value);
    //public abstract T Insert(int index, char[] value, int startIndex, int charCount);
    //public abstract T Insert(int index, int value);
    //public abstract T Insert(int index, long value);
    //public abstract T Insert(int index, float value);
    //public abstract T Insert(int index, double value);
    //public abstract T Insert(int index, char[] value);
    #endregion
    #region Remove
    //public abstract T Remove(int startIndex, int length); 
    #endregion
    #region Replace
    //public abstract T Replace(string oldValue, string newValue);
    //public abstract T Replace(string oldValue, string newValue, int startIndex, int count);
    //public abstract T Replace(char oldChar, char newChar);
    //public abstract T Replace(char oldChar, char newChar, int startIndex, int count); 
    #endregion
    #region ToString
    //public abstract string ToString(int startIndex, int length);
    public abstract override string ToString(); 
    #endregion
}