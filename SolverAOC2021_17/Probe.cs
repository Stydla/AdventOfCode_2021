using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverAOC2021_17
{
  class Probe
  {
    public Velocity InitialVelocity;
    public Velocity Velocity;
    public Coords Coords;

    public int MaxY = int.MinValue;

    public Probe(Coords coords, Velocity velocity)
    {
      Coords = coords;
      Velocity = velocity;
      InitialVelocity = new Velocity(velocity.X, velocity.Y);
    }

    public void Move()
    {
      Coords.X += Velocity.X;
      Coords.Y += Velocity.Y;

      Velocity.X = Math.Max(Velocity.X - 1, 0);
      Velocity.Y--;

      if(Coords.Y > MaxY)
      {
        MaxY = Coords.Y;
      }
    }
  }
}
