using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Api.Model.Entities
{
    public class OrganisationUser : TemporalEntityBase
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Password { get; set; }

        [Required]
        public int OrganisationId { get; set; }
        
        public virtual Organisation Organisation { get; set; }
    }
}