using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_NEWBDMATRICULA.Models
{
    public class pa_cursos_por_costo
    {
        public string CODCUR { get; set; }
        public string NOMCUR { get; set; }
        public decimal COSTO { get; set; }
        public int NROVAC { get; set; }
    }
}