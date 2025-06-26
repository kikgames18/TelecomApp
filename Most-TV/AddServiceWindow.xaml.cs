using System;
using System.Globalization;
using System.Windows;
using TelecomApp.Data;
using TelecomApp.Models;

namespace TelecomApp
{
    public partial class AddServiceWindow : Window
    {
        public AddServiceWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Введите название услуги");
                return;
            }

            if (!decimal.TryParse(FeeTextBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var fee))
            {
                MessageBox.Show("Введите корректную цену");
                return;
            }

            using var context = new TelecomContext();

            var service = new Service
            {
                Name = NameTextBox.Text,
                Description = DescriptionTextBox.Text,
                MonthlyFee = fee
            };

            context.Services.Add(service);
            context.SaveChanges();

            MessageBox.Show("Услуга добавлена");
            Close();
        }
    }
}
