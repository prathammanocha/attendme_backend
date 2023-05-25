using System;
using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Data.Contract
{
    public class RelativesDTO
    {

        [Required]
        public int PatronTypeId { get; set; }

        [Required]
        public int OrganisationId { get; set; }

        [Required]
        public Guid Guid { get; set; }

        [Required]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Workingwc { get; set; }
        public bool ChildSafety { get; set; }
        public bool VDS { get; set; }
        public int StudentId { get; set; }
    }
}
