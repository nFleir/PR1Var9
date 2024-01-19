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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string operation = "";
        private double x;
        private double p;
        private double answer;
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение выхода", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                base.OnClosing(e);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void EnterX_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (EnterX.Text == "Введите х")
                EnterX.Clear();
        }

        private void EnterP_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (EnterP.Text == "Введите p")
                EnterP.Clear();
        }

        private void PressSH_Click(object sender, RoutedEventArgs e)
        {
            operation = PressSH.Content.ToString();
        }

        private void xVkvadrate_Click(object sender, RoutedEventArgs e)
        {
            operation = xVkvadrate.Content.ToString();
        }

        private void eVikse_Click(object sender, RoutedEventArgs e)
        {
            operation = eVikse.Content.ToString();
        }

        private void calculateAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (Double.TryParse(EnterX.Text.Replace('.', ','), out x))
            {

            }
            else
            {
                EnterX.Text = "Введите х";
                MessageBox.Show("х должно быть числом!", "Тип числа Х", MessageBoxButton.OK, MessageBoxImage.Error);
                answer = 0;
                x = 0;
                p = 0;
                PrintAnswer.Text = answer.ToString();
                return;
            }
            if (Double.TryParse(EnterP.Text.Replace('.', ','), out p))
            {

            }
            else
            {
                EnterP.Text = "Введите p";
                MessageBox.Show("p должно быть числом!", "Тип числа P", MessageBoxButton.OK, MessageBoxImage.Error);
                answer = 0;
                x = 0;
                p = 0;
                PrintAnswer.Text = answer.ToString();
                return;
            }
            if (x > Math.Abs(p))
            {
                x = GetXFromOperation(operation);
                answer = 2 * Math.Pow(x, 3) + 3 * Math.Pow(p, 2);
                x = 0;
                p = 0;
                EnterX.Text = "Введите х";
                EnterP.Text = "Введите p";
                PrintAnswer.Text = answer.ToString();
            }
            else if (3 < x && x < Math.Abs(p))
            {
                x = GetXFromOperation(operation);
                answer = Math.Abs(x - p);
                x = 0;
                p = 0;
                EnterX.Text = "Введите х";
                EnterP.Text = "Введите p";
                PrintAnswer.Text = answer.ToString();
            }
            else if (x == Math.Abs(p))
            {
                x = GetXFromOperation(operation);
                answer = Math.Pow((x-p), 2);
                x = 0;
                p = 0;
                EnterX.Text = "Введите х";
                EnterP.Text = "Введите p";
                PrintAnswer.Text = answer.ToString();
            }
            else
            {
                x = 0;
                p = 0;
                EnterX.Text = "Введите х";
                EnterP.Text = "Введите p";
                MessageBox.Show("Данные не подходят ни под одно условие", "Результат", MessageBoxButton.OK, MessageBoxImage.Warning);
                PrintAnswer.Text = answer.ToString();
                answer = 0;
                return;
            }
        }

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            x = 0;
            p = 0;
            operation = "";
            answer = 0;
            PrintAnswer.Text = answer.ToString();
            EnterX.Text = "Введите х";
            EnterP.Text = "Введите p";
            PressSH.IsChecked = false;
            xVkvadrate.IsChecked = false;
            eVikse.IsChecked = false;
        }
        private double GetXFromOperation(string operation)
        {
            switch (operation)
            {
                case "sh(x)":
                    x = (Math.Pow(Math.E, x) - Math.Pow(Math.E, -x)) / 2;
                    break;
                case "x^2":
                    x = Math.Pow(x, 2);
                    break;
                case "e^x":
                    x = Math.Pow(Math.E, x);
                    break;
                case "":
                    MessageBox.Show("Выберите Преобразование Х", "Преобразование Х", MessageBoxButton.OK, MessageBoxImage.Error);
                    x = 0;
                    p = 0;
                    answer = 0;
                    break;
            }
            return x;
        }
    }
}
