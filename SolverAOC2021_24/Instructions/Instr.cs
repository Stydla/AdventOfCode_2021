using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_24.Instructions
{
  public abstract class Instr
  {
    string InputString;

    public Instr(string input)
    {
      InputString = input;
    }

    public override string ToString()
    {
      return InputString;
    }
  }
}
