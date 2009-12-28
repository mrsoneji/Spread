
using System;

namespace Spread
{
	public class ActorObject: GameObject, RenderInterface, KeyboardInterface, MouseInterface
	{
		Engine.Image a;
		ActorState _State = null;

		public System.Drawing.Point Table;
		
		public ActorObject()
		{
			try {
				ChangeState(new ActorMouseReleasedState());
				
				a = new Engine.Image();
				a.Load(@"a.png");
			} catch (Exception ex) {
				Console.WriteLine(@"ActorObject._ctor()" + ex.Message);
			}
		}
		
		public void Render(Graphics g)
		{
			try {
				a.Draw(Table.X, Table.Y);
			} catch (Exception ex) {
				Console.WriteLine(@"Render: " + ex.Message);
			}
		}
		
	    void ChangeState(ActorState state)
	    {
			try {
		        if (_State != null)
		            _State.OnExit();
		        _State = state;
		        _State.OnEnter();
			} catch (Exception) {
				
			}
	    }
 
		public void OnMouseClick()
		{
			ChangeState(new ActorMouseClickedState());
		}
		
		public void OnMouseRelease()
		{
			ChangeState(new ActorMouseReleasedState());			
		}
		
		public void OnMouseMove(int x, int y)
		{	
			_State.OnMouseMove(x, y, this);
		}
			
		public void OnKeyDown(OpenTK.Input.KeyboardDevice k)
		{
			if (k[OpenTK.Input.Key.Right]) { Table.X++; }
			if (k[OpenTK.Input.Key.Left]) { Table.Y--; }
		}
		
        public void LoadImage(string file)
        {
        }
	}
	
	abstract class ActorState
	{
	    public virtual void OnEnter() { } // do nothing by default
	    public virtual void OnExit() { } // do nothing by default

		public virtual void OnMouseMove(int x, int y, ActorObject ao) {} // do nothing by default
	}
	
	class ActorMouseClickedState: ActorState
	{
		public override void OnMouseMove(int x, int y, ActorObject ao)
		{
			ao.Table.X = ao.Table.X + x; ao.Table.Y = ao.Table.Y + y;
		}
	}

	class ActorMouseReleasedState: ActorState
	{
		public override void OnMouseMove(int x, int y, ActorObject ao)
		{
		}
	}
}
