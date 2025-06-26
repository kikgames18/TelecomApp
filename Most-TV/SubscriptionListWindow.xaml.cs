using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using TelecomApp.Data;
using TelecomApp.Models;

namespace TelecomApp
{
    public partial class SubscriptionListWindow : Window
    {
        private TelecomContext _context;

        public SubscriptionListWindow()
        {
            InitializeComponent();
            _context = new TelecomContext();
            LoadSubscriptions();
        }

        private void LoadSubscriptions()
        {
            // Загружаем подписки с подгрузкой связанных клиентов и услуг
            var subs = _context.Subscriptions
                .Include(s => s.Customer)
                .Include(s => s.Service)
                .ToList();

            SubscriptionsDataGrid.ItemsSource = subs;
        }

        private void DeleteSubscription_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Subscription subscription)
            {
                if (MessageBox.Show($"Удалить подписку клиента {subscription.Customer.FullName} на услугу {subscription.Service.Name}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    _context.Subscriptions.Remove(subscription);
                    _context.SaveChanges();
                    LoadSubscriptions();
                }
            }
        }

        private void SubscriptionsDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
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
