using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DiarioPolitico.Models
{
    public class Comentario
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public int proyecto { get; set; }
        [Required]
        public string comentario { get; set; }
        
        public bool like { get; set; }


        public Comentario() { }

        public Comentario(int p)
        {
            proyecto = p;
        }
    }
}