using SolverAOC2021_24.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_24
{
  class InstructionFactory
  {

    public static IInstruction CreateInstruction(string input, ALU alu)
    {
      string instrName = input.Substring(0, 3);
      switch(instrName)
      {
        case "inp":
          {
            return new Inp(input, alu);
          }
        case "add":
          {
            return new Add(input, alu);
          }
        case "mul":
          {
            return new Mul(input, alu);
          }
        case "div":
          {
            return new Div(input, alu);
          }
        case "mod":
          {
            return new Mod(input, alu);
          }
        case "eql":
          {
            return new Eql(input, alu);
          }
        default:
          throw new Exception($"Instruction not found {instrName} - {input}");
      }
    }
  }
}
