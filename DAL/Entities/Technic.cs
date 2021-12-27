namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Technic")]
    public partial class Technic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Technic()
        {
            LineOrder = new HashSet<LineOrder>();
        }

        [Key]
        public int id_technic { get; set; }

        [StringLength(50)]
        public string specifications { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public int quantity_warehouse { get; set; }

        public decimal cost { get; set; }

        public int id_category { get; set; }

        public string image { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LineOrder> LineOrder { get; set; }
    }
}
