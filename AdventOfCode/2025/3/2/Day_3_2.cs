namespace AdventOfCode._2025._3._2;

public static class Day_3_2
{
    public class VoltageExecutor
    {
        private readonly string[] _rows;

        public VoltageExecutor(string filePath)
        {
            _rows = File.ReadAllLines(filePath);
        }

        private const int numOfElementsInBattery = 12;

        public IEnumerable<long> Execute()
        {
            foreach (string row in _rows)
            {
                string result = "";
                int prevPos = -1;

                while (result.Length < numOfElementsInBattery)
                {
                    ReadOnlySpan<char> range = default (ReadOnlySpan<char>)!;
                    
                    int length = row.Length - numOfElementsInBattery + result.Length - prevPos;
                    
                    range = row.AsSpan().Slice(prevPos + 1, length);
                    
                    (char max, int pos) = GetMaxInRange(range);

                    result += max;
                    prevPos = prevPos + 1 + pos;
                }

                yield return long.Parse(result);
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
