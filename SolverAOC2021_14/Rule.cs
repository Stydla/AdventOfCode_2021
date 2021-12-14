using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SolverAOC2021_14
{
  internal class Rule
  {

    public string In, Out;

    public List<Dictionary<Rule, long>> RulesInStep = new List<Dictionary<Rule, long>>();

    public Rule(string line)
    {
      Match m = Regex.Match(line, @"([A-Z]*) -> ([A-Z]*)");
      In = m.Groups[1].Value;
      Out = m.Groups[2].Value;

    }

    public Dictionary<char, long> GetChars(int step)
    {
      Dictionary<char, long> res = new Dictionary<char, long>();
      foreach(var r in RulesInStep[step])
      {
        char key = r.Key.In[0];
        if(!res.ContainsKey(key)) 
        {
          res.Add(key, r.Value);
        } else
        {
          res[key] += r.Value;
        }
        char key2 = r.Key.Out[0];
        if (!res.ContainsKey(key2))
        {
          res.Add(key2, r.Value);
        }
        else
        {
          res[key2] += r.Value;
        }
      }
      //res[In[1]]++;

      return res;
    }

    public void Init(List<Rule> rules)
    {
      RulesInStep.Add(new Dictionary<Rule, long>());
      RulesInStep[0].Add(this, 1);
        
      RulesInStep.Add(new Dictionary<Rule, long>());
      Rule r = rules.First(x => x.In[0] == In[0] && x.In[1] == Out[0]);
      RulesInStep[1].Add(r, 1);

      Rule r2 = rules.First(x => x.In[0] == Out[0] && x.In[1] == In[1]);
      RulesInStep[1].Add(r2, 1);
    }

    internal void SolveNext(List<Rule> rules)
    {
      int current = RulesInStep.Count - 1;
      RulesInStep.Add(new Dictionary<Rule, long>());

      Dictionary<Rule, long> currentRules = RulesInStep[current]; 
      foreach(var currentRule in currentRules)
      {
        foreach(var ruleDict in currentRule.Key.RulesInStep[1])
        {
          if(!RulesInStep[current+1].ContainsKey(ruleDict.Key))
          {
            RulesInStep[current + 1].Add(ruleDict.Key, ruleDict.Value * currentRule.Value);
          } else
          {
            RulesInStep[current + 1][ruleDict.Key] += (ruleDict.Value * currentRule.Value);
          }
        }
      }
    }

  }
}