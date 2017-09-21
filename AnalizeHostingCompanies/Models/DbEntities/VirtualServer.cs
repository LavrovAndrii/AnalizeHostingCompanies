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
        public string TypeServer { get; set; }

        [Display(Name = "CMS")]
        public int CmsId { get; set; }
        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Ціна за день")]
        public decimal Price { get; set; }//price per day
        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Кількість ядер ЦП")]
        public byte CountCpuCores { get; set; }
        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Максимальна кількість запитів")]
        public int MaxCountRequest { get; set; }
        [Display(Name = "Тип ЦП")]
        public int CpuTypeId { get; set; }
        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Кількість ядер ЦП")]
        public byte CountCore { get; set; }
        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Місце на диску (Gb)")]
        public byte Hdd { get; set; }
        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Оперативна пам'ять (Gb)")]
        public byte Ram { get; set; }
        [Display(Name = "ІР адреса")]
        public string IpAddressId { get; set; }
        [Display(Name = "Трафік")]
        public int TrafficId { get; set; }
        [Display(Name = "Швидкість інтернет з'єднання")]
        public int SpeedConnectionId { get; set; }
        [Display(Name = "Термін покупки")]
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