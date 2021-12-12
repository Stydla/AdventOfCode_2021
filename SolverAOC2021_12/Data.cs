using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_12
{
  internal class Data
  {

    public List<Node> AllNodes;

    public Data(string input)
    {
      AllNodes = new List<Node>();
      using(StringReader sr = new StringReader(input))
      {
        string line;
        while((line = sr.ReadLine()) != null)
        {
          string[] arr = line.Split('-');
          Node n1 = GetNode(arr[0]);
          Node n2 = GetNode(arr[1]);
          n1.Link(n2);
        }
      }
    }

    internal int Solve1()
    {
      Node startCave = AllNodes.First(x => x.IsStartCave);
      int res = startCave.Search(true);
      return res;
    }

    internal int Solve2()
    {
      Node startCave = AllNodes.First(x => x.IsStartCave);
      int res = startCave.Search(false);
      return res;
    }

    private Node GetNode(string name)
    {
      Node n = AllNodes.FirstOrDefault(x => x.Name == name);
      if (n != null)
      {
        return n;
      }  
      n = new Node(name);
      AllNodes.Add(n);
      return n;
    }
  }
}
