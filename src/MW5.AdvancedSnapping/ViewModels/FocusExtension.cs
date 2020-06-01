using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MW5.Plugins.AdvancedSnapping.WPFExtensions
{
    /// <summary>
    /// Example usage: <TextBox core:FocusExtension.IsFocused="{Binding IsUserNameFocused}" />
    /// </summary>
    public static class FocusExtension
    {
        public static readonly DependencyProperty IsFocusedProperty =
            DependencyProperty.RegisterAttached("IsFocused", typeof(bool?), typeof(FocusExtension), new FrameworkPropertyMetadata(IsFocusedChanged) { BindsTwoWayByDefault = true });

        public static bool? GetIsFocused(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            return (bool?)element.GetValue(IsFocusedProperty);
        }

        public static void SetIsFocused(DependencyObject element, bool? value)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            element.SetValue(IsFocusedProperty, value);
        }

        public static void ApplyFocus(FrameworkElement fe)
        {
            fe.Focus();
            if (fe is TextBox textBox) {
                Keyboard.Focus(fe);
                textBox.SelectAll();
            }
        }

        private static void IsFocusedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fe = (FrameworkElement)d;

            if (e.OldValue == null)
            {
                fe.GotFocus += FrameworkElement_GotFocus;
                fe.LostFocus += FrameworkElement_LostFocus;
            }

            if (!fe.IsVisible)
            {
                fe.IsVisibleChanged += new DependencyPropertyChangedEventHandler(IsVisibleChanged);
            }

            if ((bool?) e.NewValue ?? false)
            {
                ApplyFocus(fe);
            }
        }

        private static void IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var fe = (FrameworkElement)sender;
            if (fe.IsVisible && (bool)((FrameworkElement)sender).GetValue(IsFocusedProperty))
            {
                fe.IsVisibleChanged -= IsVisibleChanged;
                ApplyFocus(fe);
            }
        }

        private static void FrameworkElement_GotFocus(object sender, RoutedEventArgs e)
        {
            if (e.Source == e.OriginalSource)
                ((FrameworkElement)sender).SetValue(IsFocusedProperty, true);
        }

        private static void FrameworkElement_LostFocus(object sender, RoutedEventArgs e)
        {
            if (e.Source == e.OriginalSource)
                ((FrameworkElement)sender).SetValue(IsFocusedProperty, false);
        }
    }
}
