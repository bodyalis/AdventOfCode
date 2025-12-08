// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using AdventOfCode._2025._1;
using AdventOfCode._2025._2;
using AdventOfCode._2025._2;
using AdventOfCode._2025._3;
using AdventOfCode._2025._3._1;
using AdventOfCode._2025._3._2;
using AdventOfCode._2025._4._1;
using AdventOfCode._2025._4._2;
using AdventOfCode._2025._5;
using AdventOfCode._2025._6;


// var day1 = new Day_1.PasswordDecoder("C:\\Users\\Bogdan.Listopad\\RiderProjects\\AdventOfCode\\AdventOfCode\\2025\\1\\File.txt");
// var decode = day1.Decode();

// var day2 = new Day_2_2.InvalidIdsChecker("C:\\Users\\Bogdan.Listopad\\RiderProjects\\AdventOfCode\\AdventOfCode\\2025\\2\\File.txt");
// var ids = day2.GetInvalidIds();
//
// var sum = ids.Sum();
// Console.WriteLine();

// var day3 = new Day_3_2.VoltageExecutor("C:\\Users\\Bogdan.Listopad\\RiderProjects\\AdventOfCode\\AdventOfCode\\2025\\3\\File.txt");
// var volages = day3.Execute();
// long sum = volages.Sum();

// var day4 = new Day_4_1.Optimizer("C:\\Users\\Bogdan.Listopad\\RiderProjects\\AdventOfCode\\AdventOfCode\\2025\\4\\File.txt");
// // var result = day4.Optimize();
// var day4 = new Day_4_2.Optimizer("C:\\Users\\listo\\Projects\\AdventOfCode\\AdventOfCode\\2025\\4\\File.txt");
// var sw = Stopwatch.StartNew();
// var result = day4.Optimize2();
// sw.Stop();
//
//
// Console.WriteLine(result);
// Console.WriteLine(sw.ElapsedMilliseconds);


// var day5 = new Day_5_2.Solution("C:\\Users\\Bogdan.Listopad\\RiderProjects\\AdventOfCode\\AdventOfCode\\2025\\5\\File.txt");
// var sw = Stopwatch.StartNew();
// long solve = day5.Solve();
// sw.Stop();
// Console.WriteLine(solve);
// Console.WriteLine(sw.ElapsedMilliseconds);

var day6 = new Day_6_2.Solution("C:\\Users\\Bogdan.Listopad\\RiderProjects\\AdventOfCode\\AdventOfCode\\2025\\6\\File.txt");
var sw = Stopwatch.StartNew();
var solve = day6.Solve();
sw.Stop();
Console.WriteLine(sw.ElapsedMilliseconds);
Console.WriteLine(solve);
