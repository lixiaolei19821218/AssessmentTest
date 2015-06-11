using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace AssessmentTest
{
    /// <summary>
    /// Convert GridCell Foreground depending on number's value.
    /// </summary>
    class ForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                string text = value as string;
                double v;

                if (double.TryParse(text, out v))//ReferenceFuture
                {
                    if (v < 0.0)
                    {
                        return Brushes.Red;
                    }
                }
                else if (text.Contains("%"))//Volatility, VolChange, and TickChange are percentages
                {
                    if (double.TryParse(text.Replace("%", string.Empty), out v))
                    {
                        if (v / 100 < 0.0)//Convert Back to orignal value
                        {
                            return Brushes.Red;
                        }
                    }
                }
            }
            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
