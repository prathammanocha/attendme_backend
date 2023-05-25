using DEKODE.AttendMe.Api.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Api.Model.Entities
{
    public class StaffLog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public LogType LogType { get; set; }
        [Required]
        public DateTime LogDateTime { get; set; }
        [Required]
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }
    }
}