using System;
using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Services.Account.Entities
{
    public class AccSbscrptnDTO
    {
        [Required]
        public Guid? Guid { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string IsActive { get; set; }

        [Required]
        public int AccountId { get; set; }

        [Required]
        public Guid? SubscriptionTypeGuid { get; set; }

        [Required]
        public string SubscriptionType { get; set; }

        [Required]
        public decimal SubscriptionAmount { get; set; }

        [Required]
        public int DevicesAllowed { get; set; }
    }
}