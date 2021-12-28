using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_24
{
  public class ALU
  {

    public List<int> Variables = new List<int>() { 0, 0, 0, 0 };
    public List<IInstruction> Instructions = new List<IInstruction>();

    public List<int> Inputs = new List<int>();
    private int CurrentInputIndex;

    public ALU(List<string> instructionStrings)
    {
      
      foreach(string instructionString in instructionStrings)
      {
        IInstruction instr = InstructionFactory.CreateInstruction(instructionString, this);
        Instructions.Add(instr);
      }
    }

    internal void Execute()
    {
      //Console.WriteLine(this);
      //Console.WriteLine("----------------------------------------------------------------------");
      foreach(IInstruction instr in Instructions)
      {
        //Console.WriteLine(this);
        //Console.WriteLine(instr);
        instr.Execute();
        //Console.WriteLine(this);
        //Console.WriteLine("----------------------------------------------------------------------");
      }
    }

    public override string ToString()
    {
      const int size = -12;
      return $"w={Variables[0],size} x={Variables[1],size} y={Variables[2],size} z={Variables[3],size}";
    }

    internal int GetResult()
    {
      int index = GetVariableIndex('z');
      return Variables[index];
    }

    internal void LoadInput(long v)
    {
      Inputs = GetIntList(v);
      CurrentInputIndex = 0;
    }

    public void ClearVariables()
    {
      for(int i = 0; i < Variables.Count; i++)
      {
        Variables[i] = 0;
      }
    }

    private List<int> GetIntList(long num)
    {
      List<int> listOfInts = new List<int>();
      while (num > 0)
      {
        listOfInts.Add((int)(num % 10));
        num = num / 10;
      }
      listOfInts.Reverse();
      return listOfInts;
    }

    public int GetVariableIndex(char variable)
    {
      switch(variable)
      {
        case 'w':
          return 0;
        case 'x':          
          return 1;
        case 'y':
          return 2;
        case 'z':
          return 3;
        default:
          throw new Exception($"Variable not found {variable}");
      }
    }

    public int ReadInput()
    {
      if(CurrentInputIndex >= Inputs.Count)
      {
        throw new Exception($"No data in input - {CurrentInputIndex}");
      }
      return Inputs[CurrentInputIndex++];
    }



  }
}
