using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace EmrsTool
{
public class PhoneDatabaseService
{
public List<PhoneModel> LoadPhones(string filePath)
{
if (!File.Exists(filePath))
return new List<PhoneModel>();

        string json = File.ReadAllText(filePath);

        return JsonSerializer.Deserialize<List<PhoneModel>>(json)
               ?? new List<PhoneModel>();
    }

    public List<PhoneModel> SearchPhones(
        List<PhoneModel> phones,
        string searchText)
    {
        if (string.IsNullOrWhiteSpace(searchText))
            return phones;

        return phones.Where(phone =>
            phone.Brand.Contains(searchText,
                StringComparison.OrdinalIgnoreCase) ||
            phone.Model.Contains(searchText,
                StringComparison.OrdinalIgnoreCase) ||
            phone.ModelNumber.Contains(searchText,
                StringComparison.OrdinalIgnoreCase) ||
            phone.Chipset.Contains(searchText,
                StringComparison.OrdinalIgnoreCase)
        ).ToList();
    }
}

}
