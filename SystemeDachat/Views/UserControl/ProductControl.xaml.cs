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
    public delegate void UpdateBillHandler();

    /// <summary>
    /// Logique d'interaction pour ProductControl.xaml
    /// </summary>
    public partial class ProductControl : System.Windows.Controls.UserControl
    {
        public event UpdateBillHandler UpdateBill;

        private Product _product;

        public ProductControl(Product product)
        {
            _product = product;

            InitializeComponent();
            SetFields();
        }

        private void SetFields()
        {
            //ProductImage.Source = _product.Img;
            ProductName.Text = _product.Name;
            ProductDescription.Text = _product.Description;
            ProductBrand.Text = _product.Brand;
            ProductPrice.Text = _product.Price + "$CA";
        }


        private void RemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            //On le supprime du système
            SystemeAchat.RemoveProductFromList(_product);

            //On demande de mettre à jour la facture
            UpdateBill();

            //On le supprime de la view
            ListBox listBox = this.Parent as ListBox;
            listBox.Items.Remove(this);
        }
    }
}
