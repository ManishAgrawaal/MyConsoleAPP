using System.Text.Json;
using MyConsoleApp.Models;

namespace MyConsoleApp.Services
{
    public class MedicineService
    {
        private readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "medicines.json");

        public List<Medicine> GetAll()
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }

            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Medicine>>(json) ?? new List<Medicine>();
        }

        public void Add(Medicine medicine)
        {
            var medicines = GetAll();
            medicines.Add(medicine);

            var json = JsonSerializer.Serialize(medicines, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }
    }
}