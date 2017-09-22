using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MinimalControls.AttachedProperties
{
    public class Attached
    {
        public static readonly DependencyProperty PlaceholderAttachedProperty = DependencyProperty.RegisterAttached("Placeholder", typeof(string), typeof(Attached), new PropertyMetadata(""));

        public static void SetPlaceholder(DependencyObject d, string value)
        {
            d.SetValue(PlaceholderAttachedProperty, value);
        }

        public static string GetPlaceholder(DependencyObject d, string value)
        {
            return (string)d.GetValue(PlaceholderAttachedProperty);
        }
    }
}
