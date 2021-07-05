namespace MayBeYouMissSomeNews.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("employee")]
    public partial class employee
    {
        public int employeeid { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(255)]
        public string photo { get; set; }

        public byte? gender { get; set; }

        public DateTime? birthday { get; set; }

        public byte? status { get; set; }

        public byte? type { get; set; }

        [Required]
        [StringLength(100)]
        public string gmail { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        public DateTime? createddate { get; set; }

        public int? createdby { get; set; }

        public DateTime? modifieddate { get; set; }

        public int? modifiedby { get; set; }
    }
}
