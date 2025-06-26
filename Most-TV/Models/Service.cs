using System.Collections.Generic;

namespace TelecomApp.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal MonthlyFee { get; set; }
        public List<Subscription> Subscriptions { get; set; } = new();
    }
}
