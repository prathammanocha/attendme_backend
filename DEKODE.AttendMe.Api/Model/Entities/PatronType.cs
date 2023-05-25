using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Api.Model.Entities
{
    public class PatronType : TemporalEntityBase
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        
        //public virtual IList<Patron> Patrons { get; set; }
    }
}