using Entities.Context;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

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
    public ActionResult<List<Alumno>> GetAll()
    {
        List<Alumno> Alumnos = new() { new Alumno() { Apellidos = "Vargas", FechaNacimiento = new DateTime(1999, 8, 17), Nombres = "Rogery", Sexo = 'M' } };
        string alumnos = "";
        foreach (var alumno in Alumnos)
        {
            alumnos += alumno.ToString();
        }

        Console.WriteLine(alumnos);
        return Alumnos;
    }

    [HttpGet("{id}")]
    public ActionResult<Alumno> GetById(int id)
    {
        Console.WriteLine($"el id enviado en la ruta es => { id }");
        if (id > 10)
        {
            return NotFound();
        }
        return new Alumno() { Apellidos = "Vargas" };
    }

    [HttpPost]
    public ActionResult<Alumno> Create(Alumno Alumno)
    {
        return new Alumno() { Apellidos = "Vargas" };
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Alumno>> Update(Alumno alumno)
    {
        return new Alumno();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Alumno>> Delete(int id)
    {
        return new Alumno();
    }
}

