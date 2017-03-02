using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace The_Calculator
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string expression = "";
        private string number;
        private List<char> ex = new List<char>();
        private bool op = false;
        private bool parentheses = false;
        private bool isResult = false;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Input("1");
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Input("2");
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Input("3");
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Input("4");
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Input("5");
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Input("6");
        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Input("7");
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Input("8");
        }
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Input("9");
        }
        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            Input("0");
        }
        private void Button_Click_Point(object sender, RoutedEventArgs e)
        {
            if (!number.Contains("."))
                Input(".");
        }

        private void Input(string str)
        {
            if (!op)
                op = true;
            number = number + str;
            numberText.Text = number;
        }

        private void Button_Click_Subtract(object sender, RoutedEventArgs e)
        {
            if (isResult)
            {
                expression = number + '-';
                number = "";
                expressionText.Text = expression;
                numberText.Text = number;
                isResult = false;
                op = false;
            }
            else
            {
                if (op)
                {
                    expression = expression + number + "-";
                    expressionText.Text = expression;
                    number = "";
                    numberText.Text = "";
                    op = false;
                }
                else
                {
                    expression = expression.Substring(0, expression.Length - 1);
                    expression = expression + "-";
                    expressionText.Text = expression;
                }
            }
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            if (isResult)
            {
                expression = number + '+';
                number = "";
                expressionText.Text = expression;
                numberText.Text = number;
                isResult = false;
                op = false;
            }
            else
            {
                if (op)
                {
                    expression = expression + number + "+";
                    expressionText.Text = expression;
                    number = "";
                    numberText.Text = "";
                    op = false;
                }
                else
                {
                    expression = expression.Substring(0, expression.Length - 1);
                    expression = expression + "+";
                    expressionText.Text = expression;
                }
            }
           
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (number != "")
            {
                number = number.Substring(0, number.Length - 1);
                numberText.Text = number;
            }
            else
            {
                expression = expression.Substring(0, expression.Length - 1);
                expressionText.Text = expression;
                op = true;
            }
            
        }

        private void Button_Click_Result(object sender, RoutedEventArgs e)
        {
            expression = expression + number;
            number = "";
            numberText.Text = number;
            expressionText.Text = expression;
            trans(expression);
            compvalue();
        }

        private void Button_Click_Multiply(object sender, RoutedEventArgs e)
        {
            if (isResult)
            {
                expression = number + 'x';
                number = "";
                expressionText.Text = expression;
                numberText.Text = number;
                isResult = false;
                op = false;
            }
            else
            {
                if (op)
                {
                    expression = expression + number + "x";
                    expressionText.Text = expression;
                    number = "";
                    numberText.Text = "";
                    op = false;
                }
                else
                {
                    expression = expression.Substring(0, expression.Length - 1);
                    expression = expression + "x";
                    expressionText.Text = expression;
                }
            }
        }

        private void Button_Click_Divide(object sender, RoutedEventArgs e)
        {
            if (isResult)
            {
                expression = number + '/';
                number = "";
                expressionText.Text = expression;
                numberText.Text = number;
                isResult = false;
                op = false;
            }
            else
            {
                if (op)
                {
                    expression = expression + number + "/";
                    expressionText.Text = expression;
                    number = "";
                    numberText.Text = "";
                    op = false;
                }
                else
                {
                    expression = expression.Substring(0, expression.Length - 1);
                    expression = expression + "/";
                    expressionText.Text = expression;
                }
            }
        }

        private void Button_Click_Left_parenthesis(object sender, RoutedEventArgs e)
        {
            if (expression == "")
            {
                expression = "(";
                expressionText.Text = expression;
                parentheses = true;
            }
            else
            {
                if (!op)
                {
                    expression = expression + "(";
                    expressionText.Text = expression;
                    parentheses = true;
                }
            }
        }

        private void Button_Click_Right_parenthesis(object sender, RoutedEventArgs e)
        {
            if (parentheses)
            {
                if (op)
                {
                    expression = expression + number + ")";
                    expressionText.Text = expression;
                    number = "";
                    numberText.Text = "";
                }
                else
                {
                    expression = expression.Substring(0, expression.Length - 1);
                    expression = expression + ")";
                    expressionText.Text = expression;
                }
            }
        }

        void trans(string str)
        {
            List<char> op = new List<char>();
            char ch;
            for (int i = 0; i < str.Length; i++)
            {
                ch = str[i];
                switch(ch)
                {
                    case '(':/*判定为左括号*/
                        op.Add(ch);
                        break;
                    case ')':/*判定为右括号*/
                        while (op[op.Count - 1] != '(')
                        {
                            ex.Add(op[op.Count - 1]);
                            op.RemoveAt(op.Count - 1);
                        }
                        op.RemoveAt(op.Count - 1);
                        break;
                    case '+':
                    case '-':
                        while (op.Count != 0 && op[op.Count - 1] != '(')
                        {
                            ex.Add(op[op.Count - 1]);
                            op.RemoveAt(op.Count - 1);
                        }
                        op.Add(ch);
                        break;
                    case 'x':
                    case '/':
                        while (op.Count != 0 && (op[op.Count - 1] == '*' || op[op.Count - 1] == '/'))
                        {
                            ex.Add(op[op.Count - 1]);
                        }
                        op.Add(ch);
                        break;
                    case '\0': break;
                    default:
                        while (ch >= '0' && ch <= '9' || ch == '.')
                        {
                            ex.Add(ch);
                            i++;
                            if (i < str.Length)
                                ch = str[i];
                            else
                                break;
                            
                        }
                        i--;
                        ex.Add('\0');
                        break;
                }
            }
            while (op.Count != 0)
            {
                ex.Add(op[op.Count - 1]);
                op.RemoveAt(op.Count - 1);
            }
            ex.Add('#');
        }
        void compvalue()
        {
            List<double> num = new List<double>();
            double d;
            int i = 0;
            char ch = ex[i];
            while (ch != '#')
            {
                switch (ch)
                {
                    case '+':
                        num[num.Count - 2] = num[num.Count - 2] + num[num.Count - 1];
                        num.RemoveAt(num.Count - 1);
                        break;
                    case '-':
                        num[num.Count - 2] = num[num.Count - 2] - num[num.Count - 1];
                        num.RemoveAt(num.Count - 1);
                        break;
                    case 'x':
                        num[num.Count - 2] = num[num.Count - 2] * num[num.Count - 1];
                        num.RemoveAt(num.Count - 1);
                        break;
                    case '/':
                        if (num[num.Count - 1] != 0)
                        {
                            num[num.Count - 2] = num[num.Count - 2] / num[num.Count - 1];
                            num.RemoveAt(num.Count - 1);
                        } 
                        else
                        {
                            numberText.Text = "除数不能为零";
                        }
                        break;
                    default:
                        d = 0;
                        double j = 0.1;
                        while (ch >= '0' && ch <= '9' && ch != '\0')
                        {
                            d = 10 * d + ch - '0';
                            i++;
                            ch = ex[i];
                        }
                        if (ch == '.')
                        {
                            i++;
                            ch = ex[i];
                            while (ch >= '0' && ch <= '9' && ch != '\0')
                            {
                                d = d + j * (ch - '0');
                                i++;
                                j = j / 10;
                                ch = ex[i];
                            }
                        }
                        num.Add(d);
                        break;
                }
                i++;
                if (i < ex.Count)
                    ch = ex[i];
            }
            number = Convert.ToString(num[0]);
            numberText.Text = number;
            isResult = true;
            ex.Clear();
        }

        private void Button_Click_Clean_All(object sender, RoutedEventArgs e)
        {
            expression = "";
            number = "";
            ex.Clear();
            op = false;
            parentheses = false;
            isResult = false;
            numberText.Text = "";
            expressionText.Text = "";
        }
    }
}
