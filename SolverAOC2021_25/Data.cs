using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_25
{
  public class Data
  {


    public List<List<Field>> Fields = new List<List<Field>>();

    public List<Cucumber> Cucumbers = new List<Cucumber>();

    public Data(string input)
    {
      using(StringReader sr = new StringReader(input))
      {
        string line;
        while((line = sr.ReadLine()) != null)
        {
          Fields.Add(new List<Field>());

          for(int i = 0; i < line.Length; i++)
          {
            char c = line[i];
            Field f = new Field(i, Fields.Count - 1);
            Fields[Fields.Count - 1].Add(f);
            if(c != '.')
            {
              Cucumber cuc = new Cucumber(c, f);
              f.Cucumber = cuc;
              Cucumbers.Add(cuc);
            }
          }
        }
      }

      for(int i = 0; i < Fields.Count; i++)
      {
        for(int j = 0; j < Fields[i].Count; j++)
        {
          Field fTmp = Fields[i][j];

          int rightIndex = (j + 1) % Fields[i].Count;
          int leftIndex = (j - 1 + Fields[i].Count) % Fields[i].Count;
          int upIndex = (i - 1 + Fields.Count) % Fields.Count;
          int downIndex = (i + 1) % Fields.Count;

          fTmp.SetNeighbour(EDirection.RIGHT, Fields[i][rightIndex]);
          fTmp.SetNeighbour(EDirection.LEFT, Fields[i][leftIndex]);
          fTmp.SetNeighbour(EDirection.UP, Fields[upIndex][j]);
          fTmp.SetNeighbour(EDirection.DOWN, Fields[downIndex][j]);
        }
      }
    }


    public int Solve1()
    {
      int step = 0;

      //Console.WriteLine(Print());

      while(true)
      {
        step++;

        List<Cucumber> cucForMove = Cucumbers.Where(x => x.CanMove()).ToList();

        if(cucForMove.Count == 0)
        {
          break;
        }

        foreach(Cucumber c in cucForMove.Where(x=>x.Type == ECucumberType.East))
        {
          c.Move();
        }
        foreach (Cucumber c in cucForMove.Where(x => x.Type == ECucumberType.South))
        {
          c.Move();
        }

        //Console.WriteLine(Print());
      }

      return step;
    }


    public string Print()
    {
      StringBuilder sb = new StringBuilder();
      foreach(var l in Fields)
      {
        foreach(Field f in l)
        {
          sb.Append(f.Print());
        }
        sb.AppendLine();
      }
      sb.AppendLine();
      return sb.ToString();

    }



  }
}
