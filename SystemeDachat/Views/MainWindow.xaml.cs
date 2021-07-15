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
using SystemeDachat.Logic;
using SystemeDachat.Views.UserControl;

namespace SystemeDachat
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Contenu.Content = new MenuPrincipal(Contenu); //Affichage du UserControl Menu Principal lors de la création du Main Window.
        }
    }
}
