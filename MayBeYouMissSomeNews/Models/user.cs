namespace MayBeYouMissSomeNews.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("user")]
    public partial class user
    {
        public int userid { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        public byte? gender { get; set; }

        [StringLength(255)]
        public string photo { get; set; }

        public DateTime? birthday { get; set; }

        [StringLength(10)]
        public string phone { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        public byte? status { get; set; }

        public DateTime? createddate { get; set; }

        public DateTime? modifieddate { get; set; }
    }
}
