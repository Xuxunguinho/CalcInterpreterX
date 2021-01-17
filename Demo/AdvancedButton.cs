using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Demo.Ui;

namespace Sape.UI
{
    [ToolboxBitmap(typeof(Button))]
    [DesignerCategory("Code")]
    //[Designer(typeof(AdvancedButtonControlDesigner))]
    public class AdvancedButton : Control, ICornedControl, IButtonControl
    {
        private static readonly List<WeakReference> EncList = new List<WeakReference>();
        private MouseState _currentState;
        private BorderState _currentBorderState;
       
        private bool _pressed = false,_hovered;
        [DebuggerNonUserCode]
        static AdvancedButton()
        {
        }

        [DebuggerNonUserCode]
        private static void __ENCAddToList(object value)
        {
            lock (EncList)
            {
                if (EncList.Count == EncList.Capacity)
                {
                    var index1 = 0;
                    const int num1 = 0;
                    var num2 = checked(EncList.Count - 1);
                    var index2 = num1;
                    while (index2 <= num2)
                    {
                        if (EncList[index2].IsAlive)
                        {
                            if (index2 != index1)
                                EncList[index1] = EncList[index2];
                            checked { ++index1; }
                        }
                        checked { ++index2; }
                    }
                    EncList.RemoveRange(index1, checked(EncList.Count - index1));
                    EncList.Capacity = EncList.Count;
                }
                EncList.Add(new WeakReference(RuntimeHelpers.GetObjectValue(value)));
            }
        }

        public AdvancedButton()
        {
            __ENCAddToList(this);
            _currentState = MouseState.None;
            _currentBorderState = BorderState.None;
          
            DrawBorders = true;
            ColorScheme = new MainColorScheme();
            Size = new Size(105, 27);
            ForeColor = Color.Black;
            Font = new Font("Segoe UI", 9f);
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
            FixBug();
        }

        [Browsable(true)]
        [Description("Eine Ober-Eigenschaft, die alle Farbeigenschaften enthält.")]
        [ReadOnly(false)]
        [Category("Appearance")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public MainColorScheme ColorScheme { [DebuggerNonUserCode] get; [DebuggerNonUserCode] set; }

        

        

        [DefaultValue(true)]
        [Description("Gibt an, ob der Button umrandet werden soll.")]
        [Browsable(true)]
        [Category("Appearance")]
        public bool DrawBorders { get; }

        private  MouseState EMouseState
        {
            get => _currentState;
            set
            {
                _currentState= value;
                switch (_currentState)
                {
                    case MouseState.Down:
                        this.Focus();
                        _pressed = false;
                        break;
                    case MouseState.Over:
                        _pressed = true;
                        break;
                    case MouseState.None:
                        _pressed = false;
                        //Capture = false;
                        break;
                    default:
                      
                        break;
                        
                }
                Invalidate(Rectangle.Round(Area));
            }
        }
        private RectangleF Area => AjustRectangle(new Rectangle(0, 0, checked(Width - 1), checked(Height - 1)), Padding);

        private static RectangleF AjustRectangle(RectangleF _base, Padding pad)
        {

            _base.Width = Math.Max(_base.Width - pad.Horizontal, 5);
            _base.Height = Math.Max(_base.Height - pad.Vertical, 5);

            _base.Offset(pad.Left, pad.Top);

            return _base;
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
           
            base.OnMouseClick(e);
            EMouseState = MouseState.None;
           
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            //this.Focus();
            EMouseState = MouseState.Over;
            
            base.OnMouseEnter(e);
        }
        
        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            //Capture = false;
            //OnMouseLeave(EventArgs.Empty);
            base.OnInvalidated(e);
           
           
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            EMouseState = MouseState.None;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            EMouseState = MouseState.Down;
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if(EMouseState == MouseState.Down)
            {
                EMouseState = Area.Contains(PointToClient(Cursor.Position)) ? MouseState.None :MouseState.Over;
            }

            base.OnMouseUp(e);
        }
        private void FixBug()
        {
            
            Invalidate();
        
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics1 = e.Graphics;
            var rectangle = Area;
            graphics1.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics1.SmoothingMode = SmoothingMode.HighQuality;
            var path = GraphicHelper.RoundPath(rectangle, graphics1, 1, Corners);


            using (var pen1 = new Pen(_pressed? ColorScheme.AccentColor : ColorScheme.BorderColor))
            {
                graphics1.DrawPath(pen1, path);
            }


            var stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
         
          
            var text = Text;
            var font = Font;
            
            using (var solidBrush = new SolidBrush(ForeColor))
            {
                
                var layoutRectangle = new RectangleF(0, 0, checked(Width - 1), checked(Height - 1));
                if(_currentState == MouseState.Down)
                    layoutRectangle.Inflate(-4,-4);
                else
                    layoutRectangle.Inflate(4, 4);

                var format = stringFormat;
                graphics1.DrawString(text, font, solidBrush, layoutRectangle, format);
            }

           
            base.OnPaint(e);

        }

        private enum MouseState
        {
            None,
            Over,
            Down,
        }

        private enum BorderState
        {
            None,
            Over,
            Down,
        }

        public interface IButtonColorScheme
        {
            Color BorderColor { get; set; }
            Color AccentColor { get; set; }
            Color PressAccentColor { get; set; }
            Color HoverFillColor { get; set; }
            Color PressFillColor { get; set; }
            Color FillColor { get; set; }
        }

        public class MainColorScheme : IButtonColorScheme
        {
            private Color _accentColor;
            private Color _borderColor;
            private Color _pressAccentColor;
            private Color _hoverFillColor;
            private Color _pressFillColor;
            private Color _fillColor;

            public MainColorScheme()
            {
                _accentColor = Color.FromArgb(0, 164, 240);
                _borderColor = Color.FromArgb(98, 98, 98);
                _pressAccentColor = Color.FromArgb(98, 98, 98);
                _hoverFillColor = Color.White;
                _pressFillColor = Color.FromArgb(101, 101, 101);
                _fillColor = Color.White;
            }

            [Browsable(true)]
            [Description("Gibt die Farbe der Umrandung an.")]
            [Category("Appearance")]
            public Color BorderColor
            {
                get => _borderColor;
                set
                {
                    if (!(value != _borderColor))
                        return;
                    _borderColor = value;
                }
            }

            [Description("Gibt die Farbe für den Farbakzent an.")]
            [Browsable(true)]
            [Category("Appearance")]
            public Color AccentColor
            {
                get => _accentColor;
                set
                {
                    if (!(value != _accentColor))
                        return;
                    _accentColor = value;
                }
            }

            [Browsable(true)]
            [Description("Gibt die Farbe für den Farbakzent aktivem Pressed-Effekt an.")]
            [Category("Appearance")]
            public Color PressAccentColor
            {
                get => _pressAccentColor;
                set
                {
                    if (!(value != _pressAccentColor))
                        return;
                    _pressAccentColor = value;
                }
            }

            [Browsable(true)]
            [Category("Appearance")]
            [Description("Gibt die Farbe des Buttons an, wenn der Hover-Effekt aktiv ist.")]
            public Color HoverFillColor
            {
                get => _hoverFillColor;
                set
                {
                    if (!(value != _hoverFillColor))
                        return;
                    _hoverFillColor = value;
                }
            }

            [Browsable(true)]
            [Category("Appearance")]
            [Description("Gibt die Farbe des Buttons an, wenn der Pressed-Effekt aktiv ist.")]
            public Color PressFillColor
            {
                get => _pressFillColor;
                set
                {
                    if (!(value != _pressFillColor))
                        return;
                    _pressFillColor = value;
                }
            }

            [Browsable(true)]
            [Category("Appearance")]
            [Description("Gibt die Farbe des Buttons an, wenn kein Effekt aktiv ist.")]
            public Color FillColor
            {
                get => _fillColor;
                set
                {
                    if (!(value != _fillColor))
                        return;
                    _fillColor = value;
                }
            }
        }

        public void NotifyDefault(bool value)
        {
           
        }

        public void PerformClick()
        {
            
        }

        public DialogResult DialogResult { get; set; }
        public CornersProperty Corners { get; set; } = new CornersProperty(0);
    }
}
