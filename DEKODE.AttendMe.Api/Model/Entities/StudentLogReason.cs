using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Model.Entities
{
    public class StudentLogReason : TemporalEntityBase
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public int OrganisationId { get; set; }
        public virtual Organisation Organisation { get; set; }
    }
}
