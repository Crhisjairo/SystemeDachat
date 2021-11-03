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
using SystemeDachat.DB;
using SystemeDachat.Models;
using SystemeDachat.Views.UserControl;

namespace SystemeDachat
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// ContentControl qui est modifié par les UserControls.
        /// </summary>
        public static ContentControl MainContentControl;

        public MainWindow()
        {
            InitializeComponent();

            MainContentControl = RootContentControl;

            //Affichage du UserControl MenuPrincipal lors de la création du MainWindow.
            RootContentControl.Content = new MenuPrincipal(); 
        }

        public static void RestartApp()
        {
            //Réinitialisation de la view
            MainContentControl.Content = new MenuPrincipal();

            //Réinitialisation du model (le système)
            SystemeAchat.RestartSystem();
        }
    }
}
