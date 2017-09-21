using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AnalizeHostingCompanies.Models.DbEntities
{
    public class HostingCompanyContext : ApplicationDbContext 
    {
        public DbSet<Cms> Cmses { get; set; }
        public DbSet<CpuType> CpuTypes { get; set; }
        public DbSet<HddType> HddTypes { get; set; }
        public DbSet<HostingCompany> HostingCompanies { get; set; }
        public DbSet<InternetProvider> InternetProviders { get; set; }
        public DbSet<IpAddress>  IpAddresses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<OfferPeriod> OfferPeriods { get; set; }
        public DbSet<PhisicalServer> PhisicalServers { get; set; }
        public DbSet<PoolIpAddress> PoolIpAddresses { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<ServerDataCenter> ServerDataCenters { get; set; }
        public DbSet<SpeedConnection> SpeedConnections { get; set; }
        public DbSet<Staff> Staves { get; set; }
        public DbSet<Traffic> Traffics { get; set; }
        public DbSet<VirtualServer> VirtualServers { get; set; }

    }
}