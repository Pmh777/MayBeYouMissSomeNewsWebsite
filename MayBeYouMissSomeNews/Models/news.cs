namespace MayBeYouMissSomeNews.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class news
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public news()
        {
            newsdetails = new HashSet<newsdetail>();
        }

        public int newsid { get; set; }

        [StringLength(100)]
        public string tittle { get; set; }

        public byte? status { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        public DateTime? createddate { get; set; }

        public int? createdby { get; set; }

        public DateTime? modifieddate { get; set; }

        public int? modifiedby { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<newsdetail> newsdetails { get; set; }
    }
}
