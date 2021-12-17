using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_15
{
  class Data
  {

    public List<List<Field>> RiskLevelsMap = new List<List<Field>>();
    public List<Field> RiskLevelsMapAll = new List<Field>();

    public int Width, Height;


    public Data(string input)
    {
      using(StringReader sr = new StringReader(input))
      {
        string line;
        while((line = sr.ReadLine()) != null)
        {
          RiskLevelsMap.Add(new List<Field>());
          foreach(char c in line)
          {
            int riskLevel = int.Parse(c.ToString());
            int y = RiskLevelsMap.Count - 1;
            int x = RiskLevelsMap[y].Count;
            
            Field f = new Field(x, y, riskLevel, RiskLevelsMap);
            RiskLevelsMap[y].Add(f);
            RiskLevelsMapAll.Add(f);
          }
        }
      }

      Height = RiskLevelsMap.Count;
      Width = RiskLevelsMap[0].Count;

    }

    internal int Solve2()
    {
      for(int i = 0; i < Height; i++)
      {
        for(int v = 1; v < 5; v++)
        {
          for(int j = 0; j < Width; j++)
          {
            Field tmp = new Field((Width * v) + j, i, (RiskLevelsMap[i][j].RiskLevel + v - 1) % 9 + 1, RiskLevelsMap);
            RiskLevelsMap[i].Add(tmp);
            RiskLevelsMapAll.Add(tmp);
          }
        }
      }

      Width = RiskLevelsMap[0].Count;
      
      
      for (int v = 1; v < 5; v++)
      {
        for (int i = 0; i < Height; i++)
        {
          List<Field> tmpList = new List<Field>();
          for (int j = 0; j < Width; j++)
          {
            Field tmp = new Field(j, i + (v * Height), (RiskLevelsMap[i][j].RiskLevel + v-1) % 9 + 1, RiskLevelsMap);

            RiskLevelsMapAll.Add(tmp);
            tmpList.Add(tmp);
          }
          RiskLevelsMap.Add(tmpList);
        } 
        
      }

      Height = RiskLevelsMap.Count;


      return Solve1();
    }

    public int Solve1()
    {
      RiskLevelsMap[Height - 1][Width - 1].Init();

      List<Field> changed = new List<Field>();
      changed.Add(RiskLevelsMap[Height - 1][Width - 1]);
      List<Field> forSolve = GetFieldsForSolve(changed);
      
      while (forSolve.Count > 0)
      {
        List<Field> forNext = new List<Field>();
        foreach(Field f in forSolve)
        {
          forNext.AddRange(f.Solve(RiskLevelsMap));
        }
        
        forSolve = GetFieldsForSolve(forNext);
      }
      return RiskLevelsMap[0][0].TotalRiskLevel - RiskLevelsMap[0][0].RiskLevel;
    }

    public void PrintMap()
    {
      for (int i = 0; i < Height; i++)
      {
        for (int j = 0; j < Width; j++)
        {
          Console.Write($"{RiskLevelsMap[i][j].RiskLevel,1}");
        }
        Console.WriteLine();
      }
      Console.WriteLine();
    }

    public void PrintRiskLevel()
    {
      for (int i = 0; i < Height; i++)
      {
        for (int j = 0; j < Width;j++)
        {
          Console.Write($"{RiskLevelsMap[i][j].TotalRiskLevel,4}");
        }
        Console.WriteLine();
      }
      Console.WriteLine();
    }
    private List<Field> GetFieldsForSolve(List<Field> changedList)
    {
      List<Field> res = new List<Field>();
      foreach (Field f in changedList)
      {
        f.State = EState.Closed;
        res.AddRange(f.Neighbours);
      }
      return res.Distinct().ToList();
    }

    //private List<Field> GetFieldsForSolve()
    //{
    //  List<Field> res = new List<Field>();
    //  foreach(Field f in RiskLevelsMapAll.Where(x => x.State == EState.Changed))
    //  {
    //    f.State = EState.Closed;
    //    res.AddRange(f.GetNeighbours(RiskLevelsMap));
    //  }
    //  return res.Distinct().ToList();
    //}
       

  }
}
