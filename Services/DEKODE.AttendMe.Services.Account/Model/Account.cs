using DEKODE.AttendMe.Services.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Services.Account.Model
{
    public class Account : TemporalEntityBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public virtual Address Address { get; set; }

        [Required]
        public string ContactName { get; set; }

        [Required]
        public string ContactPhone { get; set; }

        [Required]
        public string ContactEmail { get; set; }

        [Required]
        public string ABN { get; set; }

        public string Website { get; set; }

        [Required]
        public bool IsActive { get; set; }

        //public virtual IList<Organisation> Organisations { get; set; }

        public virtual IList<AccSbscrptn> AccSbscrptns { get; set; }

        //public virtual IList<AccountUser> AccountUsers { get; set; }
    }
}