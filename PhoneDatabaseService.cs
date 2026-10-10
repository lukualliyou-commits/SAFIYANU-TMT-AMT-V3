
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EmrsTool
{
    public partial class PhoneDatabaseWindow : Window
    {
        private List<PhoneModel> allPhones = new();

        public PhoneDatabaseWindow()
        {
            InitializeComponent();
            LoadPhoneDatabase();
        }

        private void LoadPhoneDatabase()
        {
            string filePath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Data",
                "phones.json"
            );

            var service = new PhoneDatabaseService();
            allPhones = service.LoadPhones(filePath);
            PhoneGrid.ItemsSource = allPhones;
        }

        private void SearchBox_TextChanged(
            object sender,
            TextChangedEventArgs e)
        {
            string search = SearchBox.Text.Trim();

            PhoneGrid.ItemsSource = allPhones
                .Where(p =>
                    p.Brand.Contains(search,
                        StringComparison.OrdinalIgnoreCase) ||
                    p.Model.Contains(search,
                        StringComparison.OrdinalIgnoreCase) ||
                    p.ModelNumber.Contains(search,
                        StringComparison.OrdinalIgnoreCase) ||
                    p.Chipset.Contains(search,
                        StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
