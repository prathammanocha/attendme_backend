using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Data.Contract
{
    public class StudentLogReasonDTO
    {
        [Required]
        public string Description { get; set; }

        [Required]
        public int OrganisationId { get; set; }
    }
}