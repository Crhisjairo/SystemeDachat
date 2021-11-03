using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SystemeDachat.Views.WindowsDialog
{
    /// <summary>
    /// Logique d'interaction pour PaymentMethodWindows.xaml
    /// </summary>
    public partial class PaymentMethodWindows : Window
    {
        private static PaymentMethodWindows paymentWin;
        private static PaymentMethod result;

        public enum PaymentMethod
        {
            Cash,
            DebitOrCredit
        }

        public PaymentMethodWindows()
        {
            InitializeComponent();
        }

        public static PaymentMethod Show()
        {
            paymentWin = new PaymentMethodWindows();

            paymentWin.ShowDialog();
            return result;
        }

        private void Cash_Click(object sender, RoutedEventArgs e)
        {
            result = PaymentMethod.Cash;
            paymentWin.Close();
        }

        private void CreditDebit_Click(object sender, RoutedEventArgs e)
        {
            result = PaymentMethod.DebitOrCredit;
            paymentWin.Close();
        }
    }
}
