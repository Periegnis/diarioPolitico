using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DiarioPolitico.Models
{
    public class Proyecto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public Usuario user { get; set; }
        [Required]
        public String titulo { get; set; }
        [Required]
        public String texto { get; set; }

        [NotMapped]
        public List<Comentario> comentarios { get; set; }

        public int aprobacion {

            get{
                if (comentarios != null)
                {
                    int pts = 0;
                    foreach (Comentario c in comentarios)
                        if(c.like)
                            pts ++;

                    return pts / comentarios.Count;
                }
                else
                    return 0;
            }
        }
        

        public Proyecto() { }
    }


}