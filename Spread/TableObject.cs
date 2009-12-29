using System;

namespace Spread
{
	public class TableObject: GameObject, RenderInterface, KeyboardInterface, MouseInterface
	{
		ActorState _State = null;

#region define table
		System.Collections.Generic.Dictionary<string, Engine.Image> pieces;
		public System.Drawing.Point Table;
		private string[,] _table;
#endregion
		
		public TableObject()
			:base("table")
		{
			try {
				pieces = new System.Collections.Generic.Dictionary<string, Engine.Image>();
				ChangeState(new ActorMouseReleasedState());

#region loading images
				Engine.Image tmp;
				tmp = new Engine.Image();
				tmp.Load(@"a.png");
				tmp.scaleX = 0.5f; tmp.scaleY = 0.5f;
				pieces.Add("a", tmp);
				tmp = new Engine.Image();
				tmp.Load(@"e.png");
				tmp.scaleX = 0.5f; tmp.scaleY = 0.5f;
				pieces.Add("e", tmp);
				tmp = new Engine.Image();
				tmp.Load(@"i.png");
				tmp.scaleX = 0.5f; tmp.scaleY = 0.5f;
				pieces.Add("i", tmp);
				tmp = new Engine.Image();
				tmp.Load(@"o.png");
				tmp.scaleX = 0.5f; tmp.scaleY = 0.5f;
				pieces.Add("o", tmp);
				tmp = new Engine.Image();
				tmp.Load(@"u.png");
				tmp.scaleX = 0.5f; tmp.scaleY = 0.5f;
				pieces.Add("u", tmp);
				tmp = new Engine.Image();
				tmp.Load(@"ha.png");
				tmp.scaleX = 0.5f; tmp.scaleY = 0.5f;
				pieces.Add("ha", tmp);
				tmp = new Engine.Image();
				tmp.Load(@"ka.png");
				tmp.scaleX = 0.5f; tmp.scaleY = 0.5f;
				pieces.Add("ka", tmp);
				tmp = new Engine.Image();
				tmp.Load(@"ma.png");
				tmp.scaleX = 0.5f; tmp.scaleY = 0.5f;
				pieces.Add("ma", tmp);
				tmp = new Engine.Image();
				tmp.Load(@"na.png");
				tmp.scaleX = 0.5f; tmp.scaleY = 0.5f;
				pieces.Add("na", tmp);
				tmp = new Engine.Image();
				tmp.Load(@"ra.png");
				tmp.scaleX = 0.5f; tmp.scaleY = 0.5f;
				pieces.Add("ra", tmp);
				tmp = new Engine.Image();
				tmp.Load(@"sa.png");
				tmp.scaleX = 0.5f; tmp.scaleY = 0.5f;
				pieces.Add("sa", tmp);
				tmp = new Engine.Image();
				tmp.Load(@"ta.png");
				tmp.scaleX = 0.5f; tmp.scaleY = 0.5f;
				pieces.Add("ta", tmp);
				tmp = new Engine.Image();
				tmp.Load(@"wa.png");
				tmp.scaleX = 0.5f; tmp.scaleY = 0.5f;
				pieces.Add("wa", tmp);
				tmp = new Engine.Image();
				tmp.Load(@"wa.png");
				tmp.scaleX = 0.5f; tmp.scaleY = 0.5f;
				pieces.Add("ya", tmp);
#endregion
				
				_table = new string[50,25];
				for (int x = 0; x < 50; x++) {
					for (int y = 0; y < 25; y++) {
						_table[x,y] = this.GenRandomLetter();
					}
				}
				
			} catch (Exception ex) {
				Console.WriteLine(@"ActorObject._ctor()" + ex.Message);
			}
		}
		
		public void Render()
		{
			try {
				for (int x = 0; x < 50; x++) {
					for (int y = 0; y < 25; y++) {
						pieces[_table[x,y]].Draw(Table.X + (x * 86), Table.Y + (y * 98));
					}
				}
				
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
 
#region GetRandomLetter
		protected string GenRandomLetter()
		{
			Random seed = new Random();
			Random rnd = new Random(seed.Next(DateTime.Now.Millisecond));
			switch (rnd.Next(13)) {
			case 0: return "a"; 
			case 1: return "e"; 
			case 2: return "i"; 
			case 3: return "o"; 
			case 4: return "u";
			case 5: return "ha";
			case 6: return "ka";
			case 7: return "ma";
			case 8: return "na";
			case 9: return "ra";
			case 10: return "sa";
			case 11: return "ta";
			case 12: return "wa";
			case 13: return "ya";
				default: return "a";
			}
		}
#endregion
		
		public void TogglePause()
		{
			if (_State is ActorPausedState) {
				ChangeState(new ActorMouseReleasedState());
			} else {
				ChangeState(new ActorPausedState());
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
		
		public void OnWheelUp(float z)
		{
			foreach (System.Collections.Generic.KeyValuePair<string, Engine.Image> i in pieces) {
				i.Value.scaleX = i.Value.scaleX + 0.1f;
				i.Value.scaleY = i.Value.scaleY + 0.1f;
			}
		}
		
		public void OnWheelDown(float z)
		{
			foreach (System.Collections.Generic.KeyValuePair<string, Engine.Image> i in pieces) {
				i.Value.scaleX = i.Value.scaleX - 0.1f; // if (i.Value.scaleX < 0) { i.Value.scaleX = 0; }
				i.Value.scaleY = i.Value.scaleY - 0.1f; // if (i.Value.scaleY < 0) { i.Value.scaleY = 0; }
			}
		}
		
		public void OnMouseMove(int x, int y)
		{	
			_State.OnMouseMove(x, y, this);
		}
			
		public void OnKeyDown(OpenTK.Input.KeyboardDevice k)
		{
		}
		
        public void LoadImage(string file)
        {
        }
	}
	
	abstract class ActorState
	{
	    public virtual void OnEnter() { } // do nothing by default
	    public virtual void OnExit() { } // do nothing by default

		public virtual void OnMouseMove(int x, int y, TableObject ao) {} // do nothing by default
	}
	
	class ActorMouseClickedState: ActorState
	{
		public override void OnMouseMove(int x, int y, TableObject ao)
		{
			ao.Table.X = ao.Table.X + x; ao.Table.Y = ao.Table.Y + y;
		}
	}

	class ActorPausedState: ActorState
	{
	}
	
	class ActorMouseReleasedState: ActorState
	{
		public override void OnMouseMove(int x, int y, TableObject ao)
		{
		}
	}
}
