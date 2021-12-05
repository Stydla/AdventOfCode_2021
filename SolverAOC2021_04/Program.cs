
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_04
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 4: Giant Squid"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2021_04";

    public override string SolveTask1(string InputData)
    {
      InputData id = new InputData(InputData);

      return id.Solve1().ToString();
    }

    public override string SolveTask2(string InputData)
    {
      InputData id = new InputData(InputData);

      return id.Solve2().ToString();
    }
  }
}
