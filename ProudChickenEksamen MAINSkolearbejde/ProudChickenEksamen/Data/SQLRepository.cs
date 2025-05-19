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
            throw new NotImplementedException();
        }

        public void Insert()
        {
            throw new NotImplementedException();
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
