
namespace Toolkit.Primitives
{
    public class SpinnerDataSource
    {
        #region Members

        private readonly int _defaultValue = 0;

        #endregion // Members

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the SpinnerDataSource class.
        /// </summary>
        public SpinnerDataSource()
        {
        }

        #endregion // Constructor

        #region Virtual Members

        public virtual object DefaultValue
        {
            get { return _defaultValue; }
        }

        /// <summary>
        /// Converts the value to formatted text.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The formatted text.</returns>
        public virtual string ConvertValueToText(object value)
        {
            return value.ToString();
        }

        /// <summary>
        /// Get the next value, relative to an existing value.
        /// </summary>
        /// <param name="relativeTo">The value the return value will be relative to.</param>
        /// <returns>The next value.</returns>
        public virtual object GetNext(object relativeTo)
        {
            int _relativeTo;

            if (!int.TryParse(relativeTo.ToString(), out  _relativeTo))
                return relativeTo;

            return _relativeTo + 1;
        }

        /// <summary>
        /// Get the previous value, relative to an existing value.
        /// </summary>
        /// <param name="relativeTo">The value the return value will be relative to.</param>
        /// <returns>The previous value.</returns>
        public virtual object GetPrevious(object relativeTo)
        {
            int _relativeTo;

            if (!int.TryParse(relativeTo.ToString(), out  _relativeTo))
                return relativeTo;

            return _relativeTo - 1;
        }

        #endregion // Virtual Members
    }
}
