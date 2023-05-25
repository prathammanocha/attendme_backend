using System;
using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Data.Contract
{
    public class PatronDTO
    {
        [Required]
        public Guid Guid { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string ContactPhone { get; set; }

        [Required]
        public string ContactEmail { get; set; }

        public string CompanyName { get; set; }

        [Required]
        public bool TermsAndConditionCheck { get; set; }

        [Required]
        public bool IsAuthorizedToCollect { get; set; } = false;

        public string ReferenceKeyId { get; set; }

        [Required]
        public int PatronTypeId { get; set; }

        [Required]
        public int OrganisationId { get; set; }
    }
}