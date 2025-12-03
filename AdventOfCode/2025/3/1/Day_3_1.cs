namespace AdventOfCode._2025._3._1;

public static class Day_3_1
{
    public class VoltageExecutor
    {
        private readonly string[] _rows;
        public VoltageExecutor(string filePath)
        {
            _rows = File.ReadAllLines(filePath);
        }

        public IEnumerable<int> Execute()
        {
            foreach (string row in _rows)
            {
                ReadOnlySpan<char> firstRange = row.AsSpan().Slice(0, row.Length - 1); 
                (char firstMax, int firstPos) = GetMaxInRange(firstRange);
                
                ReadOnlySpan<char> secondRange = row.AsSpan().Slice( firstPos+ 1, row.Length - firstPos - 1);
                (char secondMax, int secondPos) = GetMaxInRange(secondRange);
                
                string result = firstMax.ToString() + secondMax.ToString();
                yield return int.Parse(result);
            }
        }

        public (char, int pos) GetMaxInRange(ReadOnlySpan<char> range)
        {
            char max = '0';
            int pos = 0;
            
            for (int index = 0; index < range.Length; index++)
            {
                char c = range[index];
                if (c > max)
                {
                    max = c;
                    pos = index;
                }

                if (c == '9') break;
            }

            return (max, pos);
        }
    }
}
