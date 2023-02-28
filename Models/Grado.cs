using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViaroTest.Models{
    public class Grado{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Nombre { get; set; }


        [ForeignKey("Profesor")]
        public int? IdProfesor { get; set; }

        public Profesor Profesor { get; set; }

        public ICollection<AlumnoGrado> AlumnoGrados { get; set; }
    }
}