using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SolverAOC2021_24.Instructions
{
  public class Add : Instr, IInstruction
  {

    private ALU Alu;
    
    private int TargetVariableIndex;
    private int SourceVariableIndex;
    private int Value;

    public Add(string input, ALU alu) : base(input)
    {
      Alu = alu;

      Match m = Regex.Match(input, @"add ([wxyz]) ([wxyz]|[-]?\d*)");

      char target = char.Parse(m.Groups[1].Value);
      TargetVariableIndex = alu.GetVariableIndex(target);

      string source = m.Groups[2].Value;
      if(int.TryParse(source, out Value))
      {
        SourceVariableIndex = -1;
      } else
      {
        SourceVariableIndex = alu.GetVariableIndex(char.Parse(source));
      }
    }

    public void Execute()
    {
      if(SourceVariableIndex  == -1)
      {
        Alu.Variables[TargetVariableIndex] += Value;
      } else
      {
        Alu.Variables[TargetVariableIndex] += Alu.Variables[SourceVariableIndex];
      }
    }
  }
}
