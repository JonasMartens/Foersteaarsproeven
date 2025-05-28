using ProudChickenEksamen.Controller;
using ProudChickenEksamen.Data;
using ProudChickenEksamen.Model;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace ProudChickenEksamenProjektWPFMain
{
    /// <summary>
    /// Interaction logic for SendBesked.xaml
    /// </summary>
    public partial class SendBesked : Window
    {
        IRepository repository;
        Controller controller;
        public SendBesked()
        {
            InitializeComponent();
            repository = new SQLRepository();
            controller = new Controller(repository);            
        }
        public void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var ComboBox = sender as ComboBox;
            ComboBox.ItemsSource = controller.SkafSmsListe();
            ComboBox.DisplayMemberPath = "StandardBesked";
            ComboBox.SelectedIndex = 0;
        }

        string smsEmail;
        string områdeNrBy;

        private void OpdaterValg()
        {
            if (By.IsChecked == true)
            {
                områdeNrBy = "MyndighedsNavn";
            }
            else if (OmrådeNr.IsChecked == true)
            {
                områdeNrBy = "PostNummer";
            }
        }
        private void SendBeskedKnappen(object sender, RoutedEventArgs e)
        {
            smsEmail = "";
            if (Sms.IsChecked == true)
            {
                smsEmail = "sms";
            }
            else if (Email.IsChecked == true)
            {
                smsEmail = "email";
            }     

            string stedValg = StedValg.Text;

            var beskedValg = BeskedType.SelectedItem as SMS;
            int beskedId = beskedValg.ID;

            string Bekræft = $"Vil du sende {smsEmail}type: {beskedId} til {stedValg}?";

            MessageBoxResult resultat = MessageBox.Show(Bekræft, "Bekræft Valg", MessageBoxButton.OKCancel);

            if (resultat == MessageBoxResult.OK)
            {
                controller.OpdaterKontaktSammenlægning(beskedId, data);
                controller.InsertSmsTypeOgDatoTilDatabase(beskedId);
                string SvarSendt = $" Du har sendt {smsEmail}type: {beskedId} til {stedValg}.";
                MessageBox.Show(SvarSendt, "Beskeden er sendt.", MessageBoxButton.OK);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Hide();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TilbageKnappen(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }
        List<Kunde> data;
        private List<Kunde> LoadData()
        {
            data = new List<Kunde>();

            string connectionString = @"Data Source=LAPTOP-U1TFVM09;Initial Catalog=Kunder;Integrated Security=True;";
            string column = områdeNrBy == "MyndighedsNavn" ? "MyndighedsNavn" : "PostNummer";

            string query = $"SELECT DISTINCT KontaktID, Navn, MyndighedsNavn, PostNummer FROM KontaktView WHERE {column} = @value";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (områdeNrBy == "MyndighedsNavn")
                {
                    cmd.Parameters.AddWithValue("@value", StedValg.Text);
                }
                else
                {
                    if (int.TryParse(StedValg.Text, out int postnummer))
                    {
                        cmd.Parameters.AddWithValue("@value", postnummer);
                    }
                    else
                    {
                        MessageBox.Show("Indtast venligst et gyldigt postnummer.");
                        return data;
                    }
                }

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    data.Add(new Kunde
                    {
                        ID = (int)reader["KontaktID"],
                        Navn = reader["Navn"].ToString(),
                        MyndighedsNavn = reader["MyndighedsNavn"].ToString(),
                        OmrådeNr = reader["PostNummer"].ToString(),
                    });
                }
            }

            MyListBox.ItemsSource = null;
            MyListBox.ItemsSource = data;
            MyListBox.DisplayMemberPath = "DisplayText";
            return data;
        }

        private void VisKundeListe(object sender, RoutedEventArgs e)
        {
            OpdaterValg();
            LoadData();
        }
    }
}
