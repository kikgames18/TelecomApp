using System;
using System.Windows;
using TelecomApp.Data;
using TelecomApp.Models;

namespace TelecomApp
{
    public partial class AddEmployeeWindow : Window
    {
        public AddEmployeeWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Проверка обязательного поля ФИО
            if (string.IsNullOrWhiteSpace(FullNameTextBox.Text))
            {
                MessageBox.Show("Введите ФИО сотрудника", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using var context = new TelecomContext();

            var employee = new Employee
            {
                Name = FullNameTextBox.Text,
                Position = PositionTextBox.Text,
                Email = EmailTextBox.Text,
                
            };

            context.Employees.Add(employee);
            context.SaveChanges();

            MessageBox.Show("Сотрудник успешно добавлен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
