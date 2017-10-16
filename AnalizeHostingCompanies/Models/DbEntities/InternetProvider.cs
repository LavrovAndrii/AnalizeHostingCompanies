using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnalizeHostingCompanies.Models.DbEntities
{
    public class InternetProvider
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Інтернет провайдер")]
        public string Name { get; set; }
        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Швидкість інтернет з'єднання")]
        public int SpeedConnectionId { get; set; }
        [Required]
        [Display(Name = "Кількість трафіку")]
        public int TrafficId { get; set; }
        [Required]
        [Display(Name = "Діапазон ІР адрес")]
        public string PoolIpAddressId { get; set; }
        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Швидкість відклику (Ping)")]
        public int Ping { get; set; }
        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Максимальна швидкість інтернет з'єднання (Gbit/секунду)")]
        public int MaxSpeed { get; set; }
        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Максимальна кількість трафіку (Gigabites)")]
        public int MaxTraffic { get; set; }


       
        public virtual SpeedConnection SpeedConnection { get; set; }
        public virtual Traffic Traffic { get; set; }
        public virtual PoolIpAddress PoolIpAddress { get; set; }

        public virtual ICollection<HostingCompany> HostingCompanies { get; set; }


    }
}