using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnalizeHostingCompanies.Models.DbEntities
{
    public class SpeedConnection
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Швидкість даних")]
        public int NameSpeed { get; set; }
        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Ціна з'єднання")]
        public decimal Price { get; set; }

        public virtual ICollection<InternetProvider> InternetProviders { get; set; }
        public virtual ICollection<VirtualServer> VirtualServers { get; set; }
    }
}