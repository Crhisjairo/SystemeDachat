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
using SystemeDachat.DB.Models;
using SystemeDachat.Models;

namespace SystemeDachat.Views.UserControl
{
    /// <summary>
    /// Logique d'interaction pour AchatReussi.xaml
    /// </summary>
    public partial class AchatReussi : System.Windows.Controls.UserControl
    {
        private String _paymentMethod;

        public AchatReussi(String paymentMethod)
        {
            _paymentMethod = paymentMethod;

            InitializeComponent();
            CreateBill();
        }

        private void CreateBill()
        {
            foreach (Product product in SystemeAchat.GetAllProducts())
            {
                txtBill.Text += $"\n{product.Name} - {product.Brand} - {product.Price}";
            }

            txtPaymentMethod.Text = _paymentMethod; // Méthode de payment dans la vue
        }
    }
}
