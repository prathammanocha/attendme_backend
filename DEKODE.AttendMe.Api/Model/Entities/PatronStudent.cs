using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Api.Model.Entities
{
    public class PatronStudent : TemporalEntityBase
    {
        [Required]
        public int PatronId { get; set; }

        public virtual Patron Patron { get; set; }

        [Required]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}