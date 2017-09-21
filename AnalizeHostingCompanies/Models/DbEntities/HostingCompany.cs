using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Web;
using Microsoft.ApplicationInsights.Extensibility.Implementation;

namespace AnalizeHostingCompanies.Models.DbEntities
{
    public class HostingCompany
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Назва компанії")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Місце розташування")]
        public string LocationId { get; set; }
        [Required]
        [Display(Name = "Сайт компанії")]
        public string Site { get; set; }
        [Required]
        [Display(Name = "Інтернет провайдер")]
        public string InternetProviderId { get; set; }
        [Required]
        [Display(Name = "Датацентр")]
        public string ServerDataCenterId { get; set; }
        [Required]
        [Display(Name = "Персонал")]
        public string StuffId { get; set; }

       

        public virtual InternetProvider InternetProvider { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Location Location { get; set; }


        public virtual ICollection<Rating> Rating { get; set; }
    }
}