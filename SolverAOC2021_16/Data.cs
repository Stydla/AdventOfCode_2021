using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_16
{
  class Data
  {
    string Input;
    string BinaryInput;

    public Packet StartPacket;
    
    public Data(string inputData)
    {
      Input = inputData;
      BinaryInput = String.Join(String.Empty, Input.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
      int pos = 0;
      StartPacket = new Packet(BinaryInput, ref pos);
    }


    internal int Solve1()
    {
      int sumVersions = StartPacket.GetSumVersions();
      return sumVersions;
    }

    internal long Solve2()
    {
      long res = StartPacket.Solve();
      return res;
    }
  }
}
