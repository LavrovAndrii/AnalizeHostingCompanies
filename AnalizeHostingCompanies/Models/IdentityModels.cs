using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using AnalizeHostingCompanies.Models.DbEntities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AnalizeHostingCompanies.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        //public DbSet<IdentityUserLogin> IdentityUserLogins { get; set; }
        //public DbSet<IdentityUserRole> IdentityUserRoles { get; set; }

        public DbSet<Cms> Cmses { get; set; }
        public DbSet<CpuType> CpuTypes { get; set; }
        public DbSet<HddType> HddTypes { get; set; }
        public DbSet<HostingCompany> HostingCompanies { get; set; }
        public DbSet<InternetProvider> InternetProviders { get; set; }
        public DbSet<IpAddress> IpAddresses { get; set; }
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
        public DbSet<CountCpuCore> CountCpuCores { get; set; }
        public DbSet<HddVirtual> HddVirtuals { get; set; }
        public DbSet<PriceVirtual> PriceVirtuals { get; set; }
        public DbSet<RamVirtual> RamVirtuals { get; set; }


       


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            //Level Rating

            modelBuilder.Entity<HostingCompany>()
                .HasMany(e => e.Rating)
                .WithRequired(e => e.HostingCompany)
                .HasForeignKey(e => e.HostingCompanyId);



            //Level HostingCompany

            modelBuilder.Entity<Location>()
                .HasMany(e => e.HostingCompanies)
                .WithRequired(e => e.Location)
                .HasForeignKey(e => e.LocationId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InternetProvider>()
                .HasMany(e => e.HostingCompanies)
                .WithRequired(e => e.InternetProvider)
                .HasForeignKey(e => e.InternetProviderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServerDataCenter>()
                .HasMany(e => e.HostingCompanies)
                .WithRequired(e => e.ServerDataCenter)
                .HasForeignKey(e => e.ServerDataCenterId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.HostingCompanies)
                .WithRequired(e => e.Staff)
                .HasForeignKey(e => e.StuffId)
                .WillCascadeOnDelete(false);



            //Level ServerDataCenter

            modelBuilder.Entity<PhisicalServer>()
                .HasMany(e => e.ServerDataCenters)
                .WithRequired(e => e.PhisicalServer)
                .HasForeignKey(e => e.PhisicalServerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.ServerDataCenters)
                .WithRequired(e => e.Location)
                .HasForeignKey(e => e.LocationId)
                .WillCascadeOnDelete(false);

            //Level PhisicalServer

            modelBuilder.Entity<CpuType>()
                .HasMany(e => e.PhisicalServers)
                .WithRequired(e => e.CpuType)
                .HasForeignKey(e => e.CpuTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HddType>()
                .HasMany(e => e.PhisicalServers)
                .WithRequired(e => e.HddType)
                .HasForeignKey(e => e.HddTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VirtualServer>()
                .HasMany(e => e.PhisicalServers)
                .WithRequired(e => e.VirtualServer)
                .HasForeignKey(e => e.VirtualServerId)
                .WillCascadeOnDelete(false);


            //Level VirtualServer

            modelBuilder.Entity<Cms>()
                .HasMany(e => e.VirtualServers)
                .WithRequired(e => e.Cms)
                .HasForeignKey(e => e.CmsId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PriceVirtual>()
                .HasMany(e => e.VirtualServers)
                .WithRequired(e => e.PriceVirtual)
                .HasForeignKey(e => e.PriceVirtualId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CountCpuCore>()
                .HasMany(e => e.VirtualServers)
                .WithRequired(e => e.CountCpuCore)
                .HasForeignKey(e => e.CountCpuCoreId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HddVirtual>()
                .HasMany(e => e.VirtualServers)
                .WithRequired(e => e.HddVirtual)
                .HasForeignKey(e => e.HddVirtualId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RamVirtual>()
                .HasMany(e => e.VirtualServers)
                .WithRequired(e => e.RamVirtual)
                .HasForeignKey(e => e.RamVirtualId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IpAddress>()
                .HasMany(e => e.VirtualServers)
                .WithRequired(e => e.IpAddress)
                .HasForeignKey(e => e.IpAddressId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Traffic>()
                .HasMany(e => e.VirtualServers)
                .WithRequired(e => e.Traffic)
                .HasForeignKey(e => e.TrafficId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SpeedConnection>()
                .HasMany(e => e.VirtualServers)
                .WithRequired(e => e.SpeedConnection)
                .HasForeignKey(e => e.SpeedConnectionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OfferPeriod>()
                .HasMany(e => e.VirtualServers)
                .WithRequired(e => e.OfferPeriod)
                .HasForeignKey(e => e.OfferPeriodId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}