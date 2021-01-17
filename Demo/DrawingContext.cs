using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Demo
{
    public sealed class DrawingContext
    {
        public MathGrid Grid { get; set; }

       

        public DrawMode DrawMode { get; set; }
      
        public AlgsCell AlgCell { get; set; }
        public OperatorsCell OperatorCell { get; set; }
        public Position CellPos { get; set; }/// <summary>
        /// Not available yet
        /// </summary>
      
       

        #region Clip
        private readonly Stack<RectangleF> _clipStack = new Stack<RectangleF>(2);

        public void PushClip(RectangleF clip)
        {
            if (this.Graphics.IsClipEmpty)
            {
                this.Graphics.SetClip(clip);
            }
            else
            {
                this.Graphics.IntersectClip(clip);
            }

            this._clipStack.Push(clip);
        }

        public void PopClip()
        {
            this._clipStack.Pop();

            if (_clipStack.Count == 0)
            {
                this.Graphics.ResetClip();
            }
            else
            {
                var curr = _clipStack.Peek();
                this.Graphics.SetClip(curr);
            }
        }

        public Rectangle ClipBounds { get; set; }

        #endregion // Clip

        public DrawingContext(MathGrid instance, DrawMode drawMode,
            Graphics g, Rectangle clipBounds)
        {
            this.Graphics = g;
            this.Grid = instance;
            this.DrawMode = drawMode;
            this.ClipBounds = clipBounds;
        }

        #region Graphics Wrap

        internal GraphicsState CellDrawGraphicsState { get; set; }
        internal GraphicsState CoreDrawGraphicsState { get; set; }

        public Graphics Graphics { get; set; }

        #endregion
    }
}