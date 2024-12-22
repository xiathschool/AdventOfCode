using System.Collections;
using System.IO;

StreamReader sr = new StreamReader("../../../test.txt");

var a = new Dictionary<String, int>();
var b = new Dictionary<String, int>();

while (!sr.EndOfStream)
{
    string[] line = sr.ReadLine().Split(' ');
    if (line.Length != 4)
    {
        break;
    }
    a.TryAdd(line[0], 0);
    b.TryAdd(line[3], 0);
    a[line[0]]++;
    b[line[3]]++;
}
long sum = 0;

foreach (KeyValuePair<string,int> keyValuePair in a)
{
    sum += int.Parse(keyValuePair.Key) * keyValuePair.Value * b.GetValueOrDefault(keyValuePair.Key, 0);
}

Console.WriteLine(sum);