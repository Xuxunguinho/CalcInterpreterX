using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;

namespace Demo.Ui
{
    public class CornerConverter : ExpandableObjectConverter
    {

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {

            var crn = new CornersProperty();
            int.TryParse(propertyValues["All"].ToString(), out int al);

            int.TryParse(propertyValues["LowerLeft"].ToString(), out int ll);
            int.TryParse(propertyValues["LowerRight"].ToString(), out int lr);
            int.TryParse(propertyValues["UpperLeft"].ToString(), out int ul);
            int.TryParse(propertyValues["UpperRight"].ToString(), out int ur);


            var oAll = ((ICornedControl)context.Instance).Corners.All;

            if (oAll != al & al > -1)
                crn.All = al;
            else
            {
                crn.LowerLeft = ll;

                crn.LowerRight = lr;

                crn.UpperLeft = ul;

                crn.UpperRight = ur;

            }
            return crn;


        }


        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof( string) || base.CanConvertFrom(context, sourceType);
        }


        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {

            if (value is string)
            {

                try
                {
                    var s = value.ToString();


                    var cornerParts = s.Split(',');


                    if (cornerParts[0] == null)
                    {
                        cornerParts[0] = "0";
                    }
                    if (cornerParts[1] == null)
                    {
                        cornerParts[1] = "0";
                    }
                    if (cornerParts[2] == null)
                    {
                        cornerParts[2] = "0";
                    }
                    if (cornerParts[3] == null)
                    {
                        cornerParts[3] = "0";
                    }
                    return new CornersProperty(int.Parse(cornerParts[0].Trim()),
                        int.Parse(cornerParts[1].Trim()),
                        int.Parse(cornerParts[2].Trim()),
                        int.Parse(cornerParts[3].Trim()));
                }
                catch (Exception)
                {

                    throw new ArgumentException($"Can not convert '{(value.ToString())}' to type Corners");
                }
            }
            else
                return new CornersProperty(2, 2, 2, 2);


            return base.ConvertFrom(context, culture, value);
        }


        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {

            var corners = ((CornersProperty)value);

            //if (destinationType.GetType() == typeof(string) && value.GetType() == typeof(ProgressBarCornersProperty))
            //{
            return $"{corners.LowerLeft}, {corners.LowerRight}, {corners.UpperLeft}, {corners.UpperRight}";

            //}

            return base.ConvertTo(context, culture, value, destinationType);
        }

    }
}
