using System;
using System.ComponentModel.DataAnnotations;
using DEKODE.AttendMe.Common;

namespace DEKODE.AttendMe.Api.Model.Entities
{
    public class TemporalEntityBase : EntityBase
    {
        public TemporalEntityBase()
        {
            //TODO ~ Replace EffectiveStartDate this with client date time. See old API for reference.
            EffectiveStartDate = DateTime.Now;
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

        public void Delete()
        {
            EffectiveEndDate = DateTime.Now.AddSeconds(-1);
            IsDeleted = true;
        }
    }
}