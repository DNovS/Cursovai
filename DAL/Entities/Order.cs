namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            LineOrder = new HashSet<LineOrder>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_order { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime complition_date { get; set; }

        public decimal cost { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime registration_date { get; set; }

        public int id_state { get; set; }

        public int id_client { get; set; }

        public int? id_code { get; set; }

        public virtual Client Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LineOrder> LineOrder { get; set; }

        public virtual PromoCode PromoCode { get; set; }

        public virtual State State { get; set; }
    }
}
