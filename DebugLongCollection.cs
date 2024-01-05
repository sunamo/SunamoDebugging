namespace SunamoDebugging;

public class DebugLongCollection : DebugCollection<long>
{
    public new void Add(long l)
    {
        base.Add(l);
#if DEBUG
        if (Count % 100 == 0)
        {
            List<long> l2 = new List<long>();
            for (int i = Count - 1; i >= Count - 100; i--)
            {
                l2.Add(this[i]);
            }

            var s = NH.CalculateMedianAverage(l2);
        }
#endif
    }
}
