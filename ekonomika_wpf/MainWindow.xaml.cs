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

                int Month_count = int.Parse(srok.Text) * 12;

                double x = Math.Pow(1+ everyMounthProcent, Month_count);

                double monthly = (credit_sum * x * everyMounthProcent) /  (x - 1);

                double monthlyPayments = monthly;
                double totalPayment = monthly * Month_count;
                double totalInterest = (monthly * Month_count) - credit_sum;




                string result_str = String.Format("{0:0.00}", totalPayment);
                pereplata.Text = String.Format("{0:0.00}",totalInterest);
                mounthlyPayment.Text = String.Format("{0:0.00}", monthlyPayments);
                Result.Text = result_str;
                
            }
            
        }
    }
}
