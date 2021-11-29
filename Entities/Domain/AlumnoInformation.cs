using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Domain
{
    public class AlumnoInformation
    {

        public int Id { get; set; }

        public string? Apellidos { get; set; }

        public string? Nombres { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public char Sexo { get; set; }


        public AlumnoInformation(Alumno alumno)
        {
            Id = alumno.Id;
            Apellidos = alumno.Apellidos;
            Nombres = alumno.Nombres;
            FechaNacimiento = alumno.FechaNacimiento;
            Sexo = alumno.Sexo;
        }
    }
}
