using ProudChickenEksamen.Model;
using System.Data.SqlClient;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProudChickenEksamen.Data
{
    class SQLRepository : IRepository
    {
        public List<Kunde> databaseConnection(string a)
        {
            string con = "Data Source=LAPTOP-U1TFVM09;Initial Catalog=Kunder;Integrated Security=True;";
            string svar = "";
            List<Kunde> KundeKontaktOplysninger = new List<Kunde>();
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(a, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0) && !reader.IsDBNull(1))
                            {
                                int ID = reader.GetInt32(0);
                                string Name = reader.GetString(1);
                                Kunde kunder = new Kunde() { id = ID, navn = Name};
                                KundeKontaktOplysninger.Add(kunder);
                                int i = 0;
                                while (i < KundeKontaktOplysninger.Count)
                                {
                                    Console.WriteLine(KundeKontaktOplysninger[i]);
                                    i++;
                                }

                                //svar += ID + " : " + Name + "\n";
                            }
                        }
                    }
                }
            }
            return KundeKontaktOplysninger;
        }
        public void Delete()
        {
            string connectionString = @"Data Source=LAPTOP-U1TFVM09;Initial Catalog=Kunder;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    using (SqlCommand deleteCommand = new SqlCommand("DELETE FROM TING", connection, transaction))
                    {
                        deleteCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        public void Insert(int smsType)
        {
            string connectionString = @"Data Source=LAPTOP-U1TFVM09;Initial Catalog=Kunder;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    DateTime date = DateTime.Now;
                    using (SqlCommand insertCommand = new SqlCommand(
                        $"INSERT INTO SmsBeskeder (smsType, smsDato) VALUES({smsType}, CAST(GETDATE() AS DATE));", connection, transaction))
                    {
                        insertCommand.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

            public void InsertSmsKontakter(int smsID, List<int> kontaktIDListe)
        {
            string connectionString = @"Data Source=LAPTOP-U1TFVM09;Initial Catalog=Kunder;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int i = 0;
                while (i < kontaktIDListe.Count)
                {
                    int kontaktID = kontaktIDListe[i];

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO SmsKontakt (smsID, kontaktID) VALUES (@smsID, @kontaktID)", connection))
                    {
                        cmd.Parameters.AddWithValue("@smsID", smsID);
                        cmd.Parameters.AddWithValue("@kontaktID", kontaktID);

                        cmd.ExecuteNonQuery();
                    }

                    i++;
                }
            }
        }
        


        public string Read(int a)
        {
            string b = "";
            if (a == 1)
            {
                b = "SELECT VejAdresseringsNavn, HusNummer FROM Lokalitet WHERE VejAdresseringsNavn LIKE '%Svalevej%'";
            }
            return b;
        }


        public void Update()
        {
            throw new NotImplementedException();
        }        
        
        


        
        
        public List<Kunde> LoadKunder()
        {
            throw new NotImplementedException();
        }

        public void SaveKunder(List<Kunde> kunder)
        {
            throw new NotImplementedException();
        }
    }
}
