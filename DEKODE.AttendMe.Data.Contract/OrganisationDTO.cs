using System;
using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Data.Contract
{
    public class OrganisationDTO
    {
        [Required]
        public Guid? Guid { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public virtual AddressDTO Address { get; set; }

        [Required]
        public string ContactName { get; set; }

        [Required]
        public string ContactPhone { get; set; }

        [Required]
        public string ContactEmail { get; set; }

        [Required]
        public string Website { get; set; }

        [Required]
        public int AccountId { get; set; }

        [Required]
        public int AccSbscrptnId { get; set; }
    }
}