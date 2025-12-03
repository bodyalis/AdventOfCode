namespace AdventOfCode._2025._2._1;

public static class Day_2_1
{
    struct Range
    {
        public string Min;
        public string Max;
        
    }
    public class InvalidIdsChecker
    {
        private List<Range> ranges;
        private List<long>? ids;

        public InvalidIdsChecker(string filePath)
        {
            SetRanges(filePath);
        }

        private void SetRanges(string filePath)
        {
            string line = File.ReadAllText(filePath);
            string[] stringRanges = line.Split(',');
            ranges = new List<Range>(stringRanges.Length);
            foreach (string range in stringRanges)
            {
                string[] minMax = range.Split('-');
                ranges.Add(new Range { Min = minMax[0], Max = minMax[1] });
            }
        }

        public IEnumerable<long> GetInvalidIds()
        {
            if (ids is not null)
            {
                return ids;
            }
            
            ids = new List<long>();

            foreach (Range range in ranges)
            {
                long minInt = long.Parse(range.Min);
                long maxInt = long.Parse(range.Max);

                long currentId = minInt;
                while (currentId <= maxInt)
                {
                    if (!IsValid(currentId))
                    {
                        ids.Add(currentId);
                    }
                    
                    currentId++;
                }
            }
            
            return ids;
        }

        private bool IsValid(long id)
        {
            string idString = id.ToString();
            if ((idString.Length & 1) == 1)
            {
                return true;
            }

            long div = (long) (Math.Pow(10, idString.Length / 2));
            long part1 = id / div ;
            long part2 = id % div;
            
            return part1 != part2;
        }
    }
}
