using ContactCatalog88.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace ContactCatalog88.Services;

    public class FileStorage
    {
        private readonly string _filePath = "contacts.json";

        public void Save(List<Contact> contacts)
        {
            var json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    public void ExportCsv(List<Contact> contacts, string filePath)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Id,Name,Email,Phone,Tags");
        foreach (var c in contacts)
        {
            var tags = string.Join('|', c.Tags);
            sb.AppendLine($"{c.Id},{c.Name},{c.Email},{c.Phone},{tags}");
        }
        File.WriteAllText(filePath, sb.ToString());
    }
    public List<Contact> Load()
        {
            if (!File.Exists(_filePath))
                return new List<Contact>();

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
        }
    }
