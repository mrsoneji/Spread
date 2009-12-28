
using System;

namespace Spread
{
	
	
	public interface MouseInterface
	{
		void OnMouseMove(int x, int y);
		void OnMouseClick();
		void OnMouseRelease();
		void OnWheelUp(float z);
		void OnWheelDown(float z);
	}
}
