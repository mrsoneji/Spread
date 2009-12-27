
using System;

namespace Spread
{
	
	
	public class ActorObject: GameObject, RenderInterface
	{
		
		public ActorObject()
		{
		}
		
		public void Render(Graphics g)
		{
			Console.WriteLine(@"Render Called");
            g.Render(this);
		}

        public void LoadImage(string file)
        {
        }
	}
}
