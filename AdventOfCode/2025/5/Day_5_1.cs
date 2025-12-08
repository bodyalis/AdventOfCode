namespace AdventOfCode._2025._5;

public class Day_5_1
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
        
    }
    public class Solution
    {
        private readonly long[] _ids;
        private Range[] _unionRanges;
        private Range[] ranges;
        private BinaryRangeTree _tree;
        
        public Solution(string filename)
        {
            string text = File.ReadAllText(filename);
            
            string[] parts = text.Split("\r\n\r\n");
           ranges = parts[0].Split("\r\n").Select(Range.Parse).OrderBy(r => r.Min).ToArray();
            _ids = parts[1].Split("\r\n").Select(long.Parse).ToArray();
            
        }
        
        public int Solve()
        {
            List<Range> unionRanges = new List<Range>(ranges.Length);
            
            Range unionRange = new ();
            unionRange.Min = ranges[0].Min;
            unionRange.Max = ranges[0].Max;
            for (int index = 1; index < ranges.Length; index++)
            {
                Range range = ranges[index];

                if (range.Min > unionRange.Max)
                {
                    unionRanges.Add(unionRange);
                    unionRange = new Range(range.Min, range.Max);
                }
                
                unionRange.Max = Math.Max(unionRange.Max, range.Max);
            }
            
            unionRanges.Add(unionRange);

            _unionRanges = unionRanges.ToArray();
            _tree = BinaryRangeTree.BuildFromSorted(_unionRanges);
            
            return _ids.Count(id => _tree.Query(id));
        }
    }

    public class BinaryRangeNode
    {
        public Range Range;
        public BinaryRangeNode Left;
        public BinaryRangeNode Right;
        
        public BinaryRangeNode(Range range)
        {
            Range = range;
        }

        public bool Query(long id)
        {
            if (id < Range.Min)
            {
                return Left?.Query(id) ?? false;
            }

            if (id > Range.Max)
            {
                return Right?.Query(id) ?? false;
            }

            return true;
        }
    }

    public class BinaryRangeTree
    {
        private BinaryRangeNode Root;

        public bool Query(long id)
        {
            return Root.Query(id);
        }

        private BinaryRangeTree()
        {
                
        }
        
        public static BinaryRangeTree BuildFromSorted(Range[] ranges)
        {
            BinaryRangeTree tree = new BinaryRangeTree();
            tree.Root = BuildRecursive(ranges, 0, ranges.Length - 1);
            return tree;
        }

        private static BinaryRangeNode BuildRecursive(Range[] ranges, int start, int end)
        {
            if (start > end) return null;
            
            int mid =  (start + end) / 2;
            BinaryRangeNode node = new BinaryRangeNode(ranges[mid]);
            
            node.Left = BuildRecursive(ranges, start, mid - 1);
            node.Right = BuildRecursive(ranges, mid + 1, end);

            return node;
        }
    }
}
