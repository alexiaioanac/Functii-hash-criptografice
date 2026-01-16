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

namespace cifrul_n
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void BtnCriptare_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(TxtN.Text);
            TxtResult.Text = cifrul_n.Encrypt(TxtInput.Text, n);
        }

        private void BtnDecriptare_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(TxtN.Text);
            TxtResult.Text = cifrul_n.Decrypt(TxtInput.Text, n);
        }

        private void BtnAnaliza_Click(object sender, RoutedEventArgs e)
        {
            TxtResult.Text = cifrul_n.BruteForce(TxtInput.Text);
        }
    }
}