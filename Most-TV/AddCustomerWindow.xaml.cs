using System;
using System.Windows;
using TelecomApp.Data;
using TelecomApp.Models;

namespace TelecomApp
{
    public partial class AddCustomerWindow : Window
    {
        public AddCustomerWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FullNameTextBox.Text))
            {
                MessageBox.Show("Введите ФИО");
                return;
            }

            using var context = new TelecomContext();

            var customer = new Customer
            {
                FullName = FullNameTextBox.Text,
                Email = EmailTextBox.Text,
                PhoneNumber = PhoneTextBox.Text,
                RegistrationDate = DateTime.UtcNow  // Здесь исправлено
            };

            context.Customers.Add(customer);
            context.SaveChanges();

            MessageBox.Show("Клиент добавлен");
            Close();
        }
    }
}
