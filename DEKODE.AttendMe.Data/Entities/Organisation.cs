using System.Collections.Generic;

namespace DEKODE.AttendMe.Data.Model.Entities
{
    public class Organisation : TemporalEntityBase
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }
        public IList<User> Users { get; set; }
        public IList<AppDevice> Devices { get; set; }
    }
}
