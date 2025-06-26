using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TelecomApp.Data;
using TelecomApp.Models;

namespace TelecomApp
{
    public partial class EmployeeListWindow : Window
    {
        private TelecomContext _context;

        public EmployeeListWindow()
        {
            InitializeComponent();
            _context = new TelecomContext();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            EmployeesDataGrid.ItemsSource = _context.Employees.ToList();
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Employee employee)
            {
                if (MessageBox.Show($"Удалить сотрудника {employee.Name}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                    LoadEmployees();
                }
            }
        }

        private void EmployeesDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
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

