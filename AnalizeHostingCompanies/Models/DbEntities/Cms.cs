using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnalizeHostingCompanies.Models.DbEntities
{
    public class Cms
    {


        public virtual ICollection<VirtualServer> VirtualServers { get; set; }
    }
}