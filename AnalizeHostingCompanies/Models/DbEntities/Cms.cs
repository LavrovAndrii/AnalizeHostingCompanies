﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnalizeHostingCompanies.Models.DbEntities
{
    public class Cms
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Назва CMS")]
        public string Name { get; set; }

        public virtual ICollection<VirtualServer> VirtualServers { get; set; }
    }
}