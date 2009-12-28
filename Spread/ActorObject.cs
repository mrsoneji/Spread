
using System;

namespace Spread
{
	
	
	public class ActorObject: GameObject, RenderInterface
	{
		Engine.Image a;
		
		public ActorObject()
		{
			try {
				a = new Engine.Image();
				a.Load(@"a.png");
			} catch (Exception ex) {
				Console.WriteLine(@"ActorObject._ctor()" + ex.Message);
			}
		}
		
		public void Render(Graphics g)
		{
			try {
				a.Draw(0, 0);
			} catch (Exception ex) {
				Console.WriteLine(@"Render: " + ex.Message);
			}
		}

        public void LoadImage(string file)
        {
        }
	}
}
