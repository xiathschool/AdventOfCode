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
        if (array[i, j] != xmas[0])
        {
            continue;
        }
        int[] dr = new[] { -1, -1, 0, 1, 1, 1, 0, -1 };
        int[] dc = new[] { 0, 1, 1, 1, 0, -1, -1, -1 };
        
        for (int k = 0; k < dr.Length; k++)
        {
            bool found = true;
            int nr = i + dr[k];
            int nc = j + dc[k];
            for (int l = 1; l < xmas.Length; l++)
            {
                if (nr >= 0 && nr < numRows && nc >= 0 && nc < numCols && array[nr, nc] == xmas[l])
                {
                    nr += dr[k];
                    nc += dc[k];
                }
                else
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
}


Console.WriteLine(cnt);