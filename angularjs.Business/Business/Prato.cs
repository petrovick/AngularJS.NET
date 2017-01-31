using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace angularjs.Business.Business
{
    [Table("Prato")]
    public class Prato
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPrato { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        //[ForeignKey("IdRestaurante")]
        public int IdRestaurante { get; set; }
        public virtual Restaurante Restaurante { get; set; }
    }
}
