using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Api.Model.Entities
{
    //[ComplexType]
    // [NotMapped]
    //[Owned]
    public class Address
    {
        [Required]
        public string StreetNo { get; set; }

        [Required]
        public string StreetName { get; set; }

        [Required]
        public string Suburb { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
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