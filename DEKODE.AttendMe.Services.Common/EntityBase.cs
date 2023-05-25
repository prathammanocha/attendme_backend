using System;
using System.ComponentModel.DataAnnotations;

namespace DEKODE.AttendMe.Services.Common
{
    public class EntityBase
    {
        public Guid Guid { get; set; }

        [Key]
        public int Id { get; set; }
    }
}
