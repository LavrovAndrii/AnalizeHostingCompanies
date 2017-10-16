namespace AnalizeHostingCompanies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VirtualServers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameTypeServer = c.String(nullable: false),
                        CmsId = c.Int(nullable: false),
                        PriceVirtualId = c.Int(nullable: false),
                        MaxCountRequest = c.Int(nullable: false),
                        CountCpuCoreId = c.Int(nullable: false),
                        HddVirtualId = c.Int(nullable: false),
                        RamVirtualId = c.Int(nullable: false),
                        IpAddressId = c.Int(nullable: false),
                        TrafficId = c.Int(nullable: false),
                        SpeedConnectionId = c.Int(nullable: false),
                        OfferPeriodId = c.Int(nullable: false),
                        PoolIpAddress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CountCpuCores", t => t.CountCpuCoreId)
                .ForeignKey("dbo.HddVirtuals", t => t.HddVirtualId)
                .ForeignKey("dbo.IpAddresses", t => t.IpAddressId)
                .ForeignKey("dbo.OfferPeriods", t => t.OfferPeriodId)
                .ForeignKey("dbo.PoolIpAddresses", t => t.PoolIpAddress_Id)
                .ForeignKey("dbo.SpeedConnections", t => t.SpeedConnectionId)
                .ForeignKey("dbo.Traffic", t => t.TrafficId)
                .ForeignKey("dbo.PriceVirtuals", t => t.PriceVirtualId)
                .ForeignKey("dbo.RamVirtuals", t => t.RamVirtualId)
                .ForeignKey("dbo.Cms", t => t.CmsId)
                .Index(t => t.CmsId)
                .Index(t => t.PriceVirtualId)
                .Index(t => t.CountCpuCoreId)
                .Index(t => t.HddVirtualId)
                .Index(t => t.RamVirtualId)
                .Index(t => t.IpAddressId)
                .Index(t => t.TrafficId)
                .Index(t => t.SpeedConnectionId)
                .Index(t => t.OfferPeriodId)
                .Index(t => t.PoolIpAddress_Id);
            
            CreateTable(
                "dbo.CountCpuCores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountCores = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HddVirtuals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HddMemory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IpAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameIpAddress = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OfferPeriods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountDay = c.Int(nullable: false),
                        StartData = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhisicalServers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CpuTypeId = c.Int(nullable: false),
                        HddTypeId = c.Int(nullable: false),
                        VirtualServerId = c.Int(nullable: false),
                        CountCpuCores = c.Int(nullable: false),
                        CountHdd = c.Int(nullable: false),
                        CountRam = c.Int(nullable: false),
                        CpuMax = c.Int(nullable: false),
                        HddMax = c.Int(nullable: false),
                        RamMax = c.Int(nullable: false),
                        PowerConsumptionMax = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CpuTypes", t => t.CpuTypeId)
                .ForeignKey("dbo.HddTypes", t => t.HddTypeId)
                .ForeignKey("dbo.VirtualServers", t => t.VirtualServerId)
                .Index(t => t.CpuTypeId)
                .Index(t => t.HddTypeId)
                .Index(t => t.VirtualServerId);
            
            CreateTable(
                "dbo.CpuTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HddTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ServerDataCenters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LocationId = c.Int(nullable: false),
                        PhisicalServerId = c.Int(nullable: false),
                        UpTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .ForeignKey("dbo.PhisicalServers", t => t.PhisicalServerId)
                .Index(t => t.LocationId)
                .Index(t => t.PhisicalServerId);
            
            CreateTable(
                "dbo.HostingCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LocationId = c.Int(nullable: false),
                        Site = c.String(nullable: false),
                        InternetProviderId = c.Int(nullable: false),
                        ServerDataCenterId = c.Int(nullable: false),
                        StuffId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InternetProviders", t => t.InternetProviderId)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .ForeignKey("dbo.Staffs", t => t.StuffId)
                .ForeignKey("dbo.ServerDataCenters", t => t.ServerDataCenterId)
                .Index(t => t.LocationId)
                .Index(t => t.InternetProviderId)
                .Index(t => t.ServerDataCenterId)
                .Index(t => t.StuffId);
            
            CreateTable(
                "dbo.InternetProviders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SpeedConnectionId = c.Int(nullable: false),
                        TrafficId = c.Int(nullable: false),
                        PoolIpAddressId = c.String(nullable: false),
                        Ping = c.Int(nullable: false),
                        MaxSpeed = c.Int(nullable: false),
                        MaxTraffic = c.Int(nullable: false),
                        PoolIpAddress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PoolIpAddresses", t => t.PoolIpAddress_Id)
                .ForeignKey("dbo.SpeedConnections", t => t.SpeedConnectionId, cascadeDelete: true)
                .ForeignKey("dbo.Traffic", t => t.TrafficId, cascadeDelete: true)
                .Index(t => t.SpeedConnectionId)
                .Index(t => t.TrafficId)
                .Index(t => t.PoolIpAddress_Id);
            
            CreateTable(
                "dbo.PoolIpAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IpNetwork = c.String(nullable: false),
                        CountIpAddress = c.Int(nullable: false),
                        Mask = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SpeedConnections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameSpeed = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Traffic",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(nullable: false),
                        DetailedAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HostingCompanyId = c.Int(nullable: false),
                        UnpayTestingPeriod = c.Int(nullable: false),
                        Feedback = c.Double(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Uptime = c.Byte(nullable: false),
                        Ping = c.Int(nullable: false),
                        MaxCountRequest = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HostingCompanies", t => t.HostingCompanyId, cascadeDelete: true)
                .Index(t => t.HostingCompanyId);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CountAdministrators = c.Int(nullable: false),
                        CountSupportManagers = c.Int(nullable: false),
                        CountSalesManagers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PriceVirtuals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PricePerDay = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RamVirtuals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RamMemory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.VirtualServers", "CmsId", "dbo.Cms");
            DropForeignKey("dbo.VirtualServers", "RamVirtualId", "dbo.RamVirtuals");
            DropForeignKey("dbo.VirtualServers", "PriceVirtualId", "dbo.PriceVirtuals");
            DropForeignKey("dbo.PhisicalServers", "VirtualServerId", "dbo.VirtualServers");
            DropForeignKey("dbo.ServerDataCenters", "PhisicalServerId", "dbo.PhisicalServers");
            DropForeignKey("dbo.HostingCompanies", "ServerDataCenterId", "dbo.ServerDataCenters");
            DropForeignKey("dbo.HostingCompanies", "StuffId", "dbo.Staffs");
            DropForeignKey("dbo.Ratings", "HostingCompanyId", "dbo.HostingCompanies");
            DropForeignKey("dbo.ServerDataCenters", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.HostingCompanies", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.VirtualServers", "TrafficId", "dbo.Traffic");
            DropForeignKey("dbo.InternetProviders", "TrafficId", "dbo.Traffic");
            DropForeignKey("dbo.VirtualServers", "SpeedConnectionId", "dbo.SpeedConnections");
            DropForeignKey("dbo.InternetProviders", "SpeedConnectionId", "dbo.SpeedConnections");
            DropForeignKey("dbo.VirtualServers", "PoolIpAddress_Id", "dbo.PoolIpAddresses");
            DropForeignKey("dbo.InternetProviders", "PoolIpAddress_Id", "dbo.PoolIpAddresses");
            DropForeignKey("dbo.HostingCompanies", "InternetProviderId", "dbo.InternetProviders");
            DropForeignKey("dbo.PhisicalServers", "HddTypeId", "dbo.HddTypes");
            DropForeignKey("dbo.PhisicalServers", "CpuTypeId", "dbo.CpuTypes");
            DropForeignKey("dbo.VirtualServers", "OfferPeriodId", "dbo.OfferPeriods");
            DropForeignKey("dbo.VirtualServers", "IpAddressId", "dbo.IpAddresses");
            DropForeignKey("dbo.VirtualServers", "HddVirtualId", "dbo.HddVirtuals");
            DropForeignKey("dbo.VirtualServers", "CountCpuCoreId", "dbo.CountCpuCores");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Ratings", new[] { "HostingCompanyId" });
            DropIndex("dbo.InternetProviders", new[] { "PoolIpAddress_Id" });
            DropIndex("dbo.InternetProviders", new[] { "TrafficId" });
            DropIndex("dbo.InternetProviders", new[] { "SpeedConnectionId" });
            DropIndex("dbo.HostingCompanies", new[] { "StuffId" });
            DropIndex("dbo.HostingCompanies", new[] { "ServerDataCenterId" });
            DropIndex("dbo.HostingCompanies", new[] { "InternetProviderId" });
            DropIndex("dbo.HostingCompanies", new[] { "LocationId" });
            DropIndex("dbo.ServerDataCenters", new[] { "PhisicalServerId" });
            DropIndex("dbo.ServerDataCenters", new[] { "LocationId" });
            DropIndex("dbo.PhisicalServers", new[] { "VirtualServerId" });
            DropIndex("dbo.PhisicalServers", new[] { "HddTypeId" });
            DropIndex("dbo.PhisicalServers", new[] { "CpuTypeId" });
            DropIndex("dbo.VirtualServers", new[] { "PoolIpAddress_Id" });
            DropIndex("dbo.VirtualServers", new[] { "OfferPeriodId" });
            DropIndex("dbo.VirtualServers", new[] { "SpeedConnectionId" });
            DropIndex("dbo.VirtualServers", new[] { "TrafficId" });
            DropIndex("dbo.VirtualServers", new[] { "IpAddressId" });
            DropIndex("dbo.VirtualServers", new[] { "RamVirtualId" });
            DropIndex("dbo.VirtualServers", new[] { "HddVirtualId" });
            DropIndex("dbo.VirtualServers", new[] { "CountCpuCoreId" });
            DropIndex("dbo.VirtualServers", new[] { "PriceVirtualId" });
            DropIndex("dbo.VirtualServers", new[] { "CmsId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RamVirtuals");
            DropTable("dbo.PriceVirtuals");
            DropTable("dbo.Staffs");
            DropTable("dbo.Ratings");
            DropTable("dbo.Locations");
            DropTable("dbo.Traffic");
            DropTable("dbo.SpeedConnections");
            DropTable("dbo.PoolIpAddresses");
            DropTable("dbo.InternetProviders");
            DropTable("dbo.HostingCompanies");
            DropTable("dbo.ServerDataCenters");
            DropTable("dbo.HddTypes");
            DropTable("dbo.CpuTypes");
            DropTable("dbo.PhisicalServers");
            DropTable("dbo.OfferPeriods");
            DropTable("dbo.IpAddresses");
            DropTable("dbo.HddVirtuals");
            DropTable("dbo.CountCpuCores");
            DropTable("dbo.VirtualServers");
            DropTable("dbo.Cms");
        }
    }
}
