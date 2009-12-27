
using System;

namespace Spread
{
	
	
	public class Graphics
	{
		
		public Graphics()
		{
		}
		
		public void Init()
		{
			Console.WriteLine(@"Init Called");
		}
		
		public void Render(RenderInterface ri)
		{
			Console.WriteLine(@"Rendering RenderInterface");
		}
	}
}
