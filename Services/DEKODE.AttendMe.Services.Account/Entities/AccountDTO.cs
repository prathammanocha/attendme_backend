using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Services.Account.Entities
{
    public class AccountDTO
    {
        // Failed model validations using DataAnnotations - [Required]
        public Guid? Guid { get; set; }

        [Required]
        public string Name { get; set; }

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

        [Required]
        public IList<AccSbscrptnDTO> Subscriptions { get; set; }
    }
}