using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DEKODE.AttendMe.Data.Contract
{
    public class StaffDTO
    {
        [Required]
        public Guid Guid { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string ContactPhone { get; set; }

        [Required]
        public string ContactEmail { get; set; }

        [Required]
        public int Pin { get; set; }

        // [Required]
        public string RefNo { get; set; }

        [JsonIgnore]
        public Guid OrganisationGuid { get; set; }
    }
}