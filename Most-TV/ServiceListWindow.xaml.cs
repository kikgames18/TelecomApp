using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TelecomApp.Data;
using TelecomApp.Models;

namespace TelecomApp
{
    public partial class ServiceListWindow : Window
    {
        private TelecomContext _context;

        public ServiceListWindow()
        {
            InitializeComponent();
            _context = new TelecomContext();
            LoadServices();
        }

        private void LoadServices()
        {
            ServicesDataGrid.ItemsSource = _context.Services.ToList();
        }

        private void DeleteService_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Service service)
            {
                if (MessageBox.Show($"Удалить услугу {service.Name}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    _context.Services.Remove(service);
                    _context.SaveChanges();
                    LoadServices();
                }
            }
        }

        private void ServicesDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
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
