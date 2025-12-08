namespace AdventOfCode._2025._7;

public static class Day_7_2
{
    public class Solution
    {
        private readonly char[][] _matrix;
        private int rows => _matrix.Length;
        private int cols => _matrix[0].Length;
        private Dictionary<Position, long> cache;
        
        public Solution(string filePath)
        {
            _matrix = File.ReadAllLines(filePath).Select(x => x.ToCharArray()).ToArray();
        }

        public long Solve()
        {
            int startX = Array.IndexOf(_matrix[0], 'S');
            
            Position startPosition = new Position(startX, 0);
            
            cache = new Dictionary<Position, long>();

            long paths = CalculatePaths(startPosition);

            return paths;
        }

        private long CalculatePaths(Position pos)
        {
            if (pos.Y >= rows)
            {
                // Console.WriteLine($"{pos.Y}, {pos.X}");
                return 1;

            }
            
            char cell = _matrix[pos.Y][pos.X];
            
            // Console.WriteLine($"{pos.Y}, {pos.X}; {cell}");

            if (cache.TryGetValue(pos, out long result))
            {
                return result;
            }

            long paths = 0;
            
            if (cell == '^')
            {
                if (Validate(pos.LeftBottom))
                {
                    paths += CalculatePaths(pos.LeftBottom);
                }

                if (Validate(pos.RightBottom))
                {
                    paths += CalculatePaths(pos.RightBottom);
                }
            }
            else
            {
                paths = CalculatePaths(pos.Bottom);
            }
            
            cache[pos] = paths;
            return paths;
        }

        private bool Validate(Position position) => position.X >= 0 && position.Y >= 0 && position.X < _matrix[0].Length && position.Y < _matrix.Length;
    }

    public struct Position
    {
        public int X, Y;
        public Position(int x, int y) => (X, Y) = (x, y);

        public Position Left => new Position(X - 1, Y);
        public Position Right => new Position(X + 1, Y);
        public Position LeftBottom => new Position(X - 1, Y + 1);
        public Position RightBottom => new Position(X + 1, Y + 1);
        public Position Bottom => new Position(X, Y + 1);
        public Position Top => new Position(X, Y - 1);
        
        public override string ToString() => $"({X}, {Y})";
    }
}