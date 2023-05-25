using System;
using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Data.Contract
{
    public class VisitorLogDTO
    {
        [Required]
        public string VisitingPerson { get; set; }

        [Required]
        public string Purpose { get; set; }

        public DateTime InDateTime { get; set; }

        public DateTime OutDateTime { get; set; }

        [Required]
        public int PatronId { get; set; }

        [Required]
        public int OrganisationId { get; set; }

    }
}