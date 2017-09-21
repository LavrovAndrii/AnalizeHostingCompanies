using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AnalizeHostingCompanies.Models.DbEntities
{
    public class DbInitializer : DropCreateDatabaseAlways<HostingCompanyContext>
    {
        //protected override void Seed(HostingCompanyContext db)
        //{
        //    db.HostingCompanies.Add(new HostingCompany{Name = "HyperHosting", Location = "Вінниця", Site = "hyperhost.ua",InternetProvider = "DataGroup", })
        //    base.Seed(db);
        //}
    }
}