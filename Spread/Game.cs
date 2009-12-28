using OpenTK;
using System;
using System.Collections.Generic;

namespace Spread
{
    public class Game: GameWindow 
    {
        Graphics gr;
        List<GameObject> iter_go;

        public Game()
            : base(800, 600, OpenTK.Graphics.GraphicsMode.Default, @"Spread: pre-alpha stage")
        {
            gr = new Graphics();
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

            if (Keyboard[OpenTK.Input.Key.Escape])
            {
                Exit();
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            Engine.Core.Clear();

			this.Flip();
			
            SwapBuffers();
        }

        public void Flip()
        {
            foreach (RenderInterface ri in iter_go)
            {
                ri.Render(gr);
            }
        }

        public List<GameObject> GameObjects
        {
            get
            {
                return iter_go;
            }
        }
    }
}