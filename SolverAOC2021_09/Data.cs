using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_09
{
  class Data
  {

    List<List<int>> Input;

    List<List<bool>> Basin;

    public Data(string input)
    {

      using(StringReader sr = new StringReader(input))
      {
        Input = new List<List<int>>();

        string line;
        while((line = sr.ReadLine()) != null)
        {
          List<int> tmp = new List<int>();

          tmp.Add(9);
          foreach(char c in line)
          {
            tmp.Add(int.Parse(c.ToString()));
          }
          tmp.Add(9);
          Input.Add(tmp);
        }
        Input.Add(new List<int>());
        Input.Insert(0, new List<int>());

        for(int i = 0; i < Input[1].Count; i++)
        {
          Input[0].Add(9);
          Input[Input.Count-1].Add(9);
        }
      }
    }

    public int Solve1()
    {

      List<Coords> lowPoints = FindLowPoints();

      return lowPoints.Sum(x => Input[x.I][x.J] + 1);

    }

    private void InitBasins()
    {
      Basin = new List<List<bool>>();
      for (int i = 0; i < Input.Count; i++)
      {
        Basin.Add(new List<bool>());
        for (int j = 0; j < Input[i].Count; j++)
        {
          Basin[i].Add(Input[i][j] == 9);
        }
      }
      
    }

    private class Coords
    {
      public int I, J;
    }

    private List<Coords> FindLowPoints()
    {
      List<Coords> res = new List<Coords>();
      for (int i = 1; i < Input.Count - 1; i++)
      {
        for (int j = 1; j < Input[i].Count; j++)
        {
          int val = Input[i][j];
          if (
            val < Input[i - 1][j] &&
            val < Input[i + 1][j] &&
            val < Input[i][j - 1] &&
            val < Input[i][j + 1])
          {
            res.Add(new Coords() { I = i, J = j });
          }
        }
      }
      return res;
    }



    public int Solve2()
    {
      InitBasins();

      List<Coords> lowPoints = FindLowPoints();

      
      List<int> results = new List<int>();
      foreach(Coords c in lowPoints)
      {
        results.Add(SolveRec(c.I, c.J));
      }

      results.Sort();
      results.Reverse();

      return results.Take(3).Aggregate((x,y)=> x * y);

    }


    private int SolveRec(int i, int j)
    {
      if (Basin[i][j]) return 0 ;

      Basin[i][j] = true;

      int res = 1;

      res += SolveRec(i + 1, j);
      res += SolveRec(i - 1, j);
      res += SolveRec(i, j - 1);
      res += SolveRec(i, j + 1);

      return res;
    }

  }
}
