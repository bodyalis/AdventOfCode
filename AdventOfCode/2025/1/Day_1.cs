namespace AdventOfCode._2025._1;

public class Day_1
{
    public class PasswordDecoder
    {
        private int _currentPosition = 50;
        private int _countOfCountZeroCrossing = 0;
        private string[] _commands;
        const int CountOfPositions = 100;

        public PasswordDecoder(string fileName)
        {
            FillCommands(fileName);
        }

        private void FillCommands(string fileName)
        {
            _commands = File.ReadAllLines(fileName);
        }

        public int Decode()
        {
            foreach (var command in _commands)
            {
                Rotate(command);
                Console.WriteLine($"Command: {command}; Current Position: {_currentPosition} ; Count of Zero Crossing: {_countOfCountZeroCrossing}");
            }
            
            return _countOfCountZeroCrossing;
        }

        private void Move(int pos)
        {
            if (pos == 0)
            {
                return;
            }

            int counfOfZeroCrossing = 0;
            
            if (pos > 0)
            {
                int sumOfPos = _currentPosition + pos;

                _currentPosition = sumOfPos % CountOfPositions;
                
                counfOfZeroCrossing = sumOfPos / CountOfPositions;
                
            }
            else
            { 
                int sumOfPos = _currentPosition + pos;
                
                if (sumOfPos < 0)
                {
                    counfOfZeroCrossing = Math.Abs(sumOfPos / CountOfPositions);
                    if (_currentPosition > 0)
                    {
                        counfOfZeroCrossing++;
                    }
                    _currentPosition = sumOfPos % CountOfPositions;
                    
                    
                    if (_currentPosition < 0)
                    {
                        _currentPosition += CountOfPositions;
                    }


                }
                else  
                {
                    _currentPosition = sumOfPos;
                }
                
            }
            
            if (_currentPosition == 0)
            {
                _countOfCountZeroCrossing++;
                counfOfZeroCrossing--;
            }
            
            if ( counfOfZeroCrossing > 0)
            {
                _countOfCountZeroCrossing += counfOfZeroCrossing;
            }

        }

        private void Rotate(string command)
        {
            int movePos = int.Parse(command.Substring(1).Trim());
            if (command.StartsWith('L'))
            {
                movePos *= -1;
            }
            Move(movePos);
        }
    }
}
