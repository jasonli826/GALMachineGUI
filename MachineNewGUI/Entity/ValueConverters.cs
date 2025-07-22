using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace MachineNewGUI.Entity.ValueConverters
{
    public class HandConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool hand = (bool)value;
            if (hand == false)
                return "Righty";
            else
                return "Lefty";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string hand = (string)value;
            if (hand == "Righty")
                return false;
            else
                return true;
        }
    }

    public class ElbowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool hand = (bool)value;
            if (hand == false)
                return "Above";
            else
                return "Below";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string hand = (string)value;
            if (hand == "Above")
                return false;
            else
                return true;
        }
    }

    public class WristConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool hand = (bool)value;
            if (hand == false)
                return "No Flip";
            else
                return "Flip";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string hand = (string)value;
            if (hand == "No Flip")
                return false;
            else
                return true;
        }
    }

    public class DoubleToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double tmp = (double)value;
            return tmp.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string tmp = (string)value;
            return System.Convert.ToDouble(tmp);
        }
    }

    public class IsGreaterThanZero : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value.ToString() == string.Empty)
            {
                return false;
            }
            else
            {
                if (System.Convert.ToInt32(value) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();//"PresenterConverter.ConvertBack() is not implemented!");
        }
        #endregion
    }

    public class DoubleToBoolConverter : IValueConverter
    {
        public double Falsevalue { get; set; } = 0;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double doubleValue)
                return doubleValue > Falsevalue;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!(value is bool boolValue))
                throw new NotImplementedException();

            if(boolValue)
                return 1;
            return 0;
        }
    }

    public class SkipScanDoubleToStringConverter : IValueConverter
    {
        public double Falsevalue { get; set; } = 0;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double doubleValue)
            {
                if (doubleValue == 0)
                    return "Yes";
                else if(doubleValue == 1)
                    return "No";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool boolValue))
                throw new NotImplementedException();

            if (boolValue)
                return 1;
            return 0;
        }
    }

    public class BoolSwapConverter : IValueConverter
    {
        public double Falsevalue { get; set; } = 0;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool result)
            {
                if (result == true)
                    return false;
                else
                    return true;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool boolValue))
                throw new NotImplementedException();

            if (boolValue)
                return 0;
            return 1;
        }
    }
}
