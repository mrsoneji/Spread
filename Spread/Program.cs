using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spread
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();
            ActorObject ao = new ActorObject();
            g.GameObjects.Add(ao);
            g.Run();
        }
    }
}
