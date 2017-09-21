using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnalizeHostingCompanies.Models.DbEntities
{
    public class Traffic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Об'єм даних")]
        public int Data { get; set; }
        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Ціна")]
        public decimal Price { get; set; }

        public virtual ICollection<InternetProvider> InternetProviders { get; set; }
        public virtual ICollection<VirtualServer> VirtualServers { get; set; }
    }
}