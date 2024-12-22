using System.Collections;
using System.IO;

StreamReader sr = new StreamReader("../../../NewFile1.txt");

int cnt = 0;

outer:
while (!sr.EndOfStream)
{
    int[] line = sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
    bool dir = line[1] - line[0] > 0;
    int life = 1;
    int prev = line[0];
    int fails = 0;
    for (int i = 1; i < line.Length; i++)
    {
        if (line[i] - prev > 0 != dir || (Math.Abs(line[i] - prev) - 1) * (Math.Abs(line[i] - prev) - 3) > 0)
        {
            if (i == 2)
            {
                dir = line[2] - line[0] > 0;
            }
            if (life == 0)
            {
                fails++;
                break;
            }
            life--;
        }
        else
        {
            prev = line[i];
        }
    }

    if (fails == 0)
    {
        cnt++;
        continue;
    }

    dir = line[2] - line[1] > 0;
    prev = line[1];
    for (int i = 2; i < line.Length; i++)
    {
        if (line[i] - prev > 0 != dir || (Math.Abs(line[i] - prev) - 1) * (Math.Abs(line[i] - prev) - 3) > 0)
        {
            fails++;
            break;
        }
        prev = line[i];
    }
    if (fails == 1)
    {
        cnt++;
    }
}
Console.WriteLine(cnt);