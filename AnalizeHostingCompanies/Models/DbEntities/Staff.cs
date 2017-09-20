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
        public string Name { get; set; }
        public int CountAdministrators { get; set; }
        public int CountSupportManagers { get; set; }
        public int CountSalesManagers { get; set; }


    }
}