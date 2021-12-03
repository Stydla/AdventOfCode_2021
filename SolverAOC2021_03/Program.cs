using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_03
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 3: Binary Diagnostic"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2021_03";

    public override string SolveTask1(string InputData)
    {
      List<string> numbers = new List<string>();
      using (StringReader sr = new StringReader(InputData))
      {
        string line;
        while((line = sr.ReadLine()) != null)
        {
          numbers.Add(line);
        }
      }

      StringBuilder gamma = new StringBuilder();
      StringBuilder epsilon = new StringBuilder();


      for(int i = 0; i < numbers[0].Length; i++)
      {
        int sum0 = numbers.Sum(x => x[i] == '0' ? 1 : 0);
        int sum1 = numbers.Sum(x => x[i] == '1' ? 1 : 0);

        if(sum1 > sum0)
        {
          gamma.Append('1');
          epsilon.Append('0');
        } else
        {
          gamma.Append('0');
          epsilon.Append('1');
        }
      }

      return $"{Convert.ToInt32(gamma.ToString(), 2) * Convert.ToInt32(epsilon.ToString(), 2)}";

    }





    public override string SolveTask2(string InputData)
    {
      List<string> numbers = new List<string>();
      using (StringReader sr = new StringReader(InputData))
      {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
          numbers.Add(line);
        }
      }

      StringBuilder gamma = new StringBuilder();
      StringBuilder epsilon = new StringBuilder();

      List<string> lifeSupport = new List<string>(numbers);
      List<string> scrubber = new List<string>(numbers);

      int lifeSupportRes = 0;
      int scrubberRes = 0;

      for (int i = 0; i < numbers[0].Length; i++)
      {

        lifeSupport = GetSignificants(lifeSupport, '1', i);
        scrubber = GetSignificants(scrubber, '0', i);

        if(lifeSupport.Count == 1)
        {
          lifeSupportRes = Convert.ToInt32(lifeSupport[0], 2);
        }

        if (scrubber.Count == 1)
        {
          scrubberRes = Convert.ToInt32(scrubber[0], 2);
        }
      }


      return $"{lifeSupportRes * scrubberRes}";
    }

    private List<string> GetSignificants(List<string> source, char val, int index)
    {
      int sum1 = source.Sum(x => x[index] == '1' ? 1 : 0);
      int sum0 = source.Sum(x => x[index] == '0' ? 1 : 0);

      if (val == '1')
      {
        if(sum1 >= sum0)
        {
          return source.Where(x => x[index] == '1').ToList();
        } else
        {
          return source.Where(x => x[index] == '0').ToList();
        }
      } else
      {
        if (sum0 <= sum1)
        {
          return source.Where(x => x[index] == '0').ToList();
        }
        else
        {
          return source.Where(x => x[index] == '1').ToList();
        }
      }
    

    } 
  }
}
