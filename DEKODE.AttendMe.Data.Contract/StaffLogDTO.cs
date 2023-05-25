using System;
using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Data.Contract
{
    public class StaffLogDTO
    {
        [Required]
        public int StaffId { get; set; }

        [Required]
        public string InOut { get; set; }

        [Required]
        public DateTime LogDateTime { get; set; }
    }
}