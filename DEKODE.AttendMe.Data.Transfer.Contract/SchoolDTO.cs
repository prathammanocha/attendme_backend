using System;

namespace DEKODE.AttendMe.Data.Transfer.Contract
{
    public class SchoolDTO
    {
        public Guid IdentityId { get; set; }
        public string Name { get; set; }
        public AddressDTO Address { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
    }
}
