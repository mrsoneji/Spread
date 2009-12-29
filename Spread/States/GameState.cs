using System;
using System.Collections.Generic;

namespace Spread
{
	public abstract class GameState
	{
	    public virtual void OnEnter(Game g) { } // do nothing by default
	    public virtual void OnExit(Game g) { } // do nothing by default

		public virtual void OnRender(Game g) {} // do nothing by default
	}
}
