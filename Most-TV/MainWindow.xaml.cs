using System.Windows;

namespace TelecomApp
{
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            new AddCustomerWindow().ShowDialog();
        }

        private void AddSubscription_Click(object sender, RoutedEventArgs e)
        {
            new AddSubscriptionWindow().ShowDialog();
        }

        private void ShowCustomers_Click(object sender, RoutedEventArgs e)
        {
            new CustomerListWindow().ShowDialog();
        }

        private void ShowSubscriptions_Click(object sender, RoutedEventArgs e)
        {
            new SubscriptionListWindow().ShowDialog();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            new AddEmployeeWindow().ShowDialog();
        }

        private void ShowEmployees_Click(object sender, RoutedEventArgs e)
        {
            new EmployeeListWindow().ShowDialog();
        }

        private void ShowServices_Click(object sender, RoutedEventArgs e)
        {
            new ServiceListWindow().ShowDialog();
        }

        private void AddService_Click(object sender, RoutedEventArgs e)
        {
            new AddServiceWindow().ShowDialog();
        }
    }
}
