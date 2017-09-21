using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnalizeHostingCompanies.Models.DbEntities
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Хостингова компанія")]
        public int HostingCompanyId { get; set; }
        [Required]
        [Range(0, 10000)]
        [Display(Name = "Тестовий період")]
        public int UnpayTestingPeriod { get; set; }
        [Required]
        [Display(Name = "Оцінка")]
        public double Feedback { get; set; }
        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Середня ціна")]
        public decimal Price { get; set; }
        [Required]
        [Range(0, 100)]
        [Display(Name = "Надійність")]
        public byte Uptime { get; set; }
        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Час відклику")]
        public int Ping { get; set; }
        [Required]
        [Range(0, 1000000)]
        [Display(Name = "Максимальне навантаження")]
        public int MaxCountRequest { get; set; }

        public virtual HostingCompany HostingCompany { get; set; }

    }
}