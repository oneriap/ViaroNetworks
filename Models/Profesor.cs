using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViaroTest.Models
{
    public class Profesor{

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(40)]
        public string Apellidos { get; set; }

        [ForeignKey("Genero")]
        public int IdGenero { get; set; }

        public Genero Genero { get; set; }
    }    
}