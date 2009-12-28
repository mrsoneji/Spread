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
            TableObject ao = new TableObject();
            g.GameObjects.Add(ao);
            g.Run();
        }
    }
}
