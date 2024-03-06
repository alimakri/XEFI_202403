using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using WpfApp1_Demo1.ViewModels;

namespace WpfApp1_Demo1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Onglet3Couleur.Background = new SolidColorBrush(Colors.Red);
        }

        private void Button_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Onglet3Couleur.Background = new SolidColorBrush(Colors.Green);
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Onglet3Couleur.Background = new SolidColorBrush(Colors.Yellow);

        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Onglet3Couleur.Background = new SolidColorBrush(Colors.Pink);
        }
    }
}
