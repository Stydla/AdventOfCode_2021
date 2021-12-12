using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_12
{
  internal class Node
  {
    public List<Node> Nodes = new List<Node>();

    public string Name;
    public bool IsBigCave;
    public bool IsStartCave;
    public bool IsEndCave;

    public int state;

    public Node(string name)
    {
      this.Name = name;
      IsBigCave = Name[0] <= 'Z';
      IsStartCave = Name == "start";
      IsEndCave = Name == "end";
    }

    internal void Link(Node n2)
    {
      this.Nodes.Add(n2);
      n2.Nodes.Add(this);
    }

    public int Search(bool visitedTwice)
    {
      if(!IsBigCave && state > 1)
      {
        return 0;
      }
      if(!IsBigCave && state > 0 && visitedTwice)
      {
        return 0;
      }
      if(IsEndCave)
      {
        return 1;
      }
      if(IsStartCave && state > 0)
      {
        return 0;
      }
      
      state++;

      visitedTwice = visitedTwice || (state == 2 && !IsBigCave);

      int res = 0;
      foreach(Node n in Nodes)
      {
        res += n.Search(visitedTwice);
      }
      state--;

      return res;
    }
  }
}
