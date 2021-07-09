namespace MayBeYouMissSomeNews.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class news
    {
        public int newsid { get; set; }

        public int categoryid { get; set; }

        [StringLength(100)]
        public string tittle { get; set; }

        [StringLength(255)]
        public string photo { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(3000)]
        public string content { get; set; }

        public byte? status { get; set; }

        public DateTime? createddate { get; set; }

        public int? createdby { get; set; }

        public DateTime? modifieddate { get; set; }

        public int? modifiedby { get; set; }

        public virtual category category { get; set; }
    }
}
