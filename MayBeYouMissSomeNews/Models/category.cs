namespace MayBeYouMissSomeNews.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("category")]
    public partial class category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public category()
        {
            news = new HashSet<news>();
        }

        public int categoryid { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        public byte? status { get; set; }

        public DateTime? createddate { get; set; }

        public int? createdby { get; set; }

        public DateTime? modifieddate { get; set; }

        public int? modifiedby { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<news> news { get; set; }
    }
}
