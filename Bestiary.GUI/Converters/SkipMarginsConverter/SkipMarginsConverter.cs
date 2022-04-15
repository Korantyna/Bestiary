using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Bestiary.GUI.Converters
{
    [ValueConversion(typeof(Thickness), typeof(Thickness))]
    public class SkipMarginsConverter : MarkupExtension, IValueConverter
    {
        public Margins MarginsToSkip { get; set; }

        public SkipMarginsConverter() : this(Margins.None) { }
        public SkipMarginsConverter(Margins marginsToSkip)
        {
            MarginsToSkip = marginsToSkip;
        }


        #region MarkupExtension Implementation

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return new SkipMarginsConverter(MarginsToSkip);
        }

        #endregion

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Thickness borderThickness)
            {
                if (MarginsToSkip.HasFlag(Margins.Left)) { borderThickness.Left = 0; }
                if (MarginsToSkip.HasFlag(Margins.Top)) { borderThickness.Top = 0; }
                if (MarginsToSkip.HasFlag(Margins.Right)) { borderThickness.Right = 0; }
                if (MarginsToSkip.HasFlag(Margins.Bottom)) { borderThickness.Bottom = 0; }

                return borderThickness;
            }
            else
            {
                throw new ArgumentException($"The argument {nameof(value)} must be of type Thickness.", nameof(value));
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Thickness borderThickness) { return borderThickness; }
            else { throw new ArgumentException($"The argument {nameof(value)} must be of type Margins.", nameof(value)); }
        }
    }

    #endregion
}
