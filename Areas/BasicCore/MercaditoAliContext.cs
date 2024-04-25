﻿using Microsoft.EntityFrameworkCore;
using MercaditoAli.Areas.CMSCore.Entities;
using MercaditoAli.Areas.CMSCore.Entities.EntitiesConfiguration;
using MercaditoAli.Areas.BasicCore.Entities.EntitiesConfiguration;
using MercaditoAli.Areas.BasicCore.Entities;
using MercaditoAli.Areas.MercaditoAli.Entities;
using MercaditoAli.Areas.MercaditoAli.Entities.EntitiesConfiguration;

namespace MercaditoAli.Areas.BasicCore
{
    public class MercaditoAliContext : DbContext
    {
        protected IConfiguration _configuration { get; }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<RoleMenu> RoleMenu { get; set; }
        public DbSet<Failure> Failure { get; set; }
        public DbSet<Parameter> Parameter { get; set; }

        //MercaditoAli
        public DbSet<Client> Client { get; set; }
        public DbSet<ProductType> ProductType { get; set; }

        public MercaditoAliContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                string ConnectionString = "";
#if DEBUG
                ConnectionString = "data source =.; " +
                    "initial catalog = MercaditoAli; " +
                    "Integrated Security = SSPI;" +
                    " MultipleActiveResultSets=True;" +
                    "Pooling=false;" +
                    "Persist Security Info=True;" +
                    "App=EntityFramework;" +
                    "TrustServerCertificate=True;";
#else
                ConnectionString = "Password=[Password];" +
                    "Persist Security Info=True;" +
                    "User ID=[User];" +
                    "Initial Catalog=[Database];" +
                    "Data Source=[Server];" +
                    "TrustServerCertificate=True";
#endif

                optionsBuilder
                    .UseSqlServer(ConnectionString);
            }
            catch (Exception) { throw; }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                modelBuilder.ApplyConfiguration(new UserConfiguration());
                modelBuilder.ApplyConfiguration(new RoleConfiguration());
                modelBuilder.ApplyConfiguration(new MenuConfiguration());
                modelBuilder.ApplyConfiguration(new RoleMenuConfiguration());
                modelBuilder.ApplyConfiguration(new FailureConfiguration());
                modelBuilder.ApplyConfiguration(new ParameterConfiguration());

