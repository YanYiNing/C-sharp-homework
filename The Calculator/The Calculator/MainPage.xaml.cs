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
        private string str;
        private List<double> value_list = new List<double>();
        private List<int> operator_list = new List<int>();
        private bool add_flag = false;
        private bool minus_flag = false;
        private bool multi_flag = false;
        private bool div_flag = false;
        private bool result_flag = false;
        private bool can_operate_flag = false;

        public MainPage()
        {
            
            this.InitializeComponent();
        }

        private void input(string num)
        {
            if (add_flag || minus_flag || multi_flag || div_flag || result_flag)
            {
                if (result_flag)
                {
                    ResultText.Text = "";
                }
                InputText.Text = "";
                add_flag = false;
                minus_flag = false;
                multi_flag = false;
                div_flag = false;
                result_flag = false;
            }
            if ((num.Equals(".") && ResultText.Text.IndexOf(".") < 0) || !num.Equals("."))
            {
                InputText.Text += num;
                ResultText.Text += num;
                can_operate_flag = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            input("1");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            input("2");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            input("3");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            input("4");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            input("5");
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            input("6");
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            input("7");
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            input("8");
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            input("9");
        }

        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            input("0");
        }

        private void Button_Click_Point(object sender, RoutedEventArgs e)
        {
            input(".");
        }

        private void Button_Click_Subtract(object sender, RoutedEventArgs e)
        {
            if (!minus_flag)
            {
                result_flag = false;
                value_list.Add(double.Parse(InputText.Text));
                operator_list.Add(1);
                ResultText.Text += "-";
                minus_flag = true;
                can_operate_flag = false;
            }
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            if (!add_flag)
            {
                result_flag = false;
                value_list.Add(double.Parse(InputText.Text));
                operator_list.Add(0);
                ResultText.Text += "+";
                add_flag = true;
                can_operate_flag = false;
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            operator_list.Clear();
            value_list.Clear();
            add_flag = false;
            minus_flag = false;
            multi_flag = false;
            div_flag = false;
            result_flag = false;
            can_operate_flag = false;
            InputText.Text = "";
            ResultText.Text = "";
        }

        private void Button_Click_Result(object sender, RoutedEventArgs e)
        {
            if (value_list.Count > 0 && operator_list.Count > 0 && can_operate_flag)
            {
                value_list.Add(double.Parse(InputText.Text));
                double total = value_list[0];
                for (int i = 0; i < operator_list.Count; i++)
                {
                    int _operator = operator_list[i];
                    switch (_operator)
                    {
                        case 0:
                            total += value_list[i + 1];
                            break;
                        case 1:
                            total -= value_list[i + 1];
                            break;
                        case 2:
                            total *= value_list[i + 1];
                            break;
                        case 3:
                            total /= value_list[i + 1];
                            break;
                    }
                }
                InputText.Text = total + "";
                ResultText.Text = total + "";
                operator_list.Clear();//算完，就清空累积数字与运算数组
                value_list.Clear();
                result_flag = true;
            }
        }

        private void Button_Click_Multiply(object sender, RoutedEventArgs e)
        {
            if (!multi_flag)
            {
                result_flag = false;
                value_list.Add(double.Parse(InputText.Text));
                operator_list.Add(2);
                ResultText.Text = "(" + ResultText.Text + ")" + "×";
                multi_flag = true;
                can_operate_flag = false;
            }
        }

        private void Button_Click_Divide(object sender, RoutedEventArgs e)
        {
            if (!div_flag)
            {
                result_flag = false;
                value_list.Add(double.Parse(InputText.Text));
                operator_list.Add(3);
                ResultText.Text = "(" + ResultText.Text + ")" + "÷";
                div_flag = true;
                can_operate_flag = false;
            }
        }
    }
}
