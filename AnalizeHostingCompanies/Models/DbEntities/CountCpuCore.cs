using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnalizeHostingCompanies.Models.DbEntities
{
    public class CountCpuCore
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(0,200)]
        public int CountCores { get; set; }

        public virtual ICollection<VirtualServer>VirtualServers { get; set; }
    }
}