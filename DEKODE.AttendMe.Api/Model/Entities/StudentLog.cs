using DEKODE.AttendMe.Api.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Api.Model.Entities
{
    public class StudentLog : TemporalEntityBase
    {
        [Key]
        public new int Id { get; set; }
        public string OtherReason { get; set; }
        [Required]
        public DateTime LogDateTime { get; set; }
        [Required]
        public LogType LogType { get; set; }
        [Required]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        [Required]
        public int StudentLogReasonId { get; set; }
        public virtual StudentLogReason StudentLogReason { get; set; }
        [Required]
        public int PatronId { get; set; }
        public virtual Patron Patron { get; set; }

    }
}
