namespace MayBeYouMissSomeNews.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("newsdetail")]
    public partial class newsdetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int categoryid { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int newsid { get; set; }

        [StringLength(3000)]
        public string content { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        public virtual category category { get; set; }

        public virtual news news { get; set; }
    }
}
