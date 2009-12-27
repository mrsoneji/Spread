using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Engine
{
    class IProperties
    {
        public int w, h, originX, originY;
        public float rotation, scaleX = 1.0f, scaleY = 1.0f;
        public bool origin, blending;
        public byte r = 255, g = 255, b = 255, a = 255; // Blending colors


        /// <summary>
        /// Sets new size.
        /// </summary>
        /// <param name="w">New width.</param>
        /// <param name="h">New height.</param>
        public void SetSize(int w, int h)
        {
            this.w = w;
            this.h = h;
        }


        /// <summary>
        /// Sets blending.
        /// </summary>
        public void SetBlending()
        {
            blending = true;
        }



        /// <summary>
        /// Sets blending.
        /// </summary>
        /// <param name="a">Alpha intensity.</param>
        public void SetBlending(byte a)
        {
            blending = true;

            this.a = a;
        }


        /// <summary>
        /// Sets blending.
        /// </summary>
        /// <param name="r">Red intensity.</param>
        /// <param name="g">Green intensity.</param>
        /// <param name="b">Blue intensity.</param>
        /// <param name="a">Alpha intensity.</param>
        public void SetBlending(byte r, byte g, byte b, byte a)
        {
            blending = true;

            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }


        /// <summary>
        /// Disables blending.
        /// </summary>
        public void DisableBlending()
        {
            blending = false;
        }


        /// <summary>
        /// Prepares drawing.
        /// </summary>
        /// <param name="x">X position.</param>
        /// <param name="y">Y position.</param>
        /// <param name="w">Width of frame.</param>
        /// <param name="h">Height of frame.</param>
        protected void Begin(int x, int y, int w, int h)
        {
            // Enable blending if allowed
            if (blending)
            {
                GL.Enable(EnableCap.Blend);
                GL.Color4(r, g, b, a);
            }

            // Rotate around user specified origin
            if (origin)
            {
                GL.Translate(originX, originY, 0.0);
                GL.Rotate(rotation, 0.0f, 0.0f, 1.0f);
                GL.Translate(-originX, -originY, 0.0);
            }
            // Else use frame center as origin
            else
            {
                GL.Translate(x + w / 2, y + h / 2, 0.0);
                GL.Rotate(rotation, 0.0f, 0.0f, 1.0f);
                GL.Translate(-(x + w / 2), -(y + h / 2), 0.0);
            }

            // Scale
            GL.Scale(scaleX, scaleY, 0.0f);
        }


        /// <summary>
        /// Ends drawing.
        /// </summary>
        protected void End()
        {
            // Translate
            GL.LoadIdentity();
            GL.Translate(0.375, 0.375, 0.0);

            // Disable blending
            if (blending)
            {
                GL.Disable(EnableCap.Blend);
                
                // Set white color
                GL.Color4((byte)255, (byte)255, (byte)255, (byte)255);
            }
        }
    }
}
