using Main.Repositories;
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
using System.Windows.Shapes;

namespace Main.Other
{
    /// <summary>
    /// Логика взаимодействия для DepositWindow.xaml
    /// </summary>
    public partial class DepositWindow : Window
    {
        public DepositWindow()
        {
            InitializeComponent();
        }

        private void Close_Window(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ConfirmPay_Click(object sender, RoutedEventArgs e)
        {
            decimal money = Convert.ToDecimal(ValueBox.Text);
            if (money < 100)
            {
                try
                {
                    using(UnitOfWork context = new UnitOfWork())
                    {
                        context.UserRepository.SetPay(money);
                        App.SuccesLoad();
                    }
                }
                catch
                {

                }
            }
        }

        private void ValueBorder_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }
    }
}
