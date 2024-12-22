using System.Collections;
using System.IO;

StreamReader sr = new StreamReader("input.txt");

var a = new ArrayList();
var b = new ArrayList();

while (!sr.EndOfStream)
{
    string[] line = sr.ReadLine().Split(' ');
    if (line.Length != 4)
    {
        break;
    }
    a.Add(line[0]);
    b.Add(line[3]);
}

a.Sort();
b.Sort();
long sum = 0;
for (int i = 0; i < a.Count; i++)
{
    sum += Math.Abs(int.Parse(a[i].ToString()) - int.Parse(b[i].ToString()));
}

Console.WriteLine(sum);