namespace AdventOfCode._2025._4._2;

public static class Day_4_2
{
    public struct Position
    {
        public int X;
        public int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position Top => new Position(X, Y - 1);
        public Position Left => new Position(X - 1, Y);
        public Position Right => new Position(X + 1, Y);
        public Position Bottom => new Position(X, Y + 1);
        public Position TopLeft => new Position(X - 1, Y - 1);
        public Position TopRight => new Position(X + 1, Y - 1);
        public Position BottomLeft => new Position(X - 1, Y + 1);
        public Position BottomRight => new Position(X + 1, Y + 1);

        public Position[] Neighbors => new[] { Top, Left, Right, Bottom, TopLeft, TopRight, BottomLeft, BottomRight };

        public static Position operator +(Position p1, Position p2) => new (p1.X + p2.X, p1.Y + p2.Y);
    }

    public class Optimizer
    {
        private const char paper = '@';
        private const char deletablePaper1 = 'X';
        private const char deletablePaper2 = 'P';
        private const char empty = '.';
        private char currentDeletablePaper = deletablePaper1;
        private char prevDeletablePaper= deletablePaper2;


        private readonly char[,] _matrix;

        public Optimizer(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            _matrix = new char[lines.Length, lines[0].Length];

            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    _matrix[y, x] = lines[y][x];
                }
            }
        }


        public int Optimize()
        {
            int sum = 0;
            int i = 0;
            do
            {
                i = OptimizeInternal();
                sum += i;
            } while (i > 0);

            return sum;
        }

        private int OptimizeInternal()
        {
            (prevDeletablePaper, currentDeletablePaper) = (currentDeletablePaper, prevDeletablePaper);
            
            int cnt = 0;
            for (int y = 0; y < _matrix.GetLength(0); y++)
            {
                for (int x = 0; x < _matrix.GetLength(1); x++)
                {
                    if (_matrix[y, x] == empty)
                    {
                        continue;
                    }

                    if (_matrix[y, x] == prevDeletablePaper)
                    {
                        _matrix[y, x] = empty;
                        continue;
                    }

                    Position pos = new Position(x, y);

                    int localCnt = 0;
                    foreach (Position neighbor in pos.Neighbors)
                    {
                        if (neighbor.X >= 0 && neighbor.X < _matrix.GetLength(1) && neighbor.Y >= 0 && neighbor.Y < _matrix.GetLength(0))
                        {
                            if (IsPaper(neighbor))
                            {
                                localCnt++;
                            }
                        }

                    }

                    if (localCnt < 4)
                    {
                        _matrix[y, x] = currentDeletablePaper;
                        cnt++;
                    }
                }
            }
            return cnt;
        }

        private bool IsPaper(Position neighbor) => _matrix[neighbor.Y, neighbor.X] == paper || _matrix[neighbor.Y, neighbor.X] == currentDeletablePaper;
    }
}
