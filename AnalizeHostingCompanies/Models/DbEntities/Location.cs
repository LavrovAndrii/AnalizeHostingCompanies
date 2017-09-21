using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace AnalizeHostingCompanies.Models.DbEntities
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Місто")]
        public string City { get; set; }
        [Display(Name = "Адреса")]
        public string DetailedAddress { get; set; }

        public virtual ICollection<HostingCompany> HostingCompanies  { get; set; }
        public virtual ICollection<ServerDataCenter> ServerDataCenters { get; set; }
    }
}