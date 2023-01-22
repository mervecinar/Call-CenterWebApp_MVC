using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;



namespace WebApplication13.Models
{
    public partial class BLM19417EContext : DbContext
    {
        public BLM19417EContext()
        {
        }
        public BLM19417EContext(DbContextOptions<BLM19417EContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<CosRepresantative> CosRepresantatives { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<RequestComplaint> RequestComplaints { get; set; } = null!;
        //public virtual DbSet<Score> Score { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("LAPTOP-GOQUQH5A\\SQLEXPRESS;Database=BLM19417E;Integrated Security=True;Encrypt=False;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<CosRepresantative>(entity =>
            {
                entity.Property(e => e.CosRepresantativeId).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.CosRepresantatives)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__CosRepresantatives__Depar__398D8EEE");
            });


            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.CosRepresantative)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CosRepresantativeId)
                    .HasConstraintName("FK__Customers__CosRepresantative__398D8EEE");
            });
            modelBuilder.Entity<RequestComplaint>(entity =>
            {
                entity.Property(e => e.RequestComplaintId).ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Text)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.RequestComplaints)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__RequestComplaints__Customer__398D8EEE");
            });
            //modelBuilder.Entity<Score>(entity =>
            //{
            //    entity.Property(e => e.CosRepresantativeId ).ValueGeneratedNever();

            //    entity.HasOne(d => d.Customer)
            //        .WithMany(p => p.Score)
            //        .HasForeignKey(d => d.CosRepresantativeId)
            //        .HasConstraintName("FK__Score__Customer__398D8EEE");
            //});



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
