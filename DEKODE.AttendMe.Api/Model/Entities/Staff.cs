using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DEKODE.AttendMe.Api.Model.Entities
{
    public class Staff : TemporalEntityBase
    {
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

        public string RefNo { get; set; }

        [Required]
        public int OrganisationId { get; set; }

        public virtual Organisation Organisation { get; set; }

        public virtual IList<StaffLog> StaffLogs { get; set; }
    }
}