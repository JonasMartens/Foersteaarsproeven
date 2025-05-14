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

        public void Insert();

        public void Update();

        public void Delete();

        public void Read();
    }
}
