using System;
using Toolkit.Primitives;

namespace ToolkitTesting
{
    public class DateSpinnerDataSource : SpinnerDataSource
    {
        #region Members

        private readonly DateTime _defaultValue = DateTime.Today;

        #endregion // Members

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the DateSpinnerDataSource class.
        /// </summary>
        public DateSpinnerDataSource()
        {
        }

        #endregion // Constructor

        #region Base Class Overrides

        public override object DefaultValue
        {
            get { return _defaultValue; }
        }

        public override string ConvertValueToText(object value)
        {
            return string.Format("{0:dddd d MMMM yyyy}", value);
        }

        public override object GetNext(object relativeTo)
        {
            DateTime _value = (DateTime)relativeTo;

            return _value.AddDays(+1);
        }

        public override object GetPrevious(object relativeTo)
        {
            DateTime _value = (DateTime)relativeTo;

            return _value.AddDays(-1);
        }

        #endregion // Base Class Overrides
    }
}
