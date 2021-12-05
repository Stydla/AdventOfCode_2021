using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_04
{
  internal class InputData
  {

    public List<int> InputNumbers = new List<int>();
    public List<Bingo> Bingos = new List<Bingo>();

    public InputData(string input)
    {
      using(StringReader sr = new StringReader(input))
      {
        string firstLine = sr.ReadLine();

        InputNumbers.AddRange(firstLine.Split(',').Select(x=>int.Parse(x)));

        string line;
        while((line = sr.ReadLine()) != null)
        {
          Bingo b = new Bingo(sr, 5);
          Bingos.Add(b);
        }
      }

    }

    internal object Solve1()
    {
      for (int i = 5; i < InputNumbers.Count; i++)
      {

        List<int> testNumbers = InputNumbers.Take(i).ToList();

        for (int j = 0; j < Bingos.Count; j++)
        {
          if (Bingos[j].Test(testNumbers))
          {
            return Bingos[j].GetResult(testNumbers);
          }
        }
      }

      throw new Exception("Not Found");
    }

    internal int Solve2()
    {
      for(int i = 5; i < InputNumbers.Count; i++)
      {

        List<int> testNumbers = InputNumbers.Take(i).ToList();

        for (int j = 0; j < Bingos.Count ; j++) {
          if (Bingos[j].Test(testNumbers))
          {
            Bingos[j].Win = true;
          }
          if(Bingos.All(x=>x.Win))
          {
            return Bingos[j].GetResult(testNumbers);
          }
        }
      }

      throw new Exception("Not Found");

      
    }
  }
}
