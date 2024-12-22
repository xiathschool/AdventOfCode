using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

StreamReader sr = new StreamReader("../../../NewFile1.txt");

long cnt = 0;
string line = sr.ReadToEnd();
string[] rows = line.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

int numRows = rows.Length;
int numCols = rows[0].Length;

int[,] array = new int[numRows, numCols];
int[] xmas = new[] { (int)'X', (int)'M', (int)'A', (int)'S' };

for (int i = 0; i < numRows; i++)
{
    for (int j = 0; j < numCols; j++)
    {
        array[i, j] = rows[i][j];
    }
}

for (int i = 0; i < numRows; i++)
{
    for (int j = 0; j < numCols; j++)
    {
        if (array[i, j] != xmas[2])
        {
            continue;
        }
        int[] dr = new[] { -1, -1, 1, 1, -1, -1, 1, 1 };
        int[] dc = new[] { -1, 1, 1, -1, -1, 1, 1, -1 };
        
        bool found = true;
        for (int k = 0; k < 2; k++)
        {
            int nr1 = i + dr[k];
            int nc1 = j + dc[k];
            
            int nr2 = i + dr[k + 2];
            int nc2 = j + dc[k + 2];

            bool inBounds = nr1 >= 0 && nr1 < numRows &&
                            nr2 >= 0 && nr2 < numRows &&
                            nc1 >= 0 && nc1 < numCols &&
                            nc2 >= 0 && nc2 < numCols;
            
            if (!inBounds || (!(array[nr1, nc1] == 'M' && array[nr2, nc2] == 'S') && !(array[nr1, nc1] == 'S' && array[nr2, nc2] == 'M')))
            {
                found = false;
                break;
            }
        }

        if (found)
        {
            cnt++;
        }
    }
}


Console.WriteLine(cnt);