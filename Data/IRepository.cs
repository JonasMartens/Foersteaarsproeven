using ProudChickenEksamen.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace ProudChickenEksamen.Data
{
    internal interface IRepository
    {
        public List<Kunde> LoadKunder();

        public void SaveKunder(List<Kunde> kunder);

        public void Insert(int smsType);

        public void InsertSmsKontakter(int smsID, List<int> kontaktIDListe);
        public void Update();

        public void Delete();

        public string Read(int a);
        List<Kunde> databaseConnection(string v);
    }
}
