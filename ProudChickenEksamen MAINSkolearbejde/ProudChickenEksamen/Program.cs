using ProudChickenEksamen.Controller;

Console.WriteLine();
Controller controller = new Controller();
controller.Run();




/*
 Database Connection : 
string databaseConnection()
{
string con = "Data Source=EAD2023-43;Initial Catalog=jakupDB;Integrated Security=True;";
string svar = "";
using (SqlConnection connection = new SqlConnection(con))
{
connection.Open();
using (SqlCommand command = new SqlCommand("SELECT * FROM jakupTable", connection))
{
using (SqlDataReader reader = command.ExecuteReader())
{
while (reader.Read())
{
var ID = reader.GetInt32(0);
var Name = reader.GetString(1);
svar += ID + ":" + Name + " - ";
}
}
}
}
return svar;
}

 */