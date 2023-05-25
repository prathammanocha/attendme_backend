using System;
using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Api.Model.Entities
{
    public class StudentIncidentLog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime IncidentDate { get; set; }

        //[Required]
        //public int OrganisationId { get; set; }

        //public virtual Organisation Organisation { get; set; }

        [Required]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        [Required]
        public int StaffId { get; set; }

        public virtual Staff Staff { get; set; }

        [Required]
        public int StudentIncidentId { get; set; }

        public virtual StudentIncident StudentIncident { get; set; }
        public string IncidentOther { get; set; }

        [Required]
        public int StudentIncidentSymptomId { get; set; }

        public virtual StudentIncidentSymptom StudentIncidentSymptom { get; set; }
        public string SymptomsOther { get; set; }

        [Required]
        public int StudentIncidentActionId { get; set; }

        public virtual StudentIncidentAction StudentIncidentAction { get; set; }
        public string ActionOther { get; set; }
    }
}