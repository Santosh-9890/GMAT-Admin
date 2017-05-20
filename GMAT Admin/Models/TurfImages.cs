namespace GMAT_Admin
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TurfImages
    {
        public int Id { get; set; }

        public int TurfId { get; set; }

        public string ImageUrl { get; set; }

        [NotMapped]
        [Required]
        public byte[] Image { get; set; }
    }
}
