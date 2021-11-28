using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("AP_Vargas_Rogery_Inscripciones_curso", Schema = "dbo")]
    public class InscripcionCurso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("inscripcion_curso_id")]
        public int Id { get; init; }

        [ForeignKey("AP_Vargas_Rogery_Alumnos")]
        [Column("alumno_id")]
        public int AlumnoId { get; init; }
        public Alumno? Alumno { get; init; }

        [ForeignKey("AP_Vargas_Rogery_Cursos")]
        [Column("curso_id")]
        public int CursoId { get; init; }
        public Curso? Curso { get; init; }

        public virtual Notas? Notas { get; init; }
    }
}
