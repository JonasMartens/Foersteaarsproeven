using ProudChickenEksamen.Model;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

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
            var options = new JsonSerializerOptions()       // Tilføjer Danske bogstaver
            {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)

            };

            string json = JsonSerializer.Serialize(kunder, options);
            File.WriteAllText(filePath, json);
        }

    }
}
