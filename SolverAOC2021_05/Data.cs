using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_05
{
  internal class Data
  {

    public List<List<int>> Grid;
    public int Size;

    public List<Line> Lines;


    public Data(string input)
    {
      using(StringReader sr = new StringReader(input))
      {
        Lines = new List<Line>();
        string strLine;
        while((strLine = sr.ReadLine()) != null)
        {
          Line l = new Line(strLine);
          Lines.Add(l);
        }
      }
      Size = Lines.Max(x => Math.Max(Math.Max(x.p1.X, x.p2.X), Math.Max(x.p1.Y, x.p2.Y))) + 1;
      PrepareGrid(Size);
    }

    private void PrepareGrid(int size)
    {
      Grid = new List<List<int>>();
      for(int i = 0; i < size; i++)
      {
        Grid.Add(new List<int>());
        for(int j = 0; j < size; j++)
        {
          Grid[i].Add(0);
        }
      }
    }

    internal string Solve1()
    {

      foreach(Line line in Lines)
      {
        if(line.IsVerticalOrHorizontal())
        {
          DrawLine(line);
        }
      }

      return GetResult().ToString();
    }

    internal string Solve2()
    {

      foreach (Line line in Lines)
      {
        DrawLine(line); 
      }

      return GetResult().ToString();
    }

    private int GetResult()
    {
      int cnt = 0;
      for (int i = 0; i < Size; i++)
      {
        for (int j = 0; j < Size; j++)
        {
          if (Grid[i][j] >= 2)
          {
            cnt++;
          }
        }
      }
      return cnt;
    }

    private void DrawLine(Line l)
    {
      List<Point> points = l.GetLinePoints();

      foreach (Point p in points)
      {
        Grid[p.X][p.Y]++;
      }
    }
  }
}
