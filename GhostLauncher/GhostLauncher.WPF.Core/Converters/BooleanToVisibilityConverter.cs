﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace GhostLauncher.WPF.Core.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(Visibility))
                throw new InvalidOperationException("Converter can only convert to value of type Visibility.");

            var falseVisibility = Visibility.Collapsed;

            var param = parameter as string;
            if (param != null)
            {
                if (param.ToLower() == "hidden")
                {
                    falseVisibility = Visibility.Hidden;
                }
            }

            var visible = System.Convert.ToBoolean(value, culture);
            if (InvertVisibility) visible = !visible;
            return visible ? Visibility.Visible : falseVisibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("Converter cannot convert back.");
        }

        public bool InvertVisibility { get; set; }
    }
}
