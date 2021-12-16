using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_16
{
  public class Packet
  {

    public int Version;
    public int TypeID;
    public int LengthTypeID;
    public long Value;
    public int SubPacketBitSize;
    public int SubPacketCount;
    public EPacketType PacketType;
    public List<Packet> SubPackets = new List<Packet>();

    public Packet(string input, ref int pos)
    {
      string version = input.Substring(pos, 3);
      pos += 3;
      Version = Convert.ToInt32(version, 2);

      string typeID = input.Substring(pos, 3);
      pos += 3;
      TypeID = Convert.ToInt32(typeID, 2);

      if (TypeID == 4)
      {
        PacketType = EPacketType.Literal;
        ParseLiteral(input, ref pos);
      } else
      {
        PacketType = EPacketType.Operator;
        ParseOperator(input, ref pos);
      }
      
    }

    internal long Solve()
    {
      switch(TypeID)
      {
        case 0:
          {
            return SubPackets.Select(x => x.Solve()).Sum(); 
          }
        case 1:
          {
            return SubPackets.Select(x => x.Solve()).Aggregate((a,b)=>a*b); 
          }
        case 2:
          {
            return SubPackets.Select(x => x.Solve()).Min();
          }
        case 3:
          {
            return SubPackets.Select(x => x.Solve()).Max();
          }
        case 4:
          {
            return Value;
          }
        case 5:
          {
            return SubPackets[0].Solve() > SubPackets[1].Solve() ? 1 : 0;
          }
        case 6:
          {
            return SubPackets[0].Solve() < SubPackets[1].Solve() ? 1 : 0;
          }
        case 7:
          {
            return SubPackets[0].Solve() == SubPackets[1].Solve() ? 1 : 0;
          }
        default:
          throw new Exception($"Invalid TypeID {TypeID}");

      }
    }

    private void ParseLiteral(string input, ref int pos)
    {
      StringBuilder sb = new StringBuilder();

      string part = input.Substring(pos, 5);
      pos += 5;
      while(part[0] != '0')
      {
        sb.Append(part.Substring(1, 4));
        part = input.Substring(pos, 5);
        pos += 5;
      }
      sb.Append(part.Substring(1, 4));
      string value = sb.ToString();
      Value = Convert.ToInt64(value, 2);
    }

    private void ParseOperator(string input, ref int pos)
    {
      string lengthTypeID = input.Substring(pos, 1);
      pos += 1;
      LengthTypeID = Convert.ToInt32(lengthTypeID, 2);

      int len;
      if(LengthTypeID == 0)
      {
        len = 15;

        string subPacketBitSize = input.Substring(pos, len);
        SubPacketBitSize = Convert.ToInt32(subPacketBitSize, 2);
        pos += len;

        int finalSize = pos + SubPacketBitSize;

        while (true)
        {
          Packet p = new Packet(input, ref pos);
          SubPackets.Add(p);
          if (pos == finalSize) break;
        }
      } else
      {
        len = 11;

        string subPacketCount= input.Substring(pos, len);
        SubPacketCount = Convert.ToInt32(subPacketCount, 2);
        pos += len;

        for(int i = 0; i < SubPacketCount; i++)
        {
          Packet p = new Packet(input, ref pos);
          SubPackets.Add(p);
        }
      }
    }

    internal int GetSumVersions()
    {
      int tmpVersion = Version;

      foreach(Packet p in SubPackets)
      {
        tmpVersion += p.GetSumVersions();
      }
      return tmpVersion;
    }
  }

  public enum EPacketType
  {
    Operator,
    Literal
  }

}
