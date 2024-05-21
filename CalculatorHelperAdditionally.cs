using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;



namespace Calculator
{
    class CalculatorHelperAdditionally
    {
        public void ToggleButtonClick(object sender, RoutedEventArgs e, ColumnDefinition columnDefinition, UIElement additionalOperationsColumn, TextBox text, ToggleButton toggleButton)
        {
            if (additionalOperationsColumn.Visibility == Visibility.Collapsed)
            {
                columnDefinition.Width = new GridLength(75, GridUnitType.Star);

                additionalOperationsColumn.Visibility = Visibility.Visible;
                text.SetValue(Grid.ColumnSpanProperty, 5);
                toggleButton.Content = "❮";
            }
            else
            {
                columnDefinition.Width = new GridLength(0);
                additionalOperationsColumn.Visibility = Visibility.Collapsed;
                toggleButton.Content = "☰";
            }
        }
    }
}
