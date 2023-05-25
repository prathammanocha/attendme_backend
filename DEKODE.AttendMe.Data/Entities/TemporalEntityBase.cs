using System;

namespace DEKODE.AttendMe.Data.Model.Entities
{
    public class TemporalEntityBase : EntityBase
    {
        public TemporalEntityBase()
        {
            EffectiveEndDate = new DateTime(9999, 12, 31);
            AuditUser = "sysadmin";
        }

        //[IgnoreDataMember]
        public DateTime EffectiveStartDate { get; set; }

        //[IgnoreDataMember]
        public DateTime EffectiveEndDate { get; set; }

        //[IgnoreDataMember]
        public string AuditUser { get; set; }

        //[IgnoreDataMember]
        public bool IsDeleted { get; set; }
    }
}
