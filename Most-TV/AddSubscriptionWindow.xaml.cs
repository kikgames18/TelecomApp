using System;
using System.Linq;
using System.Windows;
using TelecomApp.Data;
using TelecomApp.Models;

namespace TelecomApp
{
    public partial class AddSubscriptionWindow : Window
    {
        public AddSubscriptionWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using var context = new TelecomContext();
            CustomerComboBox.ItemsSource = context.Customers.ToList();
            ServiceComboBox.ItemsSource = context.Services.ToList();
            StartDatePicker.SelectedDate = DateTime.Now;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите клиента");
                return;
            }
            if (ServiceComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите услугу");
                return;
            }
            if (StartDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату начала");
                return;
            }

            using var context = new TelecomContext();

            var subscription = new Subscription
            {
                CustomerId = (int)CustomerComboBox.SelectedValue,
                ServiceId = (int)ServiceComboBox.SelectedValue,
                StartDate = StartDatePicker.SelectedDate.Value.ToUniversalTime(), // <-- исправлено здесь
                IsActive = true
            };

            context.Subscriptions.Add(subscription);
            context.SaveChanges();

            MessageBox.Show("Подписка добавлена");
            Close();
        }

    }
}
