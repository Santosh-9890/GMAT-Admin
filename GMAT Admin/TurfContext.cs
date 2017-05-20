namespace GMAT_Admin
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TurfContext : DbContext
    {
        public TurfContext()
            : base("name=TurfContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        //public virtual DbSet<BookingSlot> BookingSlots { get; set; }
        public virtual DbSet<TurfDetail> TurfDetails { get; set; }
        public virtual DbSet<TurfImages> TurfImages { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
