namespace GMAT_Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TurfDetail
    {
        [Key]
        public int TurfId { get; set; }

        public string TurfCode { get; set; }

        public string TurfName { get; set; }

        public string TurfEmailId { get; set; }

        public string Address { get; set; }

        public string Synopsis { get; set; }

        public string MobileNo { get; set; }

        public string PhoneNo { get; set; }

        public string Dimensions { get; set; }

        public DateTime AvailableFrom { get; set; }

        public DateTime AvailableTill { get; set; }

        public int DayCharges { get; set; }

        public int NightCharges { get; set; }

        public string RegionCode { get; set; }
    }
}