                //MercaditoAli
                modelBuilder.ApplyConfiguration(new ClientConfiguration());
                modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());

                #region User
                modelBuilder.Entity<User>().HasData(new User
                {
                    UserId = 1,
                    Email = "novillo.matias1@gmail.com",
                    Password = "Pq5FM4q7dDtlZBGcn0w8P0XjnEPDlTCcLUY5/bWVcuVJ4/kXRyHp62hPgry0R/ur+kEspHc+HK6XqqvA8OLXLw==",
                    RoleId = 1,
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<User>().HasData(new User
                {
                    UserId = 2,
                    Email = "kalebem83@gmail.com",
                    Password = "Pq5FM4q7dDtlZBGcn0w8P0XjnEPDlTCcLUY5/bWVcuVJ4/kXRyHp62hPgry0R/ur+kEspHc+HK6XqqvA8OLXLw==",
                    RoleId = 2,
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<User>().HasData(new User
                {
                    UserId = 3,
                    Email = "carlos.e.gariglio@gmail.com",
                    Password = "Pq5FM4q7dDtlZBGcn0w8P0XjnEPDlTCcLUY5/bWVcuVJ4/kXRyHp62hPgry0R/ur+kEspHc+HK6XqqvA8OLXLw==",
                    RoleId = 2,
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<User>().HasData(new User
                {
                    UserId = 4,
                    Email = "martinlermer@hotmail.com",
                    Password = "Pq5FM4q7dDtlZBGcn0w8P0XjnEPDlTCcLUY5/bWVcuVJ4/kXRyHp62hPgry0R/ur+kEspHc+HK6XqqvA8OLXLw==",
                    RoleId = 2,
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<User>().HasData(new User
                {
                    UserId = 5,
                    Email = "paolalocucion@yahoo.com.ar",
                    Password = "Pq5FM4q7dDtlZBGcn0w8P0XjnEPDlTCcLUY5/bWVcuVJ4/kXRyHp62hPgry0R/ur+kEspHc+HK6XqqvA8OLXLw==",
                    RoleId = 2,
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<User>().HasData(new User
                {
                    UserId = 6,
                    Email = "sinapsiscom@gmail.com",
                    Password = "Pq5FM4q7dDtlZBGcn0w8P0XjnEPDlTCcLUY5/bWVcuVJ4/kXRyHp62hPgry0R/ur+kEspHc+HK6XqqvA8OLXLw==",
                    RoleId = 2,
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });
                #endregion

                modelBuilder.Entity<Role>().HasData(new Role
                {
                    RoleId = 1,
                    Name = "Root",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<Role>().HasData(new Role
                {
                    RoleId = 2,
                    Name = "Administrator",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<Role>().HasData(new Role
                {
                    RoleId = 3,
                    Name = "Client",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                #region Menu
                modelBuilder.Entity<Menu>().HasData(new Menu
                {
                    MenuId = 1,
                    Name = "BasicCore",
                    MenuFatherId = 0,
                    Order = 100,
                    URLPath = "",
                    IconURLPath = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<Menu>().HasData(new Menu
                {
                    MenuId = 2,
                    Name = "Failure",
                    MenuFatherId = 1,
                    Order = 0,
                    URLPath = "/BasicCore/FailurePage",
                    IconURLPath = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<Menu>().HasData(new Menu
                {
                    MenuId = 3,
                    Name = "Parameter",
                    MenuFatherId = 1,
                    Order = 0,
                    URLPath = "/BasicCore/ParameterPage",
                    IconURLPath = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<Menu>().HasData(new Menu
                {
                    MenuId = 4,
                    Name = "BasicCulture",
                    MenuFatherId = 0,
                    Order = 200,
                    URLPath = "",
                    IconURLPath = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<Menu>().HasData(new Menu
                {
                    MenuId = 5,
                    Name = "City",
                    MenuFatherId = 4,
                    Order = 0,
                    URLPath = "/BasicCulture/CityPage",
                    IconURLPath = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<Menu>().HasData(new Menu
                {
                    MenuId = 6,
                    Name = "State",
                    MenuFatherId = 4,
                    Order = 0,
                    URLPath = "/BasicCulture/StatePage",
                    IconURLPath = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<Menu>().HasData(new Menu
                {
                    MenuId = 7,
                    Name = "Country",
                    MenuFatherId = 4,
                    Order = 0,
                    URLPath = "/BasicCulture/CountryPage",
                    IconURLPath = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<Menu>().HasData(new Menu
                {
                    MenuId = 8,
                    Name = "Planet",
                    MenuFatherId = 4,
                    Order = 0,
                    URLPath = "/BasicCulture/PlanetPage",
                    IconURLPath = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<Menu>().HasData(new Menu
                {
                    MenuId = 9,
                    Name = "Sex",
                    MenuFatherId = 4,
                    Order = 0,
                    URLPath = "/BasicCulture/SexPage",
                    IconURLPath = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<Menu>().HasData(new Menu
                {
                    MenuId = 10,
                    Name = "CMSCore",
                    MenuFatherId = 0,
                    Order = 300,
                    URLPath = "",
                    IconURLPath = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<Menu>().HasData(new Menu
                {
                    MenuId = 11,
                    Name = "User",
                    MenuFatherId = 10,
                    Order = 0,
                    URLPath = "/CMSCore/UserPage",
                    IconURLPath = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<Menu>().HasData(new Menu
                {
                    MenuId = 12,
                    Name = "Role",
                    MenuFatherId = 10,
                    Order = 0,
                    URLPath = "/CMSCore/RolePage",
                    IconURLPath = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<Menu>().HasData(new Menu
                {
                    MenuId = 13,
                    Name = "Menu",
                    MenuFatherId = 10,
                    Order = 0,
                    URLPath = "/CMSCore/MenuPage",
                    IconURLPath = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<Menu>().HasData(new Menu
                {
                    MenuId = 14,
                    Name = "Permission",
                    MenuFatherId = 10,
                    Order = 0,
                    URLPath = "/CMSCore/Permission",
                    IconURLPath = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<Menu>().HasData(new Menu
                {
                    MenuId = 15,
                    Name = "MercaditoAli",
                    MenuFatherId = 0,
                    Order = 0,
                    URLPath = "",
                    IconURLPath = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<Menu>().HasData(new Menu
                {
                    MenuId = 16,
                    Name = "BlogPost",
                    MenuFatherId = 15,
                    Order = 0,
                    URLPath = "/MercaditoAli/BlogPostPage",
                    IconURLPath = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<Menu>().HasData(new Menu
                {
                    MenuId = 17,
                    Name = "Perfil",
                    MenuFatherId = 15,
                    Order = 0,
                    URLPath = "/MercaditoAli/UserProfilePage",
                    IconURLPath = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<Menu>().HasData(new Menu
                {
                    MenuId = 18,
                    Name = "Agenda",
                    MenuFatherId = 15,
                    Order = 0,
                    URLPath = "/MercaditoAli/AgendaPage",
                    IconURLPath = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<Menu>().HasData(new Menu
                {
                    MenuId = 19,
                    Name = "CarouselTemasDeInteres",
                    MenuFatherId = 15,
                    Order = 0,
                    URLPath = "/MercaditoAli/CarouselTemasDeInteresPage",
                    IconURLPath = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<Menu>().HasData(new Menu
                {
                    MenuId = 20,
                    Name = "MarketplaceServices",
                    MenuFatherId = 15,
                    Order = 0,
                    URLPath = "/MercaditoAli/MarketplacePostServicePage",
                    IconURLPath = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });

                modelBuilder.Entity<Menu>().HasData(new Menu
                {
                    MenuId = 21,
                    Name = "Estadisticas",
                    MenuFatherId = 15,
                    Order = 0,
                    URLPath = "/Estadisticas",
                    IconURLPath = "",
                    Active = true,
                    DateTimeCreation = DateTime.Now,
                    DateTimeLastModification = DateTime.Now,
                    UserCreationId = 1,
                    UserLastModificationId = 1
                });
                #endregion

                #region RoleMenu (Permission)
                modelBuilder.Entity<RoleMenu>().HasData(new RoleMenu
                {
                    RoleMenuId = 1,
                    RoleId = 1,
                    MenuId = 10
                });

                modelBuilder.Entity<RoleMenu>().HasData(new RoleMenu
                {
                    RoleMenuId = 2,
                    RoleId = 1,
                    MenuId = 14
                });
                #endregion
            }
            catch (Exception) { throw; }
        }
    }
}
