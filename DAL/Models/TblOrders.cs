using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Orders")]
    public class TblOrders
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required]
        public string OrderName { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]
        [Required]
        public string State { get; set; }
        public virtual ICollection<TblWindows> Windows { get; set; } = new List<TblWindows>();
    }
}
