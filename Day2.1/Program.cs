using System.Collections;
using System.IO;

StreamReader sr = new StreamReader("../../../NewFile1.txt");

int cnt = 0;

outer:
while (!sr.EndOfStream)
{
    int[] line = sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    bool dir = line[1] - line[0] > 0;
    for (int i = 1; i < line.Length; i++)
    {
        if (line[i] - line[i - 1] > 0 != dir || (Math.Abs(line[i] - line[i - 1]) - 1) * (Math.Abs(line[i] - line[i - 1]) - 3) > 0)
        {
            goto outer;
        }
    }

    cnt++;
}
Console.WriteLine(cnt);