using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_01
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 1: Sonar Sweep"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2021_01";

    public override string SolveTask1(string InputData)
    {
      List<int> data = new List<int>();
      using (StringReader sr = new StringReader(InputData))
      {
        
        string line;
        while((line = sr.ReadLine()) != null)
        {
          data.Add(int.Parse(line));
        }
      }
      int res = 0;
      for(int i = 0; i < data.Count - 1; i++)
      {
        if(data[i] < data[i+1])
        {
          res++;
        }
      }
      return res.ToString();
    }

    public override string SolveTask2(string InputData)
    {
      List<int> data = new List<int>();
      using (StringReader sr = new StringReader(InputData))
      {

        string line;
        while ((line = sr.ReadLine()) != null)
        {
          data.Add(int.Parse(line));
        }
      }
      int res = 0;
      for (int i = 0; i < data.Count - 3; i++)
      {
        int sum1 = SlidingWindowRes(data, i);
        int sum2 = SlidingWindowRes(data, i+1);
        if (sum1 <sum2)
        {
          res++;
        }
      }
      return res.ToString();
    }

    private int SlidingWindowRes(List<int> data, int index)
    {
      int sum = 0;
      for(int i = index; i < index + 3; i++)
      {
        sum += data[i];
      }
      return sum;
    }
  }
}
