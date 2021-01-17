using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Demo
{
  public   class QbinaryBorder : System.Windows.Forms.Panel
    {

        public QbinaryBorder(): base()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.Padding = new Padding(1, 1, 1, 1);
        }
        #region " Campos"

        private Color _borderColor = Color.LightGray,focus = Color.Blue;
        private bool _BorderOn = true,focusanim =false;
        private int _BorderSize = 1;

        #endregion
        [Category("QBinary Options")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
        } 
        [Category("QBinary Options")]
        public bool BorderOn
        {

            get { return _BorderOn; }
            set { _BorderOn = value; }

        }
        [Category("QBinary Options")]
        public Color FocusColor
        {
            get { return focus; }
            set { focus = value; }
        }
        [Category("Comportamento")]
        public bool FocusAnimation
        {

            get { return focusanim; }
            set { focusanim= value; }

        }
        [Category("QBinary Options")]
        public int BorderSize
        {
            get { return _BorderSize; }
            set
            {
                _BorderSize = value;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (BorderOn) { border(e); }

        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            //if (BorderOn) { border(e); }
           
        }
        
        public  Control[] Exceptions { get; set; } = new Control[] { };
        public override DockStyle Dock { get => base.Dock ; set { base.Dock = value;

                if (value == DockStyle.Top)
                    this.Padding = new Padding(0,0,0,BorderSize);
               else if (value == DockStyle.Left)
                    this.Padding = new Padding(0, 0, BorderSize, 0);
                else    if (value == DockStyle.Right)
                    this.Padding = new Padding(BorderSize, 0,0 , 0);
                else     if (value == DockStyle.Bottom)
                    this.Padding = new Padding(0, BorderSize, 0, 0);
                else     if (value == DockStyle.Fill)
                    this.Padding = new Padding(0,0, 0, 0);
                else if (value == DockStyle.None)
                    this.Padding = new Padding(0, 0, 0, 0);

            }

        }
        private void border(PaintEventArgs e)
        {
           
          e = new PaintEventArgs(e.Graphics, e.ClipRectangle);
          
          GraphicsPath gp = new GraphicsPath();
          RectangleF rect = new RectangleF();
           foreach (Control c in this.Controls)
           {
                var hovered = false;               
                var type = c.GetType();
                c.EnabledChanged += (s , b) =>
                {
                    this.Invalidate();                 
                    return;
                };
                if (type != typeof(Label) & type != typeof(CheckBox) & type != typeof(RadioButton))
                {
                    if (Exceptions.Length > 0)
                    {

                        if (!Exceptions.Contains(c))
                        {
                           

                            if (c.Enabled == true)
                            {
                                rect = c.Bounds;
                                rect.Inflate(1, 1);
                                rect.Height -= 1;
                                rect.Width -= 1;

                                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                                
                                using (Pen pen = new Pen( hovered !=true ? _borderColor : FocusColor, Convert.ToInt32(_BorderSize)))
                                {
                                    pen.LineJoin = LineJoin.Round;
                                    gp.AddRectangle(rect);                                  
                                    e.Graphics.DrawPath(pen, gp);

                                    this.CreateGraphics();
                                }
                            }
                        }
                    }
                    else
                    {                   
                     
                        if (c.Enabled == true) {


                            rect = c.Bounds;
                            rect.Inflate(1, 1);
                            rect.Height -= 1;
                            rect.Width -= 1;

                            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                           
                            using (Pen pen = new Pen(hovered != true ? _borderColor : FocusColor, Convert.ToInt32(_BorderSize)))
                            {

                                pen.LineJoin = LineJoin.Round;
                                gp.AddRectangle(rect);
                                e.Graphics.DrawPath(pen, gp);
                                this.CreateGraphics();

                            }
                        }
                        
                    }
                }

                }
                e.Graphics.Flush();
                gp.Dispose();
            
        }
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            this.Refresh();
            this.Update();
        }
        private void C_EnabledChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
              
    

