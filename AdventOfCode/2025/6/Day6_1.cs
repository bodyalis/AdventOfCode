using System.Numerics;
using System.Text;

namespace AdventOfCode._2025._6;

public static class Day_6_2
{
    public class Task
    {
        public List<BigInteger> Numbers = new ();
        public Func<BigInteger, BigInteger, BigInteger> Operation;
        public char OperationChar;
    }

    public class Solution
    {
        private List<Task> tasks = new List<Task>();
        private string[] rows;

        public Solution(string fileName)
        {
            rows = File.ReadLines(fileName).ToArray();
        }

        public BigInteger Solve()
        {
            Task currentTask = null;
            int rowsLength = rows.Length;
            StringBuilder currentNumbers = new StringBuilder();
            for (int i = 0; i < rows[0].Length; i++)
            {

                currentNumbers = currentNumbers.Clear();
                for (int j = 0; j < rowsLength - 1; j++)
                {
                    char c = rows[j][i];
                    if (c != ' ')
                    {
                        currentNumbers.Append(c);
                    }
                }

                if (currentNumbers.Length == 0)
                {
                    currentTask = null;
                    continue;
                }

                if (currentTask is null)
                {
                    char operation = rows[rowsLength - 1][i];

                    currentTask = new Task();
                    currentTask.Operation = operation switch
                    {
                        '+' => (a, b) => a + b,
                        '*' => (a, b) => a * b,
                    };
                    currentTask.OperationChar = operation;
                    tasks.Add(currentTask);
                }

                currentTask.Numbers.Add(BigInteger.Parse(currentNumbers.ToString()));

            }

            BigInteger val = 0;

            foreach (var task in tasks)
            {
                BigInteger currentVal = task.OperationChar == '+' ? 0 : 1;

                foreach (var number in task.Numbers)
                {
                    currentVal = task.Operation(currentVal, number);
                }

                val += currentVal;
            }

            return val;


        }
    }
}
