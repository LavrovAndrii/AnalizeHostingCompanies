using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnalizeHostingCompanies.Models.DbEntities
{
    public class PoolIpAddress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "IP мережа")]
        public string IpNetwork { get; set; }
        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Кількість IP адрес")]
        public int CountIpAddress { get; set; }
        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Маска мережі")]
        public int Mask { get; set; }

        public virtual ICollection<InternetProvider> InternetProviders { get; set; }
        public virtual ICollection<VirtualServer> VirtualServers { get; set; }
    }
}