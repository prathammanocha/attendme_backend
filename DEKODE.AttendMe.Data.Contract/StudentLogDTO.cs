using System;
using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Data.Contract
{
    public class StudentLogDTO
    {
        public int Id { get; set; }

        public string OtherReason { get; set; }

        [Required]
        public DateTime LogDateTime { get; set; }

        [Required]
        public LogType LogType { get; set; }

        [Required]
        public int StudentId { get; set; }

        public int StudentLogReasonId { get; set; }

        [Required]
        public int PatronId { get; set; }
    }
}
