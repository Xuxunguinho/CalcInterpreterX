using System;
using System.Drawing;
using System.Windows.Forms;

namespace Demo
{
    public  class MathGrid : Control
    {
        private Size _siz = new Size(5,4);
        public Size MatrixSize {
            get => _siz;
            set
            {
                _siz = value;
                Draw(_siz);
            }
        }

        private void Draw(Size matrixSize)
        {
            var size = new Size(40, 40);
            var antlocX = 0;
            var antlocY = 0;
            var tempcell = new AlgsCell();
            for (var j = 0; j < matrixSize.Height; j++)
            {

                for (var i = 0; i < matrixSize.Width; i++)
                {

                    tempcell = new AlgsCell
                    {
                        Size = size,
                        Location = new Point(i == 0 ? 3 : (antlocX + size.Width + 1),
                            j == 0 ? 3 : (antlocY + size.Height + 1)),
                    };
                    antlocX = tempcell.Location.X;

                    this.Controls.Add(tempcell);
                }
                antlocY = tempcell.Location.Y;
            }
        }

        protected override void InitLayout()
        {
            base.InitLayout();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
            base.OnPaint(e);
        }

      

        protected override void OnParentChanged(EventArgs e)
        {
          
           
            base.OnParentChanged(e);
        }
    }
}
