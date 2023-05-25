using System;
using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Api.Model.Entities
{
    public class PatronCompliance : TemporalEntityBase
    {
        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int PatronId { get; set; }

        public virtual Patron Patron { get; set; }

        [Required]
        public int ComplianceId { get; set; }

        public virtual Compliance Compliance { get; set; }
    }
}