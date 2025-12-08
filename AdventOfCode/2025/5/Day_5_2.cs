namespace AdventOfCode._2025._5;

public class Day_5_2
{
    public struct Range
    {
        public  long Min;
        public  long Max;
        
        public Range(long min, long max) => (Min, Max) = (min, max);

        public Range()
        {
        }

        public static Range Parse(string range)
        {
            string[] parts = range.Split("-");
            return new Range(long.Parse(parts[0]), long.Parse(parts[1]));
        }
        
        public long  Length => Max - Min + 1;
        
    }
    public class Solution
    {
        private readonly long[] _ids;
        private Range[] _unionRanges;
        private Range[] ranges;
        
        public Solution(string filename)
        {
            string text = File.ReadAllText(filename);
            
            string[] parts = text.Split("\r\n\r\n");
           ranges = parts[0].Split("\r\n").Select(Range.Parse).OrderBy(r => r.Min).ToArray();
            
        }
        
        public long Solve()
        {
            long cnt = 0;
            Range unionRange = new ();
            unionRange.Min = ranges[0].Min;
            unionRange.Max = ranges[0].Max;
            for (int index = 1; index < ranges.Length; index++)
            {
                Range range = ranges[index];

                if (range.Min > unionRange.Max)
                {
                    cnt += unionRange.Length;
                    unionRange = new Range(range.Min, range.Max);
                }
                
                unionRange.Max = Math.Max(unionRange.Max, range.Max);
            }
            
            cnt += unionRange.Length;

            return cnt;
        }
    }

   
}
