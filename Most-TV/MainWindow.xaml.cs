using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using TelecomApp.Data;
using TelecomApp.Models;

namespace TelecomApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowCustomers_Click(object sender, RoutedEventArgs e)
        {
            using var context = new TelecomContext();
            dataGrid.ItemsSource = context.Customers.ToList();
        }

        private void ShowServices_Click(object sender, RoutedEventArgs e)
        {
            using var context = new TelecomContext();
            dataGrid.ItemsSource = context.Services.ToList();
        }

        private void ShowSubscriptions_Click(object sender, RoutedEventArgs e)
        {
            using var context = new TelecomContext();
            var subs = context.Subscriptions.Include(s => s.Customer).Include(s => s.Service).ToList();
            dataGrid.ItemsSource = subs.Select(s => new
            {
                s.Id,
                Customer = s.Customer.FullName,
                Service = s.Service.Name,
                s.StartDate,
                s.IsActive
            }).ToList();
        }

        private void ShowEmployees_Click(object sender, RoutedEventArgs e)
        {
            using var context = new TelecomContext();
            dataGrid.ItemsSource = context.Employees.ToList();
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new AddCustomerWindow();
            wnd.ShowDialog();
        }

        private void AddService_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new AddServiceWindow();
            wnd.ShowDialog();
        }

        private void AddSubscription_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new AddSubscriptionWindow();
            wnd.ShowDialog();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var wnd = new AddEmployeeWindow();
            wnd.ShowDialog();
        }

        private void ShowHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Приложение TelecomApp.\n\n" +
                "Просмотр данных: клиенты, услуги, подписки, сотрудники.\n" +
                "Добавление новых записей через соответствующее меню.\n" +
                "Разработано: Герман Максимов", "Справка");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
