using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace MVC_NEWBDMATRICULA.Models
{
    public class Cursos
    {
        [Required]
        public string CODCUR { get; set; }
        
        [Required]
        public string CODESP { get; set; }
        
        [Required]
        [StringLength(45, MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z ]+$")]
        public string NOMCUR { get; set; }
        
        [Required]
        [Range(300, 1000)]
        public decimal COSTO { get; set; }
        
        [Required]
        [Range(0, 50)]
        public int NROVAC { get; set; }

        public string ELIMINADO { get; set; }


    }
}