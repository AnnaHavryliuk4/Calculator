using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Data;


namespace Calculator
{
    class CalculatorHelper
    {
        private readonly TextBox text;
        private readonly Stack<string> operandStack;

        public CalculatorHelper(TextBox textBox, Stack<string> stack)
        {
            text = textBox;
            operandStack = stack;
            text.Text = "0";
            text.PreviewTextInput += Text_PreviewTextInput;
            text.PreviewKeyDown += Text_PreviewKeyDown;

        }
        private void Text_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Back)
            {
                Backspace();
            }
        }

        private void Text_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {

            if (char.IsDigit(e.Text[0]))
            {
                if (text.Text == "0" || text.Text == "-0")
                {
                    e.Handled = true;
                }
            }
            if (IsOperator(e.Text[0]))
            {
                if (text.Text.Length > 0 && IsOperator(text.Text[text.Text.Length - 1]))
                {
                    e.Handled = true; 
                }
            }
        }

        public void ClearAll()
        {
            if (text.Text != "0")
            {
                text.Clear();
                operandStack.Clear();
            }
           
            text.Text = "0";
          
        }

        public void ClearLastOperand()
        {
            if (operandStack.Count > 0)
            {
                string lastOperand = operandStack.Pop();
                text.Text = lastOperand;
            }
        }

        public void AppendOperator(string operatorText)
        {
            if (text.Text.Length > 0 && IsOperator(text.Text[text.Text.Length - 1]))
            {
                text.Text = text.Text.Remove(text.Text.Length - 1);
            }
            operandStack.Push(text.Text);
            text.Text += operatorText;
        }

        private bool IsOperator(char c)
        {
            List<char> operators = new List<char> { '+', '-', '*', '/' };
            return operators.Contains(c);
        }

        public void Backspace()
        {
            if (text.Text.Length > 1 || (text.Text.Length == 1 && text.Text != "0"))
            {
                text.Text = text.Text.Substring(0, text.Text.Length - 1);
            }
            
            if (text.Text == "")
            {
                text.Text = "0";
            }
        }

        public void AppendDigit(string digit)
        {
            if (text.Text==".")
            {
                text.Text = "0.";
            }
            if (text.Text == "0" || text.Text == "-0")
            {
                text.Text = digit;
            }
            else
            {
                text.Text += digit;
            }
        }

        public void CalculateResult()
        {
            text.Text = new DataTable().Compute(text.Text, null).ToString();
        }
    }
}
