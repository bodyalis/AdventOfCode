// See https://aka.ms/new-console-template for more information

using AdventOfCode._2025._1;
using AdventOfCode._2025._2;
using AdventOfCode._2025._2;
using AdventOfCode._2025._3;
using AdventOfCode._2025._3._1;
using AdventOfCode._2025._3._2;


// var day1 = new Day_1.PasswordDecoder("C:\\Users\\Bogdan.Listopad\\RiderProjects\\AdventOfCode\\AdventOfCode\\2025\\1\\File.txt");
// var decode = day1.Decode();

// var day2 = new Day_2_2.InvalidIdsChecker("C:\\Users\\Bogdan.Listopad\\RiderProjects\\AdventOfCode\\AdventOfCode\\2025\\2\\File.txt");
// var ids = day2.GetInvalidIds();
//
// var sum = ids.Sum();
// Console.WriteLine();

var day3 = new Day_3_2.VoltageExecutor("C:\\Users\\Bogdan.Listopad\\RiderProjects\\AdventOfCode\\AdventOfCode\\2025\\3\\File.txt");
var volages = day3.Execute();
long sum = volages.Sum();

Console.WriteLine(sum);
    