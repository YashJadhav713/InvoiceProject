using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InvoiceProject.Models;

public partial class ApisContext : DbContext
{
    public ApisContext()
    {
    }

    public ApisContext(DbContextOptions<ApisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCustomer> TblCustomers { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblinvoiceDetail> TblinvoiceDetails { get; set; }

    public virtual DbSet<TblinvoicePayment> TblinvoicePayments { get; set; }

    public virtual DbSet<TblinvoiceProduct> TblinvoiceProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=YASH; Database=apis; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__TblCusto__8CB286B9538F8CC3");

            entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Customer_Name");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__TblProdu__9834FB9AC8EA3B27");

            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Product_Name");
        });

        modelBuilder.Entity<TblinvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK__Tblinvoi__0DE604946956D604");

            entity.ToTable("Tblinvoice_details");

            entity.Property(e => e.InvoiceId).HasColumnName("Invoice_ID");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");
            entity.Property(e => e.InvoiceDate).HasColumnName("Invoice_Date");
            entity.Property(e => e.TotalAmount)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.TblinvoiceDetails)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("cusid");
        });

        modelBuilder.Entity<TblinvoicePayment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Tblinvoi__DA6C7FE173E5DF61");

            entity.ToTable("Tblinvoice_payments");

            entity.Property(e => e.PaymentId).HasColumnName("Payment_ID");
            entity.Property(e => e.InvoiceId).HasColumnName("Invoice_ID");
            entity.Property(e => e.PaymentAmount).HasColumnName("Payment_Amount");
            entity.Property(e => e.PaymentDescription)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Payment_Description");
            entity.Property(e => e.PaymentMode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Payment_Mode");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");

            entity.HasOne(d => d.Invoice).WithMany(p => p.TblinvoicePayments)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("invoiceid");

            entity.HasOne(d => d.Product).WithMany(p => p.TblinvoicePayments)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("productid");
        });

        modelBuilder.Entity<TblinvoiceProduct>(entity =>
        {
            entity.HasKey(e => e.InvoiceproductId).HasName("PK__Tblinvoi__9E04A4FC7E5AF493");

            entity.ToTable("Tblinvoice_products");

            entity.Property(e => e.InvoiceproductId).HasColumnName("Invoiceproduct_ID");
            entity.Property(e => e.InvoiceId).HasColumnName("Invoice_ID");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");

            entity.HasOne(d => d.Invoice).WithMany(p => p.TblinvoiceProducts)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("iid");

            entity.HasOne(d => d.Product).WithMany(p => p.TblinvoiceProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("pid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
