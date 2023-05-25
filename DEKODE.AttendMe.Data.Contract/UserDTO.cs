using System;
using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Data.Contract
{
    public class UserDTO
    {
        // [JsonIgnore]
        public Guid UserGuid { get; set; }

        public Guid OrganisationGuid { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}