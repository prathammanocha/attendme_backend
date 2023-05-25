using DEKODE.AttendMe.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Services.Common
{
    public class TemporalEntityBase : EntityBase
    {
        public TemporalEntityBase()
        {
            EffectiveEndDate = DateTimeHelper.NewEndDateTime();
            AuditUser = "sysadmin";
        }

        //[IgnoreDataMember]
        [Required]
        public DateTime EffectiveStartDate { get; set; }

        //[IgnoreDataMember]
        [Required]
        public DateTime EffectiveEndDate { get; set; }

        //[IgnoreDataMember]
        [Required]
        public string AuditUser { get; set; }

        //[IgnoreDataMember]
        [Required]
        public bool IsDeleted { get; set; }
    }
}
