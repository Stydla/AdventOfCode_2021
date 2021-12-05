using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolverAOC2021_05
{
  internal class Line
  {

    public Point p1;
    public Point p2;

    public Line(string input)
    {
      //0,9 -> 5,9
      Match m = Regex.Match(input, @"(\d+),(\d+) -> (\d+),(\d+)");

      int a1 = int.Parse(m.Groups[1].Value);
      int a2 = int.Parse(m.Groups[2].Value);
      int b1 = int.Parse(m.Groups[3].Value);
      int b2 = int.Parse(m.Groups[4].Value);

      p1 = new Point(a1, a2);
      p2 = new Point(b1, b2);

    }

    public bool IsVerticalOrHorizontal()
    {
      return p1.X == p2.X || p1.Y == p2.Y;
    }

    //public List<Point> GetLinePoints()
    //{
    //  List<Point> points = new List<Point>();

    //  int dx = Math.Abs(p1.X - p2.X);
    //  int dy = Math.Abs(p1.Y - p2.Y);

    //  int xMin = Math.Min(p1.X, p2.X);
    //  int yMin = Math.Min(p1.Y, p2.Y);

    //  for (int i = 0; i <= dx; i++)
    //  {
    //    for (int j = 0; j <= dy; j++)
    //    {
    //      points.Add(new Point(xMin + i, yMin + j));
    //    }

    //  }


    //  return points;
    //}

    public List<Point> GetLinePoints()
    {
      List<Point> points = new List<Point>();

      int dx = Math.Abs(p1.X - p2.X);
      int dy = Math.Abs(p1.Y - p2.Y);

      int xMin = Math.Min(p1.X, p2.X);
      int yMin = Math.Min(p1.Y, p2.Y);

      

      if(dx > 0 && dy > 0)
      {
        for (int i = 0; i <= dx; i++)
        {
          int nextX;
          int nextY;
          nextX = p1.X < p2.X ? p1.X + i : p1.X - i;
          nextY = p1.Y < p2.Y ? p1.Y + i : p1.Y - i;

          points.Add(new Point(nextX, nextY));
        }
      } else if (dx > 0)
      {
        for (int i = 0; i <= dx; i++)
        {
          points.Add(new Point(xMin + i, yMin));
        }
      } else if (dy > 0)
      {
        for (int i = 0; i <= dy; i++)
        {
          points.Add(new Point(xMin, yMin + i));
        }
      }

      return points;
    }

  }
}
