using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolverAOC2021_24.Instructions
{
  public class Inp : Instr, IInstruction
  {

    private ALU Alu;
    private int VariableIndex;

    public Inp(string input, ALU alu) : base(input)
    {
      char c = input.Last();
      VariableIndex = alu.GetVariableIndex(c);
      Alu = alu;
    }

    public void Execute()
    {
      Alu.Variables[VariableIndex] = Alu.ReadInput();
    }
  }
}
