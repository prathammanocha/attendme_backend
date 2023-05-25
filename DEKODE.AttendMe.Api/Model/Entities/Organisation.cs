using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Api.Model.Entities
{
    public class Organisation : TemporalEntityBase
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

        public string Website { get; set; }

        //public int AccountId { get; set; }
        //public virtual Account Account { get; set; }
        //public int AccSbscrptnId { get; set; }
        //public virtual AccSbscrptn AccSbscrptn { get; set; }
        public virtual IList<Staff> StaffMembers { get; set; }

        public virtual IList<Student> Students { get; set; }
        public virtual IList<StudentLogReason> StudentLogReasons { get; set; }
        public virtual IList<Patron> Patrons { get; set; }
        public virtual IList<OrganisationUser> Users { get; set; }

        //public virtual IList<User> Users { get; set; }
        //public virtual IList<AppDevice> AppDevices { get; set; }
        //
    }
}