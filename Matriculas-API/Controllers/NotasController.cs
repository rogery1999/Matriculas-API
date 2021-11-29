using Entities.Context;
using Entities.Domain;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Matriculas_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotasController : ControllerBase
    {
        private readonly ExamenContext _context;


        public NotasController(ExamenContext ExamenContext)
        {
            _context = ExamenContext;
        }

        [HttpGet("{id}")]
        public ActionResult<Notas> Get(int id)
        {
            var nota = _context.Notas!.FirstOrDefault(n => n.Id == id);

            if (nota == null) return NotFound();

            return Ok(nota);
        }

        [HttpPut("{id}")]
        public ActionResult<Notas> Update(int id, [FromBody] NotaPayload notaPayload)
        {
            var nota = _context.Notas!.FirstOrDefault(n => n.Id == id);

            if (nota == null) return NotFound();


            nota.Practica_1 = notaPayload.Practica_1;
            nota.Practica_2 = notaPayload.Practica_2;
            nota.Practica_3 = notaPayload.Practica_3;
            nota.Parcial = notaPayload.Parcial;
            nota.Final = notaPayload.Final;

            _context.SaveChanges();
            return Ok(nota);
        }
    }
}
