using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ViaroTest.Models{
    public class Genero{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Descripcion { get; set; }

        [JsonIgnore]
        public ICollection<Alumno>? Alumnos { get; set; }

        [JsonIgnore]
        public ICollection<Profesor>? Profesors { get; set; }
    }
}