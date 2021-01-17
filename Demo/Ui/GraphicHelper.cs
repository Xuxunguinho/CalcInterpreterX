using System.Drawing;
using System.Drawing.Drawing2D;

namespace Demo.Ui
{
    public static  class GraphicHelper
    {
        public static GraphicsPath RoundPath(RectangleF baseRect, Graphics e, float inf, CornersProperty crn)
        {
            e.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF arcRect;
            var path = new GraphicsPath();
            baseRect.Inflate(-inf, -inf);
            if (crn.All == -1)
            {

                //  top left arc
                if (crn.UpperLeft != 0)
                {
                    arcRect = new RectangleF(baseRect.Location,
                     new SizeF(crn.UpperLeft * 2, crn.UpperLeft * 2));
                    path.AddArc(arcRect, 180, 90);
                }
                else
                    path.AddLine(baseRect.X, baseRect.Y, baseRect.X, baseRect.Y);

                // top right arc
                if (crn.UpperRight != 0)
                {
                    arcRect = new RectangleF(baseRect.Location,
                        new SizeF(crn.UpperRight * 2, crn.UpperRight * 2)) {X = baseRect.Right - (crn.UpperRight * 2)};
                    path.AddArc(arcRect, 270, 90);
                }
                else
                {
                    path.AddLine(baseRect.X + (crn.LowerLeft), baseRect.Y, baseRect.Right - (crn.LowerLeft), baseRect.Top);
                }
                // bottom right arc

                if (crn.LowerRight != 0)
                {

                    arcRect = new RectangleF(baseRect.Location,
                        new SizeF(crn.LowerRight * 2, crn.LowerRight * 2))
                    {
                        Y = baseRect.Bottom - (crn.LowerRight * 2),
                        X = baseRect.Right - (crn.LowerRight * 2)
                    };

                    path.AddArc(arcRect, 0, 90);
                }
                else
                    path.AddLine(baseRect.Right, baseRect.Top + (crn.LowerRight), baseRect.Right, baseRect.Bottom - (crn.LowerRight));



                // bottom left arc
                if (crn.LowerLeft != 0)
                {
                    arcRect = new RectangleF(baseRect.Location,
                        new SizeF(crn.LowerLeft * 2, crn.LowerLeft * 2)) {Y = baseRect.Bottom - (crn.LowerLeft * 2)};
                    path.AddArc(arcRect, 90, 90);
                }
                else
                    path.AddLine(baseRect.Right - (crn.LowerLeft), baseRect.Bottom, baseRect.X - (crn.LowerLeft), baseRect.Bottom);

                path.CloseFigure();


            }
            else
            {
                if (crn.All == 0)
                    path.AddRectangle(baseRect);
                else
                {

                    arcRect = new RectangleF(baseRect.Location,
                        new SizeF(crn.All * 2, crn.All * 2));
                    // top left arc
                    path.AddArc(arcRect, 180, 90);

                    // top right arc
                    arcRect.X = baseRect.Right - (crn.All * 2);
                    path.AddArc(arcRect, 270, 90);

                    //bottom right arc
                    arcRect.Y = baseRect.Bottom - (crn.All * 2);
                    path.AddArc(arcRect, 0, 90);

                    // bottom left arc
                    arcRect.X = baseRect.Left;
                    path.AddArc(arcRect, 90, 90);
                }



                path.CloseFigure();


            }

            return path;


        }

        public static GraphicsPath BorderPath(RectangleF baseRect, Graphics e)
        {
            e.SmoothingMode = SmoothingMode.AntiAlias;
            var path = new GraphicsPath();
            baseRect.Inflate(-2,-2);
            path.AddRectangle(baseRect);
            path.CloseFigure();
            return path;
        }
    }
}
