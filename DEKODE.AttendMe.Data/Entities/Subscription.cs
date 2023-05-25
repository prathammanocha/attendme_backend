using System.Collections.Generic;

namespace DEKODE.AttendMe.Data.Model.Entities
{
    public class Subscription: TemporalEntityBase
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int DevicesAllowed { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public IList<Organisation> Organisations { get; set; }
    }
}
