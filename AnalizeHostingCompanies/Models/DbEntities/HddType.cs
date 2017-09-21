using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnalizeHostingCompanies.Models.DbEntities
{
    public class HddType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Назва типу накопичувача")]
        public string Name { get; set; }


        public virtual ICollection<PhisicalServer> PhisicalServers { get; set; }
    }
}