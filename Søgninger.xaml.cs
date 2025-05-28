using ProudChickenEksamen.Controller;
using ProudChickenEksamen.Data;
using ProudChickenEksamen.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace ProudChickenEksamenProjektWPFMain
{
    /// <summary>
    /// Interaction logic for Søgninger.xaml
    /// </summary>
    public partial class Søgninger : Window
    {
        IRepository repository;
        Controller controller;
        public Søgninger()
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
        string datoValg;

        private void OpdaterValg()
        {
            if (By.IsChecked == true)
            {
                områdeNrBy = "MyndighedsNavn";
            }
            if (OmrådeNr.IsChecked == true)
            {
                områdeNrBy = "PostNummer";
            }
            if (Dato.IsChecked == true)
            {
                områdeNrBy = "SmsDato";
            }
        }
        List<Kunde> data;
        private List<Kunde> LoadData()
        {
            data = new List<Kunde>();

            string connectionString = @"Data Source=LAPTOP-U1TFVM09;Initial Catalog=Kunder;Integrated Security=True;";
            string column;
            if (områdeNrBy == "MyndighedsNavn")
            {
                column = "MyndighedsNavn";
            }
            else if (områdeNrBy == "PostNummer")
            {
                column = "PostNummer";
            }
            else
            {
                column = "SmsDato";
            }

            string query = $"SELECT DISTINCT KontaktID, Navn, MyndighedsNavn, PostNummer FROM KontaktView WHERE {column} = @value";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (områdeNrBy == "MyndighedsNavn")
                {

                    if (string.IsNullOrEmpty(StedValg.Text))
                    {
                       
                        MessageBox.Show($"Indtast venligst et gyldigt {column}.");
                        return data;                       
                    }
                    else
                    { 
                        cmd.Parameters.AddWithValue("@value", StedValg.Text); 
                    }

                }
                else
                {
                    if (int.TryParse(StedValg.Text, out int postnummer))
                    {
                        cmd.Parameters.AddWithValue("@value", postnummer);
                    }
                    else
                    {
                        MessageBox.Show($"Indtast venligst et gyldigt {column}.");
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

        private void TilbageKnappen(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
        }

        private void Dato_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
