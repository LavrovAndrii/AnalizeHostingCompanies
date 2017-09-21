﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace AnalizeHostingCompanies.Models.DbEntities
{
    public class OfferPeriod
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Кількість дів")]
        public int CountDay { get; set; }
        
        [Display(Name = "Дата запуску сервера")]
        public DateTime StartData { get; set; }

        public virtual ICollection<VirtualServer> VirtualServers { get; set; }
    }
}