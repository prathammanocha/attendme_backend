using System;
using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Api.Model.Entities
{
    public class VisitorLog : TemporalEntityBase
    {
        [Required]
        public string VisitingPerson { get; set; }

        [Required]
        public string Purpose { get; set; }

        public DateTime InDateTime { get; set; }

        public DateTime OutDateTime { get; set; }

        [Required]
        public int PatronId { get; set; }

        public virtual Patron Patron { get; set; }

        public int OrganisationId { get; set; }

        public virtual Organisation Organisation { get; set; }
    }
}