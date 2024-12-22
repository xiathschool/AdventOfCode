using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

StreamReader sr = new StreamReader("../../../NewFile1.txt");

long sum = 0;

while (!sr.EndOfStream)
{
    string line = sr.ReadLine();
    string reg = @"mul\((\d+),(\d+)\)";

    foreach (Match match in Regex.Matches(line, reg))
    {
        sum += long.Parse(match.Groups[1].Value) * long.Parse(match.Groups[2].Value);
    }
}

Console.WriteLine(sum);