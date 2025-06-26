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
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Введите имя клиента");
                return;
            }

            using var context = new TelecomContext();

            var customer = new Customer
            {
                FullName = NameTextBox.Text,
                Email = EmailTextBox.Text,
                PhoneNumber = PhoneTextBox.Text
            };

            context.Customers.Add(customer);
            context.SaveChanges();

            MessageBox.Show("Клиент добавлен");
            Close();
        }
    }
}
