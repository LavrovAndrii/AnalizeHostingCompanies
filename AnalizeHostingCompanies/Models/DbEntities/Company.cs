using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace AnalizeHostingCompanies.Models.DbEntities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Site { get; set; }
        public string InternetProviderId { get; set; }
        public string ServerDataCenterId { get; set; }
        //public int Rating  { get; set; }

    }
}