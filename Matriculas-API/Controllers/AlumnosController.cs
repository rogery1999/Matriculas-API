using Entities.Context;
using Entities.Domain;
using Entities.Models;
using Matriculas_API.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Matriculas_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlumnosController : ControllerBase
{

    private readonly ExamenContext _context;

    public AlumnosController(ExamenContext ExamenContext)
    {
        _context = ExamenContext;
    }

    [HttpGet]
    public ActionResult<List<AlumnoInformation>> GetAll()
    {
        var Alumnos = _context.Alumnos!.ToList();
        List<AlumnoInformation> alumnosInformation = new(Alumnos!.Count);
        foreach (var alumno in Alumnos)
        {
            alumnosInformation.Add(new(alumno));
        }
        return Ok(alumnosInformation);
    }

    [HttpGet("{id}")]
    public ActionResult<Alumno> GetById(int id)
    {
        var Alumno = _context.Alumnos!
                        .Include(a => a.InscripcionesCursos)!
                            .ThenInclude(ic => ic.Curso)
                        .Include(a => a.InscripcionesCursos)!
                            .ThenInclude(ic => ic.Notas)
                        .FirstOrDefault(a => a.Id == id);

        if (Alumno is null) return NotFound();

        return Ok(Alumno);
    }

    [HttpPost]
    public ActionResult<AlumnoBasicData> Create([FromBody] AlumnoBasicData alumnoBasicData)
    {
        try
        {
            if (alumnoBasicData.Sexo != 'M' && alumnoBasicData.Sexo != 'F')
                return BadRequest("La propiedad sexo no tiene un valor aceptado");

            var fechaValida = DateUtils.FromStringToDatetime(alumnoBasicData.FechaNacimiento);

            Alumno DataAlumno = new() { Apellidos = alumnoBasicData.Apellidos, Nombres = alumnoBasicData.Nombres, FechaNacimiento = fechaValida, Sexo = alumnoBasicData.Sexo };
            _context.Add(DataAlumno);
            _context.SaveChanges();

            return Ok(alumnoBasicData);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpPut("{id}")]
    public ActionResult<Alumno> Update(int id, [FromBody] AlumnoBasicData alumnoBasicData)
    {
        var Alumno = _context.Alumnos!.FirstOrDefault(a => a.Id == id);
        if (Alumno == null) return NotFound();

        try
        {
            var fecha = DateUtils.FromStringToDatetime(alumnoBasicData.FechaNacimiento);

            Alumno.Apellidos = alumnoBasicData.Apellidos;
            Alumno.Sexo = alumnoBasicData.Sexo;
            Alumno.FechaNacimiento = fecha;
            Alumno.Nombres = alumnoBasicData.Nombres;

            _context.SaveChanges();

            return Ok(Alumno);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpDelete("{id}")]
    public ActionResult<Alumno> Delete(int id)
    {
        var alumno = _context.Alumnos!.FirstOrDefault(a => a.Id == id);
        if (alumno == null) return NotFound();

        _context.Alumnos!.Remove(alumno);
        _context.SaveChanges();

        return alumno;
    }
}

