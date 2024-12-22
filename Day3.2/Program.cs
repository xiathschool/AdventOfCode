using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

StreamReader sr = new StreamReader("../../../NewFile1.txt");

long sum = 0;
string large = "do()";
while (!sr.EndOfStream)
{
    large += sr.ReadLine();
}

string line = Strings.StrReverse(large);
string reg = @"\)(\d+),(\d+)\(lum";
string revdont = @"\)\(t'nod";
string revreg = @"\)(\d+),(\d+)\(lum(?=.*?(\)\(od|\)\(t'nod))";

foreach (Match match in Regex.Matches(line, revreg, RegexOptions.Singleline))
{
    if (match.Groups[3].ToString().Equals(")(od")) {
        sum += long.Parse(Strings.StrReverse(match.Groups[1].Value)) * long.Parse(Strings.StrReverse(match.Groups[2].Value));
    }
}

Console.WriteLine(sum);

// 6494415
// 6234972
// 78683433