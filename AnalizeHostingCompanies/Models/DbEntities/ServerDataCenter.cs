using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace AnalizeHostingCompanies.Models.DbEntities
{
    public class ServerDataCenter
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Назва датацентру")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Місто")]
        public int LocationId { get; set; }

        [Required]
        [Display(Name = "Фізичний сервер")]
        public int PhisicalServerId { get; set; }
        [Required]
        [Display(Name = "Надійність (%)")]
        [Range(0, 100)]
        public int UpTime { get; set; }
       
        public virtual Location Location { get; set; }
        public virtual PhisicalServer PhisicalServer { get; set; }
        public virtual ICollection<HostingCompany> HostingCompanies { get; set; }

    }
}