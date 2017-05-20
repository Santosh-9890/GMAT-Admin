namespace GMAT_Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BookingSlot
    {
        public int Id { get; set; }

        public string TurfCode { get; set; }

        public string FullName { get; set; }

        public DateTime BookingSlotFrom { get; set; }

        public DateTime BookingSlotTo { get; set; }

        public string InvoiceNo { get; set; }

        public DateTime BookingDate { get; set; }

        public int ChargesPaid { get; set; }

        public string UserMobileNo { get; set; }

        public string RegionCode { get; set; }
    }
}
