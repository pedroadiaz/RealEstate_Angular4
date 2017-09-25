using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MySql.Data.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace RealEstate_Angular4.models
{
    public partial class realestateContext : DbContext
    {
        public virtual DbSet<Agent> Agent { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyBilling> CompanyBilling { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<House> House { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<ImageLink> ImageLink { get; set; }
        public virtual DbSet<PermissionLevel> PermissionLevel { get; set; }
        public virtual DbSet<Propertytype> Propertytype { get; set; }
        public virtual DbSet<SalesPerson> SalesPerson { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseMySQL(@"server=easeewaste.crcy3axworup.us-west-2.rds.amazonaws.com;user id=EFUser;database=realestate;password=Citlali890Leo.;sslmode=none;port=3306;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>(entity =>
            {
                entity.HasKey(e => new { e.AgentId, e.CompanyId, e.UserLoginId })
                    .HasName("PK_Agent");

                entity.ToTable("Agent", "realestate");

                entity.HasIndex(e => e.AgentId)
                    .HasName("PRIMARY")
                    .IsUnique();

                entity.HasIndex(e => e.CompanyId)
                    .HasName("Agent_Company_idx");

                entity.HasIndex(e => e.UserLoginId)
                    .HasName("Agent_UserLogin_idx");

                entity.Property(e => e.AgentId).HasColumnType("int(11)");

                entity.Property(e => e.CompanyId).HasColumnType("int(11)");

                entity.Property(e => e.UserLoginId).HasColumnType("int(11)");

                entity.Property(e => e.Address1)
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Address2)
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.AgentImage)
                    .HasColumnType("varchar(500)")
                    .HasMaxLength(500);

                entity.Property(e => e.AgentName)
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.City)
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);

                entity.Property(e => e.State)
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50);

                entity.Property(e => e.ZipCode)
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => new { e.CompanyId, e.EmployeeId })
                    .HasName("PK_Company");

                entity.ToTable("Company", "realestate");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("PRIMARY")
                    .IsUnique();

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("Company_EmployeeId_idx");

                entity.Property(e => e.CompanyId).HasColumnType("int(11)");

                entity.Property(e => e.EmployeeId).HasColumnType("int(11)");

                entity.Property(e => e.Address1)
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Address2)
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.City)
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.CompanyName)
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Created).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);

                entity.Property(e => e.State)
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);

                entity.Property(e => e.WebSite)
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.ZipCode)
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<CompanyBilling>(entity =>
            {
                entity.HasKey(e => new { e.CompanyBillingId, e.CompanyId })
                    .HasName("PK_CompanyBilling");

                entity.ToTable("CompanyBilling", "realestate");

                entity.HasIndex(e => e.CompanyBillingId)
                    .HasName("PRIMARY")
                    .IsUnique();

                entity.HasIndex(e => e.CompanyId)
                    .HasName("CompanyBilling_Company_idx");

                entity.Property(e => e.CompanyBillingId).HasColumnType("int(11)");

                entity.Property(e => e.CompanyId).HasColumnType("int(11)");

                entity.Property(e => e.Address1)
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Address2)
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Amount).HasColumnType("decimal(8,2)");

                entity.Property(e => e.BillingCycle).HasColumnType("int(11)");

                entity.Property(e => e.BillingName)
                    .HasColumnType("varchar(200)")
                    .HasMaxLength(200);

                entity.Property(e => e.City)
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);

                entity.Property(e => e.State)
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);

                entity.Property(e => e.ZipCode)
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.UserLoginId })
                    .HasName("PK_Employee");

                entity.ToTable("Employee", "realestate");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("PRIMARY")
                    .IsUnique();

                entity.HasIndex(e => e.UserLoginId)
                    .HasName("Employee_UserLogin_idx");

                entity.Property(e => e.EmployeeId).HasColumnType("int(11)");

                entity.Property(e => e.UserLoginId).HasColumnType("int(11)");

                entity.Property(e => e.Address1)
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Address2)
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.City)
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.LastName)
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.MobilePhone)
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);

                entity.Property(e => e.Ssn)
                    .HasColumnName("SSN")
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);

                entity.Property(e => e.State)
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);

                entity.Property(e => e.ZipCode)
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<House>(entity =>
            {
                entity.HasKey(e => new { e.Houseid, e.AgentId, e.PropertyTypeId })
                    .HasName("PK_house");

                entity.ToTable("house", "realestate");

                entity.HasIndex(e => e.AgentId)
                    .HasName("agentid_idx");

                entity.HasIndex(e => e.Houseid)
                    .HasName("PRIMARY")
                    .IsUnique();

                entity.HasIndex(e => e.PropertyTypeId)
                    .HasName("propertytype_fk_idx");

                entity.Property(e => e.Houseid)
                    .HasColumnName("houseid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AgentId).HasColumnType("int(11)");

                entity.Property(e => e.PropertyTypeId).HasColumnType("int(11)");

                entity.Property(e => e.Bathrooms).HasColumnType("decimal(3,2)");

                entity.Property(e => e.Bedrooms).HasColumnType("int(11)");

                entity.Property(e => e.City)
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100);

                entity.Property(e => e.HouseUrl)
                    .HasColumnName("HouseURL")
                    .HasColumnType("varchar(512)")
                    .HasMaxLength(512);

                entity.Property(e => e.Latitude).HasColumnType("decimal(8,5)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(8,5)");

                entity.Property(e => e.MainImage)
                    .HasColumnType("varchar(512)")
                    .HasMaxLength(512);

                entity.Property(e => e.Mls)
                    .HasColumnName("MLS")
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);

                entity.Property(e => e.Price).HasColumnType("decimal(7,0)");

                entity.Property(e => e.State)
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);

                entity.Property(e => e.StreetAddress)
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.StreetAddress2)
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.ZipCode)
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => new { e.ImageId, e.Houseid })
                    .HasName("PK_image");

                entity.ToTable("image", "realestate");

                entity.HasIndex(e => e.Houseid)
                    .HasName("houseid_idx");

                entity.HasIndex(e => e.ImageId)
                    .HasName("PRIMARY")
                    .IsUnique();

                entity.Property(e => e.ImageId).HasColumnType("int(11)");

                entity.Property(e => e.Houseid)
                    .HasColumnName("houseid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImagePath)
                    .HasColumnType("varchar(512)")
                    .HasMaxLength(512);

                entity.Property(e => e.ShortDescription)
                    .HasColumnType("varchar(100)")
                    .HasMaxLength(100);

                entity.Property(e => e.SortOrder)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<ImageLink>(entity =>
            {
                entity.HasKey(e => new { e.ImageLinkId, e.ChildImageId, e.ParentImageId })
                    .HasName("PK_ImageLink");

                entity.ToTable("ImageLink", "realestate");

                entity.HasIndex(e => e.ChildImageId)
                    .HasName("ChildImageLink_idx");

                entity.HasIndex(e => e.ImageLinkId)
                    .HasName("PRIMARY")
                    .IsUnique();

                entity.HasIndex(e => e.ParentImageId)
                    .HasName("ParentImageLink_idx");

                entity.Property(e => e.ImageLinkId).HasColumnType("int(11)");

                entity.Property(e => e.ChildImageId).HasColumnType("int(11)");

                entity.Property(e => e.ParentImageId).HasColumnType("int(11)");

                entity.Property(e => e.Xposition)
                    .HasColumnName("XPosition")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Yposition)
                    .HasColumnName("YPosition")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<PermissionLevel>(entity =>
            {
                entity.ToTable("PermissionLevel", "realestate");

                entity.Property(e => e.PermissionLevelId).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Propertytype>(entity =>
            {
                entity.ToTable("propertytype", "realestate");

                entity.Property(e => e.PropertyTypeId)
                    .HasColumnName("PropertyTypeID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PropertyType)
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<SalesPerson>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.EmployeeId1 })
                    .HasName("PK_SalesPerson");

                entity.ToTable("SalesPerson", "realestate");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("PRIMARY")
                    .IsUnique();

                entity.Property(e => e.EmployeeId).HasColumnType("int(11)");

                entity.Property(e => e.EmployeeId1)
                    .HasColumnName("EmployeeId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CommissionAmount).HasColumnType("decimal(4,2)");

                entity.Property(e => e.Salary).HasColumnType("decimal(9,2)");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => new { e.UserLoginId, e.PermissionLevel })
                    .HasName("PK_UserLogin");

                entity.ToTable("UserLogin", "realestate");

                entity.HasIndex(e => e.PermissionLevel)
                    .HasName("UserLogin_PermissionLevel_idx");

                entity.HasIndex(e => e.UserLoginId)
                    .HasName("PRIMARY")
                    .IsUnique();

                entity.Property(e => e.UserLoginId).HasColumnType("int(11)");

                entity.Property(e => e.PermissionLevel).HasColumnType("int(11)");

                entity.Property(e => e.Password)
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);

                entity.Property(e => e.Username)
                    .HasColumnType("varchar(45)")
                    .HasMaxLength(45);
            });
        }
    }
}