using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("AP_Vargas_Rogery_Notas", Schema = "dbo")]
public class Notas
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("nota_id")]
    public int Id { get; init; }

    [Column("nota_practica_1")]
    public float? Practica_1 { get; set; }

    [Column("nota_practica_2")]
    public float? Practica_2 { get; set; }

    [Column("nota_practica_3")]
    public float? Practica_3 { get; set; }

    [Column("nota_parcial")]
    public float? Parcial { get; set; }

    [Column("nota_final")]
    public float? Final { get; set; }

    [ForeignKey("AP_Vargas_Rogery_Inscripciones_curso")]
    [Column("inscripcion_curso_id")]
    public int InscripcionCursoId { get; set; }
    public InscripcionCurso? InscripcionCurso { get; set; }
}