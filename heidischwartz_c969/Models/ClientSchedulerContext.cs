using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace heidischwartz_c969.Models;

public partial class ClientSchedulerContext : DbContext
{
    public ClientSchedulerContext()
    {
    }

    public ClientSchedulerContext(DbContextOptions<ClientSchedulerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // connection string is hardcoded here for evaluation lab environment
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=sqlUser;password=Passw0rd!;database=client_schedule", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.37-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PRIMARY");

            entity.ToTable("address");

            entity.HasIndex(e => e.CityId, "cityId");

            entity.Property(e => e.AddressId).HasColumnName("addressId");
            entity.Property(e => e.Address1)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .HasColumnName("address2");
            entity.Property(e => e.CityId).HasColumnName("cityId");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .HasColumnName("createdBy");
            entity.Property(e => e.LastUpdate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("lastUpdate");
            entity.Property(e => e.LastUpdateBy)
                .HasMaxLength(40)
                .HasColumnName("lastUpdateBy");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .HasColumnName("postalCode");

            entity.HasOne(d => d.City).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("address_ibfk_1");
        });

        modelBuilder.Entity<Appointment>(entity =>
    {
        entity.HasKey(e => e.AppointmentId).HasName("PRIMARY");

        entity.ToTable("appointment");

        entity.HasIndex(e => e.CustomerId, "appointment_ibfk_1");

        entity.HasIndex(e => e.UserId, "userId");

        entity.Property(e => e.AppointmentId).HasColumnName("appointmentId");
        entity.Property(e => e.Contact)
            .HasColumnType("text")
            .HasColumnName("contact");
        entity.Property(e => e.CreateDate)
            .HasColumnType("datetime")
            .HasColumnName("createDate");
        entity.Property(e => e.CreatedBy)
            .HasMaxLength(40)
            .HasColumnName("createdBy");
        entity.Property(e => e.CustomerId).HasColumnName("customerId");
        entity.Property(e => e.Description)
            .HasColumnName("description");
        entity.Property(e => e.End)
            .HasColumnType("datetime")
            .HasColumnName("end");
        entity.Property(e => e.LastUpdate)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("timestamp")
            .HasColumnName("lastUpdate");
        entity.Property(e => e.LastUpdateBy)
            .HasMaxLength(40)
            .HasColumnName("lastUpdateBy");
        entity.Property(e => e.Location)
            .HasColumnType("text")
            .HasColumnName("location");
        entity.Property(e => e.Start)
            .HasColumnType("datetime")
            .HasColumnName("start");
        entity.Property(e => e.Title)
            .HasMaxLength(255)
            .HasColumnName("title");
        entity.Property(e => e.Type)
            .HasColumnType("text")
            .HasColumnName("type");
        entity.Property(e => e.Url)
            .HasMaxLength(255)
            .HasColumnName("url");
        entity.Property(e => e.UserId).HasColumnName("userId");

        entity.HasOne(d => d.Customer).WithMany(p => p.Appointments)
            .HasForeignKey(d => d.CustomerId)
            .OnDelete(DeleteBehavior.Cascade) // Enable cascading deletes
            .HasConstraintName("appointment_ibfk_1");

        entity.HasOne(d => d.User).WithMany(p => p.Appointments)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("appointment_ibfk_2");
    });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PRIMARY");

            entity.ToTable("city");

            entity.HasIndex(e => e.CountryId, "countryId");

            entity.Property(e => e.CityId).HasColumnName("cityId");
            entity.Property(e => e.City1)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.CountryId).HasColumnName("countryId");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .HasColumnName("createdBy");
            entity.Property(e => e.LastUpdate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("lastUpdate");
            entity.Property(e => e.LastUpdateBy)
                .HasMaxLength(40)
                .HasColumnName("lastUpdateBy");

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("city_ibfk_1");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PRIMARY");

            entity.ToTable("country");

            entity.Property(e => e.CountryId).HasColumnName("countryId");
            entity.Property(e => e.Country1)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .HasColumnName("createdBy");
            entity.Property(e => e.LastUpdate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("lastUpdate");
            entity.Property(e => e.LastUpdateBy)
                .HasMaxLength(40)
                .HasColumnName("lastUpdateBy");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.ToTable("customer");

            entity.HasIndex(e => e.AddressId, "addressId");

            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.AddressId).HasColumnName("addressId");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .HasColumnName("createdBy");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(45)
                .HasColumnName("customerName");
            entity.Property(e => e.LastUpdate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("lastUpdate");
            entity.Property(e => e.LastUpdateBy)
                .HasMaxLength(40)
                .HasColumnName("lastUpdateBy");

            entity.HasOne(d => d.Address).WithMany(p => p.Customers)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("customer_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("createDate");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(40)
                .HasColumnName("createdBy");
            entity.Property(e => e.LastUpdate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("lastUpdate");
            entity.Property(e => e.LastUpdateBy)
                .HasMaxLength(40)
                .HasColumnName("lastUpdateBy");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("userName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
