using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Data.Contract
{
    public class AddressDTO
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
    }
}