
namespace DEKODE.AttendMe.Data.Model.Entities
{
    //[ComplexType]
    //[NotMapped]
    //[Owned]
    public class Address
    {
        public string StreetNo { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }

        //public bool HasValue
        //{
        //    get
        //    {
        //        return (StreetNo != null || StreetName != null || Suburb != null || State != null || PostCode != null || Country != null);
        //    }
        //}
    }
}
