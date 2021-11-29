using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Models;

[Table("AP_Vargas_Rogery_Alumnos", Schema = "dbo")]
public class Alumno
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("alumno_id")]
    public int Id { get; init; }

    [Required]
    [Column("alumno_apellidos")]
    public string? Apellidos { get; set; }

    [Required]
    [Column("alumno_nombres")]
    public string? Nombres { get; set; }

    [Required]
    [Column("alumno_fechaNacimiento")]
    public DateTime FechaNacimiento { get; set; }

    [Column("alumno_sexo")]
    public char Sexo { get; set; }

    public virtual ICollection<InscripcionCurso>? InscripcionesCursos { get; set; }


}