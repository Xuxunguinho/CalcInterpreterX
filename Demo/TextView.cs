/**********************************************
 *  This software was developed by :
 *  
 *  Júlio José de Andrade Reis
 *  Email: julioreisdev@outlook.com 
 * 
 * OpenSource
 **********************************************/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Demo.Ui;

namespace Demo
{
    public class TextView : Control,ICornedControl
    {
        private string _text;

        public override string Text { get => _text;
            set { _text = value; Invalidate(ClientRectangle);
               
            }
        }
        private StringAlignment _ali = StringAlignment.Center;

        [Category("Aparência")]
        public Color BorderColor { get; set; } = ColorTranslator.FromHtml("#00C8FF");
        public Color BaseColor { get; set; } = ColorTranslator.FromHtml("#00C8FF");
        [Category("Comportamento")]
         public bool UseBorder { get; set; }

        [Category("Aparência")]
        public StringAlignment TextAligment
        {
            get => _ali;
            set
            {
                _ali = value;

                Update();
                Refresh();

            }
        }
        private int _textPadding = 14;

        [Category("Aparência")]
        [DefaultValue(14)]
        public virtual int TextPadding
        {
            get => _textPadding;
            set { _textPadding = value; Invalidate(); }
        }

        public TextView()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
        protected override void InitLayout()
        {

            SetStyle( ControlStyles.SupportsTransparentBackColor, true);
            
            base.InitLayout();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            SuspendLayout();

            var x = ClientRectangle.Left;
           
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            var rect = new Rectangle(0,0,Width -1,Height-1);

            var ft = new StringFormat(StringFormat.GenericDefault);

            if (UseBorder)
            {
                using (var pen = new Pen(new SolidBrush(BorderColor), 1))
                {
                    var path = GraphicHelper.RoundPath(rect, e.Graphics,0,Corners);
                    e.Graphics.DrawPath(pen,path);
                    e.Graphics.FillPath(new SolidBrush(BaseColor), path);
                }
              
                
            }

            if (!string.IsNullOrEmpty(Text))
            {
                ft.Alignment =TextAligment;
                ft.LineAlignment = TextAligment;
                          //Width = TextRenderer.MeasureText(Text, Font).Width + 10;
                //var textSize = e.Graphics.MeasureString(Text, Font, ClientRectangle.Width, ft);                
                var textRect = new Rectangle(x, 0, (int)rect.Width + TextPadding, rect.Height - 1);
                textRect.Inflate(-8,-8);
              

                using (Brush b = new SolidBrush(ForeColor))
                {
                    e.Graphics.DrawString(Text, Font, b, textRect, ft);
                }

            }      

            e.Graphics.Flush();
            ResumeLayout();
            base.OnPaint(e);
        }

        protected override void OnResize(EventArgs e)
        {
            Invalidate(ClientRectangle);
            base.OnResize(e);
        }

        public CornersProperty Corners { get; set; }= new CornersProperty(1);
    }
}
