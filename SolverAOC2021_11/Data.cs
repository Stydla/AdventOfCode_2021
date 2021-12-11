using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_11
{
  internal class Data
  {

    public List<List<int>> Energies;
    public int FlashCount = 0;

    public Data(string input)
    {
      int borderValue = 666;
      using (StringReader sr = new StringReader(input))
      {
        
        Energies = new List<List<int>>();
        string line;
        while((line = sr.ReadLine()) != null)
        {
          List<int> tmp = new List<int>();
          tmp.Add(borderValue);
          foreach (char c in line)
          {
            tmp.Add(int.Parse(c.ToString()));
          }
          tmp.Add(borderValue);
          Energies.Add(tmp);
        }
      }

      Energies.Insert(0, new List<int>());
      Energies.Add(new List<int>());
      for (int i = 0; i < 12; i++)
      {
        Energies[0].Add(borderValue);
        Energies[11].Add(borderValue);
      }
    }

    internal int Solve2()
    {
      int tmpFlash = 0;
      int round = 0;
      while(true)
      {
        round++;
        SimulateNext();
        if(FlashCount - tmpFlash == 100)
        {
          break;
        } else
        {
          tmpFlash = FlashCount;
        }
      }
      return round;
    }

    public int Solve1()
    {
      for(int i = 0; i < 100; i++)
      {
        Print();
        SimulateNext();
      }
      return FlashCount;
    }

    private void SimulateNext()
    {

      IncreaseAll();

      int flashCount;
      while((flashCount = Flash()) > 0)
      {
        FlashCount += flashCount;
      }

      for (int i = 1; i < 11; i++)
      {
        for (int j = 1; j < 11; j++)
        {
          if (Energies[i][j] == -1)
          {
            Energies[i][j] = 0;
          }
        }
      }
    }

    private void Print()
    {
      for (int i = 1; i < 11; i++)
      {
        for (int j = 1; j < 11; j++)
        {
          Console.Write(Energies[i][j]);
        }
        Console.WriteLine();
      }
      Console.WriteLine();
    }

    private int Flash()
    {
      int flashCount = 0; 
      for (int i = 1; i < 11; i++)
      {
        for(int j = 1; j < 11; j++)
        {
          if(Energies[i][j] == 10)
          {
            Energies[i][j] = -1;
            flashCount++;
            for(int a = i - 1; a <= i+1; a++)
            {
              for(int b = j - 1; b <= j+1; b++)
              {
                if(!(a== i && b==j))
                {
                  if(Energies[a][b] != -1 && Energies[a][b] != 10) 
                  {
                    Energies[a][b]++;
                  }
                  
                }
              }
            }
          }
        }
      }
      return flashCount;
    }

    private void IncreaseAll()
    {
      for(int i = 0; i < Energies.Count; i++)
      {
        for(int j = 0; j < Energies[i].Count; j++)
        {
          Energies[i][j]++;
        }
      }
    }


  }
}
