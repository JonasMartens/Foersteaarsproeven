using ProudChickenEksamen.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProudChickenEksamen.Data
{
    class Repository
    {
        private readonly string filePath = "kunder.json";
        public List<Kunde> LoadKunder()
        {
            if (!File.Exists(filePath))
                return new List<Kunde>();
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Kunde>>(json) ?? new List<Kunde>();
        }
        public void SaveKunder(List<Kunde> kunder)
        {
            string json = JsonSerializer.Serialize(kunder, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
