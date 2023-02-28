using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViaroTest.Models{
    public class AlumnoGrado{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [ForeignKey("Alumno")]
        public int IdAlumno { get; set; }

        public Alumno Alumno { get; set; }


        [ForeignKey("Grado")]
        public int IdGrado { get; set; }

        public Grado Grado { get; set; }

        [StringLength(40)]
        public string? SeccionGrupo {get;set;}
    }
}