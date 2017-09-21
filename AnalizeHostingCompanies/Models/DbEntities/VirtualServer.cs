using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnalizeHostingCompanies.Models.DbEntities
{
    public class VirtualServer
    {
        [Key]
        public int Id { get; set; }

        public string TypeServer { get; set; }
        public int CmsId { get; set; }
        public decimal Price { get; set; }//price per day
        public byte CountCpuCores { get; set; }
        public int MaxCountRequest { get; set; }
        public int CpuTypeId { get; set; }
        public byte CountCore { get; set; }
        public byte Hdd { get; set; }
        public byte Ram { get; set; }
        public string IpAddressId { get; set; }
        public int TrafficId { get; set; }
        public int SpeedConnectionId { get; set; }
        public int OfferPeriodId { get; set; }


        public virtual Cms Cms { get; set; }
        public virtual CpuType CpuType { get; set; }
        public virtual IpAddress IpAddress { get; set; }
        public virtual Traffic Traffic { get; set; }
        public virtual SpeedConnection SpeedConnection { get; set; }
        public virtual OfferPeriod OfferPeriod { get; set; }
        public virtual ICollection<PhisicalServer> PhisicalServers { get; set; }
        
    }
}