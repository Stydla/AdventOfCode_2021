﻿using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_09
{
  public class Program : BaseAdventSolver, IAdventSolver
  {

    public override string SolverName => "Day 9: Smoke Basin"/*TODO: Task Name*/;

    public override string InputsFolderName => "SolverAOC2021_09";

    public override string SolveTask1(string InputData)
    {
      Data d = new Data(InputData);
      int res = d.Solve1();
      return res.ToString();
      
    }

    public override string SolveTask2(string InputData)
    {
      Data d = new Data(InputData);
      int res = d.Solve2();
      return res.ToString();
    }
  }
}
