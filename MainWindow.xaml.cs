using ProudChickenEksamen.Controller;
using ProudChickenEksamen.Data;
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

namespace ProudChickenEksamenProjektWPFMain
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IRepository repository;
        Controller controller;
        public MainWindow()
        {
            InitializeComponent();
            repository = new SQLRepository();
            controller = new Controller(repository);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SendBesked sendBesked = new SendBesked();
            sendBesked.Show();
            Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Søgninger søgning = new Søgninger();
            søgning.Show();
            Hide();
        }
    }
}