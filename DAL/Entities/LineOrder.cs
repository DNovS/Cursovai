namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LineOrder")]
    public partial class LineOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id_line { get; set; }

        public int id_order { get; set; }

        public int id_technic { get; set; }

        public int quantity { get; set; }

        public decimal cost { get; set; }

        public virtual Order Order { get; set; }

        public virtual Technic Technic { get; set; }
    }
}
