using System;
using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Api.Model.Entities
{
    public class EntityBase
    {
        public Guid Guid { get; set; }

        [Key]
        public int Id { get; set; }
    }
}