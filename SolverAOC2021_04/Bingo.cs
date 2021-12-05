using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_04
{
  internal class Bingo
  {

    public List<List<int>> BoardRows;
    public List<List<int>> BoardColumns;

    public bool Win = false;


    public Bingo(StringReader sr, int size)
    {

      BoardRows = new List<List<int>>();
      for (int i = 0; i < size; i++)
      {
        string line = sr.ReadLine();


        string lineTmp = line;
        while(lineTmp != line.Replace("  ", " "))
        {
          line = line.Replace("  ", " ");
          lineTmp = line;
        }
        line = line.Trim();


        var list = line.Split(' ').Select(x => int.Parse(x)).ToList();
        BoardRows.Add(list); 
      }

      BoardColumns = new List<List<int>>();
      for(int i = 0; i <size; i++)
      {
        BoardColumns.Add(new List<int>());

        for(int j = 0; j < size; j++)
        {
          BoardColumns[i].Add(BoardRows[j][i]);
        }
      }

    }

    internal bool Test(List<int> testNumbers)
    {
      foreach(List<int> col in BoardColumns)
      {
        if(col.Intersect(testNumbers).Count() == 5)
        {
          return true;
        }
      }

      foreach (List<int> row in BoardRows)
      {
        if (row.Intersect(testNumbers).Count() == 5)
        {
          return true;
        }
      }
      
      return false;
    }

    

    internal int GetResult(List<int> testNumbers)
    {
      int sum = BoardRows.Sum(x => x.Sum());

      foreach(List<int> row in BoardRows)
      {
        foreach(int val in row)
        {
          if(testNumbers.Contains(val))
          {
            sum -= val;
          }
        }
      }
      return sum * testNumbers.Last();



    }
  }
}
