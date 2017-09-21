using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnalizeHostingCompanies.Models.DbEntities
{
    public class IpAddress
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "IP адреса")]
        public string NameIpAddress { get; set; }
        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Ціна")]
        public int Price { get; set; }

        public virtual ICollection<VirtualServer> VirtualServers { get; set; }
    }
}