using System.Collections.Generic;

namespace DEKODE.AttendMe.Data.Model.Entities
{

    // Use Entity Framework Core 5.0 In .NET Core 3.1 With MySQL Database By Code-First Migration On Visual Studio 2019 For RESTful API Application
    // https://www.c-sharpcorner.com/article/tutorial-use-entity-framework-core-5-0-in-net-core-3-1-with-mysql-database-by2/

    public class Account: TemporalEntityBase
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public string ABN { get; set; }
        public IList<Subscription> Subscriptions { get; set; }
    }
}
