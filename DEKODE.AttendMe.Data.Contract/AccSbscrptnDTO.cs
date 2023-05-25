using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DEKODE.AttendMe.Data.Contract
{
    public class AccSbscrptnDTO
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string IsActive { get; set; }
        [Required]
        public int AccountId { get; set; }
        //[Required]
        //public virtual AccountDTO Account { get; set; }
        [Required]
        public int SbscrptnTypeId { get; set; }
        //[Required]
        //public virtual SbscrptnTypeDTO SbscrptnType { get; set; }
    }
}
