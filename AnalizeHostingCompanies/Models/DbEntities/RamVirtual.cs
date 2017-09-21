using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnalizeHostingCompanies.Models.DbEntities
{
    public class RamVirtual
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(0, 200000000)]
        public int RamMemory { get; set; }

        public virtual ICollection<VirtualServer> VirtualServers { get; set; }
    }
}