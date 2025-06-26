using System;

namespace TelecomApp.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; }
    }
}