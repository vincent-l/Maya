using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace Toolkit.Primitives
{
    /// <summary>
    /// Represents an spinner control that includes two buttons.
    /// </summary>
    [TemplatePart(Name = PART_IncreaseButton, Type = typeof(ButtonBase))]
    [TemplatePart(Name = PART_DecreaseButton, Type = typeof(ButtonBase))]
    [ContentProperty("Content")]
    public class Spinner : ContentControl
    {
        #region Members

        internal const string PART_IncreaseButton = "PART_IncreaseButton";
        internal const string PART_DecreaseButton = "PART_DecreaseButton";

        private bool IsReady
        {
            get { return DataSource != null; }
        }

        #region DecreaseButton

        private ButtonBase _decreaseButton;
        /// <summary>
        /// Gets or sets the DecreaseButton template part.
        /// </summary>
        private ButtonBase DecreaseButton
        {
            get
            {
                return _decreaseButton;
            }
            set
            {
                if (_decreaseButton != null)
                    _decreaseButton.Click -= OnButtonClick;

                _decreaseButton = value;

                if (_decreaseButton != null)
                    _decreaseButton.Click += OnButtonClick;
            }
        }

        #endregion //DecreaseButton

        #region IncreaseButton

        private ButtonBase _increaseButton;
        /// <summary>
        /// Gets or sets the IncreaseButton template part.
        /// </summary>
        private ButtonBase IncreaseButton
        {
            get
            {
                return _increaseButton;
            }
            set
            {
                if (_increaseButton != null)
                    _increaseButton.Click -= OnButtonClick;

                _increaseButton = value;

                if (_increaseButton != null)
                    _increaseButton.Click += OnButtonClick;
            }
        }

        #endregion //IncreaseButton

        #endregion // Members

        #region Properties

        #region Value

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                                "Value",
                                typeof(object),
                                typeof(Spinner)
                                );

        /// <summary> 
        /// Gets or sets the value assigned to the control. 
        /// </summary> 
        public object Value
        {
            get { return (object)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        #endregion //Value

        #region DataSource

        public static readonly DependencyProperty DataSourceProperty =
            DependencyProperty.Register(
                        "DataSource",
                        typeof(SpinnerDataSource),
                        typeof(Spinner),
                        new FrameworkPropertyMetadata(OnDataSourceChanged)
                        );

        /// <summary>
        /// The data source that this control is the view for.
        /// </summary>
        public SpinnerDataSource DataSource
        {
            get { return (SpinnerDataSource)GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }

        private static void OnDataSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Spinner spinnerBase = d as Spinner;
            if (spinnerBase != null)
                spinnerBase.OnDataSourceChanged(e.OldValue, e.NewValue);
        }

        protected virtual void OnDataSourceChanged(object oldValue, object newValue)
        {
            SpinnerDataSource spinnerDataSource = newValue as SpinnerDataSource;
            if (spinnerDataSource != null)
                Value = spinnerDataSource.DefaultValue;
        }

        #endregion // DataSource

        #endregion Properties

        #region Constructors

        static Spinner()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                        typeof(Spinner),
                        new FrameworkPropertyMetadata(typeof(Spinner))
                        );
        }

        /// <summary>
        /// Initializes a new instance of the Spinner class.
        /// </summary>
        public Spinner()
        {
            DataSource = new SpinnerDataSource();
        }

        #endregion // Constructor

        #region Base Class Overrides

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            IncreaseButton = GetTemplateChild(PART_IncreaseButton) as ButtonBase;
            DecreaseButton = GetTemplateChild(PART_DecreaseButton) as ButtonBase;

            if (IsReady)
                Content = DataSource.ConvertValueToText(Value);
        }

        #endregion //Base Class Overrides

        #region Event Handlers

        /// <summary>
        /// Handle click event of IncreaseButton and DecreaseButton template parts.
        /// </summary>
        /// <param name="sender">Event sender, should be either IncreaseButton or DecreaseButton template part.</param>
        /// <param name="e">Event args.</param>
        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            if (!IsReady)
                return;

            object newValue = sender == IncreaseButton ? DataSource.GetNext(Value) : DataSource.GetPrevious(Value);
       
            Content = DataSource.ConvertValueToText(Value = newValue);
        }

        #endregion //Event Handlers
    }
}

