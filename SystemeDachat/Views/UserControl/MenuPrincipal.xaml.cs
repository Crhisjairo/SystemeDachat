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
using SystemeDachat.Logic;
using SystemeDachat.Views.Windows;

namespace SystemeDachat.Views.UserControl
{
    /// <summary>
    /// Logique d'interaction pour MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : System.Windows.Controls.UserControl
    {
        /// <summary>
        /// ContentControl de la fenêtre principal.
        /// </summary>
        private ContentControl _contenu; //À MODIFIER!!!!!!!

        public MenuPrincipal(ContentControl contenu)
        {
            InitializeComponent();
            _contenu = contenu; //À MODIFIER!!!!!!!
        }


        /// <summary>
        /// Arrête l'application
        /// </summary>
        private void ArreterApplication(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Button_Commencer(object sender, RoutedEventArgs e)
        {
            _contenu.Content = new EcranAchat(_contenu); //À MODIFIER!!!!!!!
        }

        private void Button_Aide(object sender, RoutedEventArgs e)
        {
            HelpWindows helpWin = new HelpWindows();
            helpWin.ShowDialog();
        }
    }
}
