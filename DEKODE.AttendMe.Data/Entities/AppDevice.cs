
using DEKODE.AttendMe.Model.Enums;

namespace DEKODE.AttendMe.Data.Model.Entities
{
    public class AppDevice : TemporalEntityBase
    {
        public AppType AppType { get; set; }
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
        public int OrganisationId { get; set; }
        public Organisation Organisation { get; set; }
    }
}
