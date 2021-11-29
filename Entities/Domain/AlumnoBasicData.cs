using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Domain
{
    public class AlumnoBasicData
    {
        public string Apellidos { get; set; }

        public string Nombres { get; set; }

        public string FechaNacimiento { get; set; }

        public char Sexo { get; set; }
    }
}
