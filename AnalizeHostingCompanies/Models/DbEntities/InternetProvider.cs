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

        public string Name { get; set; }

        public int SpeedConnection { get; set; }
        public int Traffic { get; set; }
        public string PoolIpAddress { get; set; }


    }
}