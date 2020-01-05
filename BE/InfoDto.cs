using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class InfoDto
    {
        public string Ruc { get; set; }
        public string RazonSocial { get; set; }
        public string TipoVia { get; set; }
        public string NombreVia { get; set; }
        public string CodigoZona { get; set; }
        public string TipoZona { get; set; }
        public string Numero { get; set; }
        public string Interior { get; set; }
        public string Lote { get; set; }
        public string Departamento { get; set; }
        public string Manzana { get; set; }
        public List<DetailDto> details { get; set; }
    }

    public class DetailDto
    {
        public string TipoVia { get; set; }
        public string NombreVia { get; set; }
        public string CodigoZona { get; set; }
        public string TipoZona { get; set; }
        public string Numero { get; set; }
        public string Interior { get; set; }
        public string Lote { get; set; }
        public string Departamento { get; set; }
        public string Manzana { get; set; }
        public string Kilometro { get; set; }
    }
}
