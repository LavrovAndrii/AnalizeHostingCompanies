using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnalizeHostingCompanies.Models.DbEntities
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Назва команди персоналу")]
        public string Name { get; set; }
        [Required]
        [Range(0, 100000)]
        [Display(Name = "Кількість адміністраторів")]
        public int CountAdministrators { get; set; }
        [Required]
        [Range(0, 100000)]
        [Display(Name = "Кількість менеджерів з підтримки")]
        public int CountSupportManagers { get; set; }
        [Required]
        [Range(0, 100000)]
        [Display(Name = "Кількість менеджерів з продаж")]
        public int CountSalesManagers { get; set; }

        public virtual ICollection<HostingCompany> Companies { get; set; }

    }
}