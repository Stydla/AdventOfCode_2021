using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_14
{
  public class Data
  {

    public string Polymer;
    List<Rule> Rules = new List<Rule>();

    public Data(string input)
    {
      using(StringReader sr = new StringReader(input))
      {
        Polymer = sr.ReadLine();
        sr.ReadLine();

        string line;
        while((line = sr.ReadLine()) != null)
        {
          Rule r = new Rule(line);
          Rules.Add(r);
        }
      }

    }


    public int Solve1()
    {
      for(int i = 0; i < 10; i++)
      {
        ApplyRules();
      }
      var byChars = Polymer.GroupBy(x => x);
      int min = byChars.Min(x => x.Count());
      int max = byChars.Max(x => x.Count());
      return max - min;
    }

    public long Solve2(int step)
    {
      foreach(Rule r in Rules)
      {
        r.Init(Rules);
      }
      for(int i = 0; i < step-1; i++)
      {
        foreach(Rule r in Rules)
        {
          r.SolveNext(Rules);
        }
      }

      Dictionary<char, long> res = new Dictionary<char, long>();
      for (int i = 0; i < Polymer.Count() - 1; i++)
      {
        string input = $"{Polymer[i]}{Polymer[i + 1]}";
        Rule r = Rules.First(x => x.In == input);
        var dictTmp = r.GetChars(step-1);

        foreach(var kv in dictTmp)
        {
          if (!res.ContainsKey(kv.Key))
          {
            res.Add(kv.Key, kv.Value);
          } else
          {
            res[kv.Key] += kv.Value;
          }
        }
      }


      if(!res.ContainsKey(Polymer.Last()))
      {
        res.Add(Polymer.Last(), 1);
      } else
      {
        res[Polymer.Last()] += 1;
      }

      //for (int i = 0; i < Polymer.Count(); i++)
      //{
      //  char key = Polymer[i];
      //  if(!res.ContainsKey(key))
      //  {
      //    res.Add(Polymer[i],1);
      //  } else
      //  {
      //    res[Polymer[i]]++;
      //  }
        
      //}

      long max = res.Max(x => x.Value);
      long min = res.Min(x => x.Value);


      return max - min;
    }

    private void ApplyRules()
    {
      StringBuilder newPolymer = new StringBuilder();
      for(int i = 0; i < Polymer.Count() - 1; i++)
      {
        string input = $"{Polymer[i]}{Polymer[i + 1]}";
        Rule r = Rules.First(x => x.In == input);
        newPolymer.Append(input[0]);
        newPolymer.Append(r.Out);
      }
      newPolymer.Append(Polymer.Last());
      Polymer = newPolymer.ToString();
    }




  }

  
}
