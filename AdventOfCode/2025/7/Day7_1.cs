namespace AdventOfCode._2025._7;

public static class Day_7_1
{
    public class Solution
    {
        private readonly char[][] _matrix;

        public Solution(string filePath)
        {
            _matrix = File.ReadAllLines(filePath).Select(x => x.ToCharArray()).ToArray();
        }

        public int Solve()
        {
            int startX = Array.IndexOf(_matrix[0], 'S');
            Queue<Position> queue = new();
            queue.Enqueue(new Position(startX, 0).Bottom); 

            int splits = 0;
            while (queue.Count > 0)
            {
                Position pos = queue.Dequeue();
                if (!ValidPosition(pos) || _matrix[pos.Y][pos.X] == '|') continue;

                char cell = _matrix[pos.Y][pos.X];
                if (cell == '^')
                {
                    splits++;  
                    queue.Enqueue(pos.Left);   
                    queue.Enqueue(pos.Right);
                }
                else 
                {
                    _matrix[pos.Y][pos.X] = '|';
                    queue.Enqueue(pos.Bottom); 
                }
            }
            return splits;
        }


        private bool ValidPosition(Position position) => position.X >= 0 && position.Y >= 0 && position.X < _matrix[0].Length && position.Y < _matrix.Length;
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

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
