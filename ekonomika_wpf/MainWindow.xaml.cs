using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ekonomika_wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Credit_sum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            //А = К * (П / (1 + П) - М - 1), где К – сумма кредита, П – процентная ставка, М – количество месяцев. 
            Console.WriteLine("AAAAAAAAAAAAAa"+Credit_sum.Text);
            if ((!String.IsNullOrEmpty(Credit_sum.Text)) && (!String.IsNullOrEmpty(procent.Text)))
            {
                 //Сумма кредита
                int credit_sum = int.Parse(Credit_sum.Text);
                //     Процент в числе(5 типо)
                double procent_double = double.Parse(procent.Text);
                //     ежемесечная
                double everyMounthProcent = procent_double / 100 / 12; 
                //Console.WriteLine(Start_date.SelectedDate.Value.Date);
                //DateTime date_of_issue = Start_date.SelectedDate.Value.Date;
                DateTime today = DateTime.Today;
                Console.WriteLine(today);
                // количество месяцев
                int Month_count = int.Parse(srok.Text);


                double S = credit_sum;
                double i = everyMounthProcent;
                int n = Month_count;

                //double result = S * (everyMounthProcent + everyMounthProcent / (Math.Pow(1 + everyMounthProcent, Month_count)) - 1); //????????
                double result = S * (i + i / ((Math.Pow(1 + i, n)) - 1)) * n;
                //Console.WriteLine();
                string result_str = String.Format("{0:0.00}", result);
                pereplata.Text = String.Format("{0:0.00}",result - S);
                Result.Text = result_str;
                
            }
            
        }
    }
}
