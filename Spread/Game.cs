using OpenTK;
using System;
using System.Collections.Generic;

namespace Spread
{
    public class Game: GameWindow 
    {
        List<GameObject> iter_go;
		
		bool _mouseclicked = false;
		float _wheelvalue = 0.0f;
		
        public Game()
            : base(1280, 800, OpenTK.Graphics.GraphicsMode.Default, @"Spread: pre-alpha stage")
        {
			this.WindowState = WindowState.Fullscreen; 
            iter_go = new List<GameObject>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Engine.Core.Init();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

#region interface call
			foreach (KeyboardInterface ki in iter_go)
            {
                ki.OnKeyDown(Keyboard);
            }
			
			foreach (MouseInterface mi in iter_go)
            {
					mi.OnMouseMove(Mouse.XDelta, Mouse.YDelta);
					if (Mouse[OpenTK.Input.MouseButton.Left]){ mi.OnMouseClick(); _mouseclicked = true; }
					if (!Mouse[OpenTK.Input.MouseButton.Left] && _mouseclicked){ mi.OnMouseRelease(); _mouseclicked = false; }
					if (Mouse.WheelPrecise > _wheelvalue) { mi.OnWheelUp(Mouse.WheelPrecise); _wheelvalue = Mouse.WheelPrecise; }
					if (Mouse.WheelPrecise < _wheelvalue) { mi.OnWheelDown(Mouse.WheelPrecise); _wheelvalue = Mouse.WheelPrecise; }
            }
#endregion 
			
			if (Keyboard[OpenTK.Input.Key.Escape])
            {
                Exit();
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            Engine.Core.Clear();

#region interface call
            foreach (RenderInterface ri in iter_go)
            {
                ri.Render();
            }
			
            SwapBuffers();
        }
#endregion
		
        public List<GameObject> GameObjects
        {
            get
            {
                return iter_go;
            }
        }
    }
}