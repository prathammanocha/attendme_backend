using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Api.Model.Entities
{
    public class StudentIncidentAction : TemporalEntityBase
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public int OrganisationId { get; set; }

        public virtual Organisation Organisation { get; set; }
    }
}