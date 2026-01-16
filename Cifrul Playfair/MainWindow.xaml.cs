using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cifrul_Playfair
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void BtnCriptare_Click(object sender, RoutedEventArgs e)
        {
            Playfair.GenereazaMatrice(TxtCheie.Text);
            TxtResult.Text = Playfair.Proceseaza(TxtInput.Text, true);
        }

        private void BtnDecriptare_Click(object sender, RoutedEventArgs e)
        {
            Playfair.GenereazaMatrice(TxtCheie.Text);
            TxtResult.Text = Playfair.Proceseaza(TxtInput.Text, false);
        }
    }
}