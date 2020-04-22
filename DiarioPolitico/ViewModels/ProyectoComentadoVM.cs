using DiarioPolitico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiarioPolitico.ViewModels
{
    public class ProyectoComentadoVM
    {
        public int idProyecto { get; set; }
        public string titulo { get; set; }
        public string detalle { get; set; }
        public int puntos { get; set; }
        public List<Comentario> comentarios { get; set; }

        public ProyectoComentadoVM(int proyid)
        {
            Context db = new Context();
            try
            {
                var proy = db.projects.Where(i => i.id == proyid);
                if (proy != null)
                {
                    idProyecto = proyid;
                    foreach(Proyecto p in proy)
                    {
                        titulo = p.titulo;
                        detalle = p.texto;
                    }
                }


                var comments= db.commentaries.Where(i => i.proyecto == proyid);
                if (!(comentarios != null))
                {
                    puntos = 0;
                    comentarios = new List<Comentario>();
                }
                else
                {
                    foreach(Comentario c in comments)
                    {
                        comentarios.Add(c);
                        if(c.like) puntos ++;
                    }
                    puntos /= comentarios.Count;
                }
            }
            catch
            {

            }
            finally
            {

            }
        }
    }
}