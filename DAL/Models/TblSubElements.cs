using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("SubElements")]
    public class TblSubElements
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Windows")]
        public int WindowId { get; set; }
        [Required]
        public Int16 ElementNumber { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Required]
        public string Type { get; set; }
        [Required]
        public Int16 Width { get; set; }
        [Required]
        public Int16 Height { get; set; }
        
    }
}
