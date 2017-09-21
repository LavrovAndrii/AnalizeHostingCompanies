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

        [Required]
        [Display(Name = "Тип сервера")]
        public string NameTypeServer { get; set; }

        [Display(Name = "CMS")]
        public int CmsId { get; set; }

        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Ціна за день")]
        public int PriceVirtualId { get; set; }//price per day

        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Максимальна кількість запитів")]
        public int MaxCountRequest { get; set; }

        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Кількість ядер ЦП")]
        public int CountCpuCoreId { get; set; }

        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Місце на диску (Gb)")]
        public int HddVirtualId { get; set; }

        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Оперативна пам'ять (Gb)")]
        public int RamVirtualId { get; set; }

        [Display(Name = "ІР адреса")]
        public int IpAddressId { get; set; }

        [Display(Name = "Трафік")]
        public int TrafficId { get; set; }

        [Display(Name = "Швидкість інтернет з'єднання")]
        public int SpeedConnectionId { get; set; }

        [Display(Name = "Термін покупки")]
        public int OfferPeriodId { get; set; }


        public virtual Cms Cms { get; set; }
        public virtual CountCpuCore CountCpuCore { get; set; }
        public virtual HddVirtual HddVirtual { get; set; }
        public virtual RamVirtual RamVirtual { get; set; }
        public virtual PriceVirtual PriceVirtual { get; set; }


        public virtual IpAddress IpAddress { get; set; }
        public virtual Traffic Traffic { get; set; }
        public virtual SpeedConnection SpeedConnection { get; set; }
        public virtual OfferPeriod OfferPeriod { get; set; }
        public virtual ICollection<PhisicalServer> PhisicalServers { get; set; }
        
    }
}