using ProudChickenEksamen.Model;
using System.Data.SqlClient;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace ProudChickenEksamen.Data
{
    class SQLRepository : IRepository
    {
        public string databaseConnection(string a)
        {
            string con = "Data Source=LAPTOP-U1TFVM09;Initial Catalog=Kunder;Integrated Security=True;";
            string svar = "";
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
                                string ID = reader.GetString(0);
                                string Name = reader.GetString(1);
                                svar += ID + " : " + Name + "\n";
                            }
                        }
                    }
                }
            }
            return svar;
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

        public void Insert()
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
                        $"INSERT INTO smsData(kommunekode, vejkode, vejadresseringsnavn, husnummer, smsType, smsDato) " +
                        "VALUES(@kommunekode, @vejkode, @vejadresseringsnavn, @husnummer, @smsType, @smsDato)", connection, transaction))
                    {
                        insertCommand.Parameters.AddWithValue("@kommunekode", 85);
                        insertCommand.Parameters.AddWithValue("@vejkode", 85);
                        insertCommand.Parameters.AddWithValue("@vejadresseringsnavn", "85");
                        insertCommand.Parameters.AddWithValue("@husnummer", "87");

                        insertCommand.Parameters.AddWithValue("@smsType", 85);
                        insertCommand.Parameters.AddWithValue("@smsDato", date);
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
