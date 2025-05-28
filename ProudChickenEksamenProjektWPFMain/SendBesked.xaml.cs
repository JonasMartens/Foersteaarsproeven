using ProudChickenEksamen.Controller;
using ProudChickenEksamen.Data;
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
using System.Windows.Shapes;

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
        
        public void Button_Click(object sender, RoutedEventArgs e)
        {

            EmailEllerSmsBool = "";
            ByEllerOmraadeNrBool = "";
            if (Sms.IsChecked == true)
            {
                EmailEllerSmsBool = "sms";
            }
            else if (Email.IsChecked == true)
            {
                EmailEllerSmsBool = "email";
            }

            ByEllerOmraadeNrBool = "";
            if (By.IsChecked == true)
            {
                ByEllerOmraadeNrBool = "By";
            }
            else if (OmrådeNr.IsChecked == true)
            {
                ByEllerOmraadeNrBool = "OmrådeNr";
            }
            LoadData();

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem = MyListBox.SelectedItem as string;
            MessageBox.Show("You selected: " + selectedItem);

        }
        string EmailEllerSmsBool;
        string ByEllerOmraadeNrBool;
       



        private void LoadData()
        {
            List<Person> data = new List<Person>();

            string connectionString = "Data Source=DESKTOP-P3H4BQQ\\MSSQLSERVER04;Initial Catalog=Kunder;Integrated Security=True;TrustServerCertificate=True;";
            string EmailEllerSMS = "";
            string ByEllerOmraadeNr = "";
            //if (EmailEllerSmsBool == "email")
            //{
            //    EmailEllerSMS = "email";
            //}
            //else
            //{
            //    EmailEllerSMS = "sms";
            //}
            if (ByEllerOmraadeNrBool == "By")
            {
                EmailEllerSMS = "By";
            }
            else
            {
                EmailEllerSMS = "OmrådeNr";
            }


            string query = $"SELECT * FROM Person WHERE {EmailEllerSMS} = {StedValg.Text}"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    data.Add(new Person
                    {
                        Id = (int)reader["Id"],
                        Adresse = reader["Adresse"].ToString(),
                        OmrådeNR = reader["OmrådeNr"].ToString(),
                    });
                    // Immer das gleiche anzeigen?
                    //
                    //data.Add(reader["VejKode"].ToString());
                    MyListBox.ItemsSource = data;
                    MyListBox.DisplayMemberPath = "DisplayText"; // VISER NU ALT - ID, Adresse, OmrådeNr
                    
                }
            }

            MyListBox.ItemsSource = data;
        }

        
    }
}
