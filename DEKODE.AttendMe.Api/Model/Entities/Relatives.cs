using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DEKODE.AttendMe.Api.Model.Entities
{

    public class Relatives : TemporalEntityBase
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Company { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Workingwc { get; set; }

        [Required]
        public bool ChildSafety { get; set; }

        [Required]
        public bool VDS { get; set; }

        [Required]
        public int PatronTypeId { get; set; }

        public virtual PatronType PatronType { get; set; }

        [Required]
        public int OrganisationId { get; set; }

        public virtual Organisation Organisation { get; set; }

        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}
