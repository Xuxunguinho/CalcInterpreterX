using System.Drawing;
using System.Windows.Forms;
using Demo.Properties;

namespace Demo
{
    public  class AlgsCell : Control
    {
        private Rectangle _imageRect;
        private Graphics _graphics;
        public Image Ico { get; set; }
        public bool IsIcognite { get; set; }
        public bool IsResult { get; set; }
        public double Value { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            _imageRect = new Rectangle(0,0,Width -1,Height-1);
            new RectangleF(0,0,Width-1,Height-1);
            _graphics = e.Graphics;
            _imageRect.Inflate(-1,-1);
            using (var p = new Pen(GridColorSheme.CellBorderColor))
            {
                _graphics.DrawRectangle(p,_imageRect);
                //_graphics.DrawString("15",this.Font,new SolidBrush(GridColorSheme.CellTextColor), _textRect);
                _graphics.DrawImage(Resources.Logo, _imageRect);
            }
            _graphics.Dispose();
            base.OnPaint(e);
        }
        public void ShowValue()
        {
        }
        
    }
    public class OperatorsCell : Control
    {

    }
}
