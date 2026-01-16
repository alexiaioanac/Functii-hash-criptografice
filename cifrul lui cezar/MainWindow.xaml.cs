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

namespace cifrul_lui_cezar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void BtnCriptare_Click(object sender, RoutedEventArgs e)
        {
            
            TxtCezarResult.Text = Caesar.Encrypt(TxtCezarInput.Text);
        }

        private void BtnDecriptare_Click(object sender, RoutedEventArgs e)
        {
            TxtCezarResult.Text = Caesar.Decrypt(TxtCezarInput.Text);
        }

        private void BtnAnaliza_Click(object sender, RoutedEventArgs e)
        {
            TxtCezarResult.Text = Caesar.BruteForce(TxtCezarInput.Text);
        }
    }
}