using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_21
{
  public class Variants
  {

    public Dictionary<int, Variant> VariantDict = new Dictionary<int, Variant>();

    internal Variant GetOrCreateVariant(Variant v)
    {
      int id = v.GetID();
      if(!VariantDict.ContainsKey(id))
      {
        VariantDict.Add(id, v);
        return v;
      }
      return VariantDict[id];
    }

    public bool Exists(Variant v)
    {
      return VariantDict.ContainsKey(v.GetID());
    }
  }
}
