namespace Pradadge.Entities.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PradadgeContext : DbContext
    {
        public PradadgeContext()
            : base("name=PradadgeContext")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tbl_Branch> tbl_Branch { get; set; }
        public virtual DbSet<tbl_Brand> tbl_Brand { get; set; }
        public virtual DbSet<tbl_Category> tbl_Category { get; set; }
        public virtual DbSet<tbl_Company> tbl_Company { get; set; }
        public virtual DbSet<tbl_Country> tbl_Country { get; set; }
        public virtual DbSet<tbl_Customer> tbl_Customer { get; set; }
        public virtual DbSet<tbl_Damages> tbl_Damages { get; set; }
        public virtual DbSet<tbl_Measurement> tbl_Measurement { get; set; }
        public virtual DbSet<tbl_Payment> tbl_Payment { get; set; }
        public virtual DbSet<tbl_PaymentMode> tbl_PaymentMode { get; set; }
        public virtual DbSet<tbl_Product> tbl_Product { get; set; }
        public virtual DbSet<tbl_PurchaseOrder> tbl_PurchaseOrder { get; set; }
        public virtual DbSet<tbl_PurchaseOrderDetail> tbl_PurchaseOrderDetail { get; set; }
        public virtual DbSet<tbl_ReferenceManager> tbl_ReferenceManager { get; set; }
        public virtual DbSet<tbl_SalesDetails> tbl_SalesDetails { get; set; }
        public virtual DbSet<tbl_SalesType> tbl_SalesType { get; set; }
        public virtual DbSet<tbl_Section> tbl_Section { get; set; }
        public virtual DbSet<tbl_Staff> tbl_Staff { get; set; }
        public virtual DbSet<tbl_State> tbl_State { get; set; }
        public virtual DbSet<tbl_Stock> tbl_Stock { get; set; }
        public virtual DbSet<tbl_StockCard> tbl_StockCard { get; set; }
        public virtual DbSet<tbl_TransactionStatus> tbl_TransactionStatus { get; set; }
        public virtual DbSet<tbl_Vendor> tbl_Vendor { get; set; }
        public virtual DbSet<tbl_VendorPayment> tbl_VendorPayment { get; set; }
        public virtual DbSet<tbl_Banks> tbl_Banks { get; set;}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Branch>()
                .HasMany(e => e.tbl_SalesDetails)
                .WithRequired(e => e.tbl_Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Company>()
                .HasMany(e => e.tbl_ReferenceManager)
                .WithRequired(e => e.tbl_Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Measurement>()
                .Property(e => e.UOM)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Payment>()
                .HasMany(e => e.tbl_SalesDetails)
                .WithRequired(e => e.tbl_Payment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_PaymentMode>()
                .HasMany(e => e.tbl_Payment)
                .WithRequired(e => e.tbl_PaymentMode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_PaymentMode>()
                .HasMany(e => e.tbl_VendorPayment)
                .WithRequired(e => e.tbl_PaymentMode)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Product>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Product>()
                .Property(e => e.ProductDescription)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Product>()
                .Property(e => e.ProductBarCode)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Product>()
                .Property(e => e.InSquareMeters)
                .HasPrecision(38, 6);

            modelBuilder.Entity<tbl_Product>()
                .HasMany(e => e.tbl_PurchaseOrderDetail)
                .WithRequired(e => e.tbl_Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Product>()
                .HasMany(e => e.tbl_SalesDetails)
                .WithRequired(e => e.tbl_Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Product>()
                .HasMany(e => e.tbl_Stock)
                .WithRequired(e => e.tbl_Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_PurchaseOrder>()
                .HasMany(e => e.tbl_PurchaseOrderDetail)
                .WithRequired(e => e.tbl_PurchaseOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_PurchaseOrder>()
                .HasMany(e => e.tbl_Stock)
                .WithRequired(e => e.tbl_PurchaseOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_SalesType>()
                .HasMany(e => e.tbl_Payment)
                .WithRequired(e => e.tbl_SalesType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Stock>()
                .HasMany(e => e.tbl_SalesDetails)
                .WithRequired(e => e.tbl_Stock)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Stock>()
                .HasMany(e => e.tbl_StockCard)
                .WithRequired(e => e.tbl_Stock)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Vendor>()
                .HasMany(e => e.tbl_VendorPayment)
                .WithRequired(e => e.tbl_Vendor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Banks>()
                .Property(e => e.BankName)
                .IsUnicode(false);
        }
    }
}
