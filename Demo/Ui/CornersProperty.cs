using System.ComponentModel;

namespace Demo.Ui
{
    [TypeConverter(typeof(CornerConverter))]
    public class CornersProperty
    {

        private int _all = -1;
        private int _upperLeft;
        private int _upperRight;
        private int _lowerLeft;
        private int _lowerRight;

        public CornersProperty(int lowerLeft, int lowerRight, int upperLeft, int upperRight)
        {
            this.LowerLeft = lowerLeft;
            this.LowerRight = lowerRight;
            this.UpperLeft = upperLeft;
            this.UpperRight = upperRight;
        }

        public CornersProperty(int all)
        {
            this.All = all;
        }


        public CornersProperty()
        {
            LowerLeft = 0;
            LowerRight = 0;
            UpperLeft = 0;
            UpperRight = 0;
        }


        private void CheckForAll(int val)
        {
            if (val != LowerLeft || val != LowerRight || val != UpperLeft || val != UpperRight) return;
            if (_all != val)
                _all = val;
            else
            if (All != -1)
                All = -1;
        }

        [Description("set the Radius of the All four Corners the same")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [NotifyParentProperty(true)]
        [DefaultValue(-1)]
        public int All
        {
            get => _all;
            set
            {

                _all = value;

                if (value <= -1) return;
                _lowerLeft = value;
                _lowerRight = value;
                _upperLeft = value;
                _upperRight = value;
            }
        }








        [Description("set the Radius of the Upper Left Corner")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [NotifyParentProperty(true)]
        [DefaultValue(0)]
        public int UpperLeft
        {
            get => _upperLeft;
            set
            {
                _upperLeft = value;
                CheckForAll(value);
            }

        }






        [Description("set the Radius of the Upper Right Corner")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [NotifyParentProperty(true)]
        [DefaultValue(0)]
        public int UpperRight
        {
            get => _upperRight;
            set
            {
                _upperRight = value;
                CheckForAll(value);
            }

        }

        [Description("set the Radius of the Lower Left Corner")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [NotifyParentProperty(true)]
        [DefaultValue(0)]
        public int LowerLeft
        {
            get => _lowerLeft;
            set
            {
                _lowerLeft = value;
                CheckForAll(value);
            }

        }

        [Description("set the Radius of the Lower Right Corner")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [NotifyParentProperty(true)]
        [DefaultValue(0)]
        public int LowerRight
        {
            get => _lowerRight;
            set
            {
                _lowerRight = value;
                CheckForAll(value);
            }

        }
        public override bool Equals(object obj)
        {

            var eObj = ((CornersProperty)(obj));

            return eObj != null && (All == eObj.All && LowerLeft == eObj.LowerLeft && LowerRight == eObj.LowerRight && UpperLeft == eObj.UpperLeft && UpperRight == eObj.UpperRight);

        }

        public override int GetHashCode()
        {
            var hashCode = 1449682585;
            hashCode = hashCode * -1521134295 + _all.GetHashCode();
            hashCode = hashCode * -1521134295 + _upperLeft.GetHashCode();
            hashCode = hashCode * -1521134295 + _upperRight.GetHashCode();
            hashCode = hashCode * -1521134295 + _lowerLeft.GetHashCode();
            hashCode = hashCode * -1521134295 + _lowerRight.GetHashCode();
            hashCode = hashCode * -1521134295 + All.GetHashCode();
            hashCode = hashCode * -1521134295 + UpperLeft.GetHashCode();
            hashCode = hashCode * -1521134295 + UpperRight.GetHashCode();
            hashCode = hashCode * -1521134295 + LowerLeft.GetHashCode();
            hashCode = hashCode * -1521134295 + LowerRight.GetHashCode();
            return hashCode;
        }
    }
}