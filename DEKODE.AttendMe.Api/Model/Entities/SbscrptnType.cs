using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Api.Model.Entities
{
    public class SbscrptnType : TemporalEntityBase
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public int DevicesAllowed { get; set; }
        
        //public virtual IList<AccSbscrptn> AccSbscrptns { get; set; }
    }
}