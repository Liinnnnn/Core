using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace projekt1.Data;

public partial class CinemaDbContext : DbContext
{
    public CinemaDbContext()
    {
    }

    public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
        : base(options)
    {
    }


    public virtual DbSet<Cinema> Cinemas { get; set; }

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Showtimes> Showtimes { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=LINHLENOVO\\SQLEXPRESS;Initial Catalog=CinemaDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Cinema>(entity =>
        {
            entity.HasKey(e => e.CinemaId).HasName("PK__Cinema__59C92626DA81D8E0");

            entity.ToTable("Cinema");

            entity.Property(e => e.CinemaId).HasColumnName("CinemaID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(true);
            entity.Property(e => e.CinemaName)
                .HasMaxLength(255)
                .IsUnicode(true);
        });

        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasKey(e => e.FilmId).HasName("PK__Film__6D1D229CAF751CFE");

            entity.ToTable("Film");

            entity.Property(e => e.FilmId).HasColumnName("FilmID");
            entity.Property(e => e.BannerImg)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Director)
                .HasMaxLength(255)
                .IsUnicode(true);
            entity.Property(e => e.FilmImg).HasMaxLength(50);
            entity.Property(e => e.Language)
                .HasMaxLength(50)
                .IsUnicode(true);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(true);
            entity.Property(e => e.suatChieu)
                .HasMaxLength(255)
                .IsUnicode(true);
            
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId)
                  .HasName("PK__Invoice__D796AAD512A91200");
            entity.ToTable("Invoice");
            entity.Property(e => e.InvoiceId)
                  .HasColumnName("InvoiceID");
            entity.Property(e => e.PaymentAmount)   
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PaymentDate)
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .IsUnicode(true);
            entity.Property(e => e.UserId)
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Invoice__UserID__47DBAE45");

            // Thêm liên kết với bảng Ticket
            entity.HasMany(d => d.Tickets).WithOne(p => p.Invoice)
                .HasForeignKey(p => p.InvoiceId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Ticket__InvoiceID");
        });

        modelBuilder.Entity<Showtimes>(entity =>
        {
            entity.HasKey(e => e.ShowtimeId).HasName("PK__Showtime__32D31FC034887DD7");

            entity.ToTable("Showtimes");

            entity.Property(e => e.ShowtimeId).HasColumnName("ShowtimeID");
            entity.Property(e => e.CinemaId).HasColumnName("CinemaID");
            entity.Property(e => e.FilmID).HasColumnName("FilmID");
            entity.Property(e => e.ShowTimeHour).HasColumnName("ShowTimeHour");
            entity.Property(e => e.ShowtimeDate)
                .HasColumnType("datetime")
                .HasColumnName("ShowtimeDate");

            entity.HasOne(d => d.Cinema).WithMany(p => p.Showtimes)
                .HasForeignKey(d => d.CinemaId)
                .HasConstraintName("FK__Showtime__Cinema__412EB0B6");

            entity.HasOne(d => d.Film).WithMany(p => p.Showtimes)
                .HasForeignKey(d => d.FilmID)
                .HasConstraintName("FK__Showtime__FilmID__403A8C7D");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Ticket__712CC6279E1F1C9C");
            entity.ToTable("Ticket");
            entity.Property(e => e.TicketId).HasColumnName("TicketID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SeatNumber).HasMaxLength(10).IsUnicode(false);
            entity.Property(e => e.ShowtimeId).HasColumnName("ShowtimeID");
            entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID"); // Thêm cột InvoiceID trong Ticket

            entity.HasOne(d => d.Showtime).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.ShowtimeId)
                .HasConstraintName("FK__Ticket__Showtime__440B1D61");

            entity.HasOne(d => d.Invoice).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Ticket__InvoiceID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCACABCF6C6F");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.AvatarImg)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(true);
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(true);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}