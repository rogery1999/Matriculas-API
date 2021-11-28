using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("AP_Vargas_Rogery_Cursos", Schema = "dbo")]
public class Curso
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("curso_id")]
    public int Id { get; init; }

    [Required]
    [Column("curso_nombre")]
    public string? Nombre { get; set; }

    [Required]
    [Column("curso_descripcion")]
    public string? Descripcion { get; set; }

    [Required]
    [Column("curso_obligatoriedad")]
    public bool Obligatoriedad { get; set; }
    //public byte Obligatoriedad { get; set; }

    public virtual ICollection<InscripcionCurso>? InscripcionesCursos { get; set; }
}