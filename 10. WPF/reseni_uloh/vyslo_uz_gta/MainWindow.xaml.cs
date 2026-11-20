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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sDen = txtDen.Text;
            string sMesic = txtMesic.Text;
            string sRok = txtRok.Text;

            int den, mesic, rok;

            if (!int.TryParse(sDen, out den))
            {
                // parsování neuspělo
                txtVystup.Text = "Neplatný vstup";
            } else if (!int.TryParse(sMesic, out mesic))
            {
                // parsování neuspělo
                txtVystup.Text = "Neplatný vstup";
            }
            else if (!int.TryParse(sRok, out rok))
            {
                // parsování neuspělo
                txtVystup.Text = "Neplatný vstup";
            }
            else
            {
                if (rok > 2026 || (rok == 2026 && mesic == 12))
                {
                    txtVystup.Text = "GTA VI vyšlo!";
                } else if (rok == 2026 && mesic == 11 && den >= 19)
                {
                    txtVystup.Text = "GTA VI vyšlo!";
                } else
                {
                    txtVystup.Text = "GTA VI NEvyšlo :(";
                }
            }
        }
    }
}