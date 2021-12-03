using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolverAOC2021_02
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 2: Dive!"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2021_02";

    public override string SolveTask1(string InputData)
    {
      using(StringReader sr = new StringReader(InputData))
      {
        int depth = 0;
        int distance = 0;
        string line;
        while((line = sr.ReadLine()) != null)
        {
          Match m = Regex.Match(line, @"([a-z]*) (\d*)");
          string command = m.Groups[1].Value;
          int value = int.Parse(m.Groups[2].Value);

          switch(command)
          {
            case "forward":
              {
                distance += value;
                break;
              }
            case "up":
              {
                depth -= value;
                break;
              }
            case "down":
              {
                depth += value;
                break;
              }
            default:
              throw new Exception($"Command not found {command}");
          }
        }
        return $"{depth * distance}";
      }
    }



    public override string SolveTask2(string InputData)
    {
      using (StringReader sr = new StringReader(InputData))
      {
        int depth = 0;
        int distance = 0;
        int aim = 0;
        string line;
        while ((line = sr.ReadLine()) != null)
        {
          Match m = Regex.Match(line, @"([a-z]*) (\d*)");
          string command = m.Groups[1].Value;
          int value = int.Parse(m.Groups[2].Value);

          switch (command)
          {
            case "forward":
              {
                depth = depth + (aim * value);
                distance += value;
                
                break;
              }
            case "up":
              {
                //depth -= value;
                aim -= value;
                break;
              }
            case "down":
              {
                aim += value;
                //depth += value;
                break;
              }
            default:
              throw new Exception($"Command not found {command}");
          }
        }
        return $"{depth * distance}";
      }
    }
  }
}
