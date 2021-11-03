using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SystemeDachat.DB.Models;
using SystemeDachat.Models;
using SystemeDachat.Views.WindowsDialog;
using MessageBox = System.Windows.MessageBox;

namespace SystemeDachat.Views.UserControl
{
    /// <summary>
    /// Logique d'interaction pour EcranAchat.xaml
    /// </summary>
    public partial class EcranAchat : System.Windows.Controls.UserControl
    {

        public EcranAchat()
        {
            InitializeComponent();

            InitAvailableProductsList();
        }

        private void InitAvailableProductsList()
        {
            availableProducts.ItemsSource = SystemeAchat.GetAllProductsName();
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.RestartApp();
        }

        private void AjouterArticle_Click(object sender, RoutedEventArgs e)
        {
            string selectedProduct = availableProducts.SelectedItem.ToString(); //Récupère le produit selectionné
            
            Product productObject = SystemeAchat.SearchProduct(selectedProduct); //Cherche le produit dans le système

            //Si le produit n'existe pas, on affiche un message d'advertissement
            if (productObject == null)
            {
                productNotFoundView.Visibility = Visibility.Visible;
                productNotFoundView.SetProductName(selectedProduct);
                return;
            }

            productNotFoundView.Visibility = Visibility.Hidden; //On cache l'advertissement du produit pas trouvé précédement

            //Ajout du produit à la liste des produits du sytème
            SystemeAchat.AddProductToList(productObject);
            //Ajout de la view du produit à la liste productList
            productList.Items.Add(SystemeAchat.GetLastProductAdded().ProductControl); //Ajout du dernier produit à la liste dans la view

            //On permet au nouveau produit de mettre à jour la facture lorsqu'il sera effacé
            SystemeAchat.GetLastProductAdded().ProductControl.UpdateBill += UpdateBill;

            //Focus de la liste sur le dernier article ajouté
            productList.SelectedIndex = productList.Items.Count - 1;
            productList.ScrollIntoView(productList.SelectedItem);

            UpdateBill();
        }

        private void UpdateBill()
        {
            //On définie le soustotal dans la view
            subTotalTxt.Text = $"Subtotal: {SystemeAchat.SousTotal} $CA";
            //On définie le total dans la view
            totalTxt.Text = $"Total: {SystemeAchat.Total} $CA";
        }

        private void ProcederAuPaiement_Click(object sender, RoutedEventArgs e)
        {
            if (SystemeAchat.IsListEmpty)
            {
                MessageBox.Show("Veuillez ajouter au moins un article", "Articles manquantes"); //To custom
                return;
            }

            String paymentMethod = PaymentMethodWindows.Show().ToString(); //Recupère la valeur du type de payment

            //Changement du contenu de la fenêtre au AchatRéussi
            MainWindow.MainContentControl.Content = new AchatReussi(paymentMethod);



            //******Après un certain temps on remet le MenuPrincipal*******//
            WaitToRestartApp(5000);
        }

        private void WaitToRestartApp(int ms)
        {
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

            timer.Tick += new EventHandler(ResetApp);
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Start();
        }

        private static void ResetApp(object sender, EventArgs e)
        {
            //Appele à la fenêtre principal pour redéramerrer l'app
            MainWindow.RestartApp();

            System.Windows.Threading.DispatcherTimer timer = (System.Windows.Threading.DispatcherTimer)sender;
            timer.Stop();

        }

        private void Button_Aide(object sender, RoutedEventArgs e)
        {
            HelpWindows helpWin = new HelpWindows();
            helpWin.ShowDialog();
            
        }
    }

    internal class dispatcherTimer
    {
    }
}
