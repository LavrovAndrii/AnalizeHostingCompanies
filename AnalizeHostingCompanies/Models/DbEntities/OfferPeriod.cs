using System;
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

        public int CountDay { get; set; }
        public DateTime StartData { get; set; }

        public virtual ICollection<VirtualServer> VirtualServers { get; set; }
    }
}