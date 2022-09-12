using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyPt
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private decimal firstNum;
        private string opName;
        private bool isOpClicked;

        private void BtnOne_Clicked(object sender, EventArgs e)
        {
            LblResult.Text = "1";
        }
        private void BtnCommon_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if(LblResult.Text == "0" || isOpClicked)
            {
                isOpClicked = false;//пампам
                LblResult.Text = button.Text;
            }
            else
            {
                LblResult.Text += button.Text;
            }
        }

        private void BtnClear_Clicked(object sender, EventArgs e)
        {
            LblResult.Text = "0";
            isOpClicked = false;//тарапамапам
            firstNum = 0;//пам

        }

        private void BtnDel_Clicked(object sender, EventArgs e)
        {
            string number = LblResult.Text;
            if(number != "0")
            {
                number = number.Remove(number.Length - 1, 1);
                if (string.IsNullOrEmpty(number))
                {
                    LblResult.Text = "0";
                }
                else
                {
                    LblResult.Text = number;
                }
            }
        }
        private void BtnComOp_Clicked(object sender, EventArgs e)//зачем это нужно и что здесь происходит, зачем мы создали три переменных разных типов
        {
            var button = sender as Button;
            isOpClicked = true;
            opName = button.Text;
            firstNum = Convert.ToDecimal(LblResult);
        }

        private void BtnRavno_Clicked(object sender, EventArgs e)
        {
            try
            {
                decimal secNum = Convert.ToDecimal(LblResult);
                string finResult = Calculate(firstNum,secNum).ToString("0.##");
                LblResult.Text = finResult;
            }
            catch(Exception ex)
            {
                DisplayAlert("Всё ... давай по новой", ex.Message, "Лады");//в случае исключений выводит ошибку
            }
        }
        public decimal Calculate (decimal firstNum,decimal secNum)//сама функция вычисленния
        {
            decimal result =0;
            if(opName =="+")
            {
                result = firstNum + secNum;
            }
            else if (opName == "-")
            {
                result = firstNum - secNum;
            }
            else if (opName == "*")
            {
                result = firstNum * secNum;
            }
            else if (opName == "/")
            {
                result = firstNum / secNum;
            }
            return result;
        }
    }
}
