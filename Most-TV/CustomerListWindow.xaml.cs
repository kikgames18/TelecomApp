using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TelecomApp.Data;
using TelecomApp.Models;

namespace TelecomApp
{
    public partial class CustomerListWindow : Window
    {
        private TelecomContext _context;

        public CustomerListWindow()
        {
            InitializeComponent();
            _context = new TelecomContext();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            CustomersDataGrid.ItemsSource = _context.Customers.ToList();
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Customer customer)
            {
                if (MessageBox.Show($"Удалить клиента {customer.FullName}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    _context.Customers.Remove(customer);
                    _context.SaveChanges();
                    LoadCustomers();
                }
            }
        }

        private void CustomersDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            _context.SaveChanges();
        }

        protected override void OnClosed(System.EventArgs e)
        {
            _context.Dispose();
            base.OnClosed(e);
        }
    }
}
