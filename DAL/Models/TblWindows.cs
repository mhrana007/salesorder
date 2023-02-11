using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Windows")]
    public class TblWindows
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Orders")]
        public int OrderId { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required]
        public string WindowName { get; set; }
        [Required]
        public Int16 Quantity { get; set; }
        public virtual ICollection<TblSubElements> SubElements { get; set; } = new List<TblSubElements>();
    }
}
