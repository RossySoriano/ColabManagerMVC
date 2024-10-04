using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSS06.Models
{
    public class LabColaborador
    {
        public string Colaborador { get; set; }
        public string NombreColaborador { get; set; }
        public int Estatus { get; set; }
        public string Departamento { get; set; }
        public int Definido { get; set; }
        public string Registrado { get; set; }
    }
}