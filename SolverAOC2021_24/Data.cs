using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_24
{
  class Data
  {

    List<string> InstructionStrings = new List<string>();

    public Data(string input)
    {
      using (StringReader sr = new StringReader(input))
      {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
          InstructionStrings.Add(line);
        }
      }
    }

    internal long Solve1()
    {
      var results = GetResults();
      return results.Max();
    }

    internal long Solve2()
    {
      var results = GetResults();
      return results.Min();
    }

    private List<long> GetResults()
    {
      ALU alu = new ALU(InstructionStrings);



      Dictionary<DataItem, DataItem> items = new Dictionary<DataItem, DataItem>();

      DataItem diInitial = new DataItem(0, 0, 0, 0, 0, 0, null);
      items.Add(diInitial, diInitial);

      for (int i = 1; i <= 14; i++)
      {

        var currentItems = items.Where(x => x.Key.Level == i - 1 && x.Key.Z < 1000000).ToList();
        List<IInstruction> instructionForExecute = alu.Instructions.Skip((i - 1) * 18).Take(18).ToList();

        for (int w = 1; w <= 9; w++)
        {

          foreach (var currentItem in currentItems)
          {


            alu.ClearVariables();
            alu.LoadInput(w);

            alu.Variables[alu.GetVariableIndex('w')] = currentItem.Value.W;
            alu.Variables[alu.GetVariableIndex('x')] = currentItem.Value.X;
            alu.Variables[alu.GetVariableIndex('y')] = currentItem.Value.Y;
            alu.Variables[alu.GetVariableIndex('z')] = currentItem.Value.Z;

            foreach (IInstruction instr in instructionForExecute)
            {
              instr.Execute();
            }

            int iw = alu.Variables[alu.GetVariableIndex('w')];
            int ix = alu.Variables[alu.GetVariableIndex('x')];
            int iy = alu.Variables[alu.GetVariableIndex('y')];
            int iz = alu.Variables[alu.GetVariableIndex('z')];
            DataItem di = new DataItem(iw, ix, iy, iz, i, w, currentItem.Value);

            if (items.ContainsKey(di))
            {
              items[di].Add(w, currentItem.Value);
            }
            else
            {
              items.Add(di, di);
            }
          }


        }
      }

      var resultItems = items.Where(x => x.Value.Level == 14 && x.Value.Z == 0).ToList();
      List<long> resultNumbers = new List<long>();
      foreach (DataItem di in resultItems.Select(x => x.Key))
      {
        List<long> numbers = di.GetResults();
        resultNumbers.AddRange(numbers);
      }
      return resultNumbers;
    }


    public class DataItem
    {


      public int W, X, Y, Z;
      public int Level;
      public List<int> Digits = new List<int>();

      public List<DataItem> Parents = new List<DataItem>();
      public List<DataItem> Childs = new List<DataItem>();

      public DataItem(int w, int x, int y, int z, int level, int digit, DataItem parent)
      {
        W = w;
        X = x;
        Y = y;
        Z = z;
        Level = level;
        Digits.Add(digit);
        Parents.Add(parent);
        if(parent != null)
        {
          parent.Childs.Add(this);
        }
        
      }

      public void Add(int digit, DataItem parent)
      {
        Digits.Add(digit);
        Parents.Add(parent);
        if (parent != null)
        {
          parent.Childs.Add(this);
        }
      }

      public override bool Equals(object obj)
      {
        if(obj is DataItem di)
        {
          return
            Y == di.Y &&
            Z == di.Z &&
            Level == di.Level
            ;

        }
        return false;
      }

      public override int GetHashCode()
      {
        int hash = 0;
        hash = Y;
        hash = hash * 29 + Z;
        hash = hash * 29 + Level;
        return hash;
      }

      internal List<long> GetResults()
      {
        List<long> res = new List<long>();
        for(int i = 0; i < Digits.Count; i++)
        {
          if(Parents[i] == null)
          {
            res.Add(Digits[i]);
            continue;
          }
          foreach(long tmp in Parents[i].GetResults())
          {
            res.Add(tmp * 10 + Digits[i]);
          }
        }
        return res;
      }
    }


  }
  
}
