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
            : base("HostingCompaniesDb", throwIfV1Schema: false)
        {
        }

 

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
                .HasForeignKey(e => e.LocationId);

            modelBuilder.Entity<InternetProvider>()
                .HasMany(e => e.HostingCompanies)
                .WithRequired(e => e.InternetProvider)
                .HasForeignKey(e => e.InternetProviderId);

            modelBuilder.Entity<ServerDataCenter>()
                .HasMany(e => e.HostingCompanies)
                .WithRequired(e => e.ServerDataCenter)
                .HasForeignKey(e => e.ServerDataCenterId);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.HostingCompanies)
                .WithRequired(e => e.Staff)
                .HasForeignKey(e => e.StuffId);

            

            //Level ServerDataCenter

            modelBuilder.Entity<PhisicalServer>()
                .HasMany(e => e.ServerDataCenters)
                .WithRequired(e => e.PhisicalServer)
                .HasForeignKey(e => e.PhisicalServerId);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.ServerDataCenters)
                .WithRequired(e => e.Location)
                .HasForeignKey(e => e.LocationId);

            //Level PhisicalServer

            modelBuilder.Entity<CpuType>()
                .HasMany(e => e.PhisicalServers)
                .WithRequired(e => e.CpuType)
                .HasForeignKey(e => e.CpuTypeId);

            modelBuilder.Entity<HddType>()
                .HasMany(e => e.PhisicalServers)
                .WithRequired(e => e.HddType)
                .HasForeignKey(e => e.HddTypeId);

            modelBuilder.Entity<VirtualServer>()
                .HasMany(e => e.PhisicalServers)
                .WithRequired(e => e.VirtualServer)
                .HasForeignKey(e => e.VirtualServerId);


            //Level VirtualServer

            modelBuilder.Entity<Cms>()
                .HasMany(e => e.VirtualServers)
                .WithRequired(e => e.Cms)
                .HasForeignKey(e => e.CmsId);
            
            modelBuilder.Entity<PriceVirtual>()
                .HasMany(e => e.VirtualServers)
                .WithRequired(e => e.PriceVirtual)
                .HasForeignKey(e => e.PriceVirtualId);
            
            modelBuilder.Entity<CountCpuCore>()
                .HasMany(e => e.VirtualServers)
                .WithRequired(e => e.CountCpuCore)
                .HasForeignKey(e => e.CountCpuCoreId);

            modelBuilder.Entity<HddVirtual>()
                .HasMany(e => e.VirtualServers)
                .WithRequired(e => e.HddVirtual)
                .HasForeignKey(e => e.HddVirtualId);

            modelBuilder.Entity<RamVirtual>()
                .HasMany(e => e.VirtualServers)
                .WithRequired(e => e.RamVirtual)
                .HasForeignKey(e => e.RamVirtualId);

            modelBuilder.Entity<IpAddress>()
                .HasMany(e => e.VirtualServers)
                .WithRequired(e => e.IpAddress)
                .HasForeignKey(e => e.IpAddressId);

            modelBuilder.Entity<Traffic>()
                .HasMany(e => e.VirtualServers)
                .WithRequired(e => e.Traffic)
                .HasForeignKey(e => e.TrafficId);

            modelBuilder.Entity<SpeedConnection>()
                .HasMany(e => e.VirtualServers)
                .WithRequired(e => e.SpeedConnection)
                .HasForeignKey(e => e.SpeedConnectionId);

            modelBuilder.Entity<OfferPeriod>()
                .HasMany(e => e.VirtualServers)
                .WithRequired(e => e.OfferPeriod)
                .HasForeignKey(e => e.OfferPeriodId);




        }
    }
}