using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApp.Models
{
    public class AccountViewModel
    {
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public string StreetNo { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        [Display(Name = "Contact Full Name")]
        public string ContactName { get; set; }
        [Display(Name = "Contact Phone")]
        public string ContactPhone { get; set; }
        [Display(Name = "Contact Email")]
        public string Email { get; set; }
        public string ABN { get; set; }
    }
}
