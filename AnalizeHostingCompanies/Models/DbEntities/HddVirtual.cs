using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnalizeHostingCompanies.Models.DbEntities
{
    public class HddVirtual
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(0, 200000000000)]
        public int HddMemory { get; set; }

        public virtual ICollection<VirtualServer> VirtualServers { get; set; }
    }
}