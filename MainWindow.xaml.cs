using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IOperation currentOperation;

        private CalculatorHelper calculatorHelper;

        private Stack<string> operandStack;

        public MainWindow()
        {
            InitializeComponent();
            operandStack = new Stack<string>();
            calculatorHelper = new CalculatorHelper(text, operandStack);


            foreach (UIElement el in GroupButton.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += ButtonClick;
                }
            }
        }

        private void ButtonClick(Object sender, RoutedEventArgs e)
        {
            try
            {
                string textButton = ((Button)e.OriginalSource).Content.ToString();
                switch (textButton)
                {
                    case "C":
                        calculatorHelper.ClearAll();
                        break;
                    case "CE":
                        calculatorHelper.ClearLastOperand();
                        break;
                    case "x":
                        calculatorHelper.AppendOperator("*");
                        break;
                    case "+":
                    case "-":
                    case "/":
                        calculatorHelper.AppendOperator(textButton);
                        break;
                    case "⌫":
                        calculatorHelper.Backspace();
                        break;
                    case "=":
                        if (text.Text.EndsWith("/0"))
                        {
                            MessageBox.Show("Division by zero is not allowed.");
                        }
                        else
                        {
                            calculatorHelper.CalculateResult();
                        }
                        break;
                    default:
                        calculatorHelper.AppendDigit(textButton);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            CalculatorHelperAdditionally helperAdditionally = new CalculatorHelperAdditionally();
            helperAdditionally.ToggleButtonClick(sender, e, GroupButton.ColumnDefinitions[4], AdditionalOperationsColumn, text, toggleButton);
        }

        private void SquareRootClicked(object sender, RoutedEventArgs e)
        {
            currentOperation = new SquareRootOperation();
            PerformOperation();
        }

        private void LogarithmClicked(object sender, RoutedEventArgs e)
        {
            currentOperation = new LogarithmOperation();
            PerformOperation();
        }

        private void PowerClicked(object sender, RoutedEventArgs e)
        {
            currentOperation = new PowerOperation();
            PerformOperation();
        }

        private void PercentageClicked(object sender, RoutedEventArgs e)
        {
            currentOperation = new PercentageOperation();
            PerformOperation();
        }

        private void InverseClicked(object sender, RoutedEventArgs e)
        {
            currentOperation = new InverseOperation();
            PerformOperation();
        }

        private void PerformOperation()
        {
            try
            {
                double number = double.Parse(text.Text);
                double result = currentOperation.Calculate(number);
                text.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }
    }
}
