using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Data.Contract
{
    public class AccountDTO
    {
        // Failed model validations using DataAnnotations - [Required]
        public Guid? Guid { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public AddressDTO Address { get; set; }

        [Required]
        public string ContactName { get; set; }

        [Required]
        public string ContactPhone { get; set; }

        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }

        public string ABN { get; set; }

        public string Website { get; set; }

        public bool IsActive { get; set; }
    }
}