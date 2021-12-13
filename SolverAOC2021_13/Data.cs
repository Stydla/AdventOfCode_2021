using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_13
{
  class Data
  {

    public List<Dot> Dots;
    public List<Fold> Folds;

    public Data(string input)
    {

      using (StringReader sr = new StringReader(input))
      {
        int state = 0;
        Dots = new List<Dot>();
        Folds = new List<Fold>();

        string line;
        while ((line = sr.ReadLine()) != null)
        {
          if (string.IsNullOrWhiteSpace(line))
          {
            state++;
            continue;
          }

          switch (state)
          {
            case 0:
              {
                Dots.Add(new Dot(line));
                break;
              }
            case 1:
              {
                Folds.Add(new Fold(line));
                break;
              }
            default:
              throw new Exception("Invalid inpput state");
          }


        }
      }

    }

    internal string Solve2()
    {
      StartFold(Folds.Count);

      return Print();
    }

    public string Print()
    {
      List<List<char>> arr = new List<List<char>>();
      for(int i = 0; i < Dots.Max(x=>x.Y) + 1; i++)
      {
        arr.Add(new List<char>());
        for(int j = 0; j < Dots.Max(x=>x.X) + 1; j++)
        {
          arr[i].Add('░');
        }
      }

      foreach(Dot d in Dots)
      {
        arr[d.Y][d.X] = '█';
      }

      StringBuilder sb = new StringBuilder();

      for (int i = 0; i < arr.Count; i++)
      {
        for (int j = 0; j < arr[i].Count; j++)
        {
          sb.Append(arr[i][j]);
        }
        sb.AppendLine();
      }
      return sb.ToString();
    }

    internal int Solve1()
    {
      StartFold(1);
      
      return Dots.Count;
    }

    private void StartFold(int count)
    {
      for (int i = 0; i < count; i++)
      {
        Fold(Folds[i]);
      }
    }

    private void Fold(Fold f)
    {
      List<Dot> DotsForFold;
      List<Dot> DotsForDelete;
      if(f.FoldType == FoldType.AlongX)
      {
        DotsForFold = Dots.Where(x => x.X > f.value).ToList();
        DotsForFold.ForEach(x => x.X = 2 * f.value - x.X);
        DotsForDelete = Dots.Where(x => x.X == f.value).ToList();
      } else
      {
        DotsForFold = Dots.Where(x => x.Y > f.value).ToList();
        DotsForFold.ForEach(x => x.Y = 2 * f.value - x.Y);
        DotsForDelete = Dots.Where(x => x.Y == f.value).ToList();
      }

      foreach(Dot d in DotsForDelete)
      {
        Dots.Remove(d);
      }

      Dots = Dots.Distinct().ToList();

    }

  }
}
