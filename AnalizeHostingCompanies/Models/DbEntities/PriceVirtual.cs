using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnalizeHostingCompanies.Models.DbEntities
{
    public class PriceVirtual
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(0, 20000000)]
        public int PricePerDay { get; set; }

        public virtual ICollection<VirtualServer> VirtualServers { get; set; }
    }
}