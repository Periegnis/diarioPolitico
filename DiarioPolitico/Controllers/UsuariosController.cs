using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiarioPolitico.Models;

namespace DiarioPolitico.Controllers
{
    public class UsuariosController : Controller
    {
        private Context db = new Context();

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(db.users.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.users.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ci,nombre,apellido,email,password,rePassword")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var x = db.users.Where(u => u.email == usuario.email).ToList();
                if (x.Count > 0)
                    ViewBag.errMail = "El mail ya esta registrado en el sistema.";
                else
                {
                    int ci = 0;
                    if (int.TryParse(usuario.ci, out ci))
                    {
                        if (ciValidator(usuario.ci))
                        {

                            db.users.Add(usuario);
                            db.SaveChanges();
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ViewBag.errCi = "La cedula de identidad no es valida.";
                        }
                    }
                    else
                        ViewBag.errCi = "La cedula debe ser numerica.";

                }//el mail ya existe
            }

            return View(usuario);
        }


        bool ciValidator(string ci)
        {
            int[] cint = new int[8];
            char[] txt = ci.ToCharArray();
            //1x2+2x9+3x8+4x7+5x6+6x3+7x4= 148.
            for (int i = 0; i < 8; i++)
            {
                cint[i] = int.Parse(txt[i].ToString());
            }
            int suma = cint[0] * 2 + cint[1] * 9 + cint[2] * 8 + cint[3] * 7 + cint[4] * 6 + cint[5] * 3 + cint[6] * 4;
            int mayor = suma;
            bool mayorEncontrado = false;

            do
            {
                if (mayor % 10 == 0)
                    mayorEncontrado = true;
                else
                    mayor++;

            } while (!mayorEncontrado);

            return (mayor - suma) == cint[7];
        }
        // GET: Usuarios/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.users.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ci,nombre,apellido,email,isAdmin")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.users.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Usuario usuario = db.users.Find(id);
            db.users.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Login()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Login([Bind(Include = "email,password")] Usuario usuario)
        {
            if (usuario.email == null)
            {
                ViewBag.errEmail = "Debe ingresar un email.";
            }
            if (usuario.password == null)
            {
                ViewBag.errPass = "Debe ingresar una contraseña.";
            }
            if (usuario.email != null && usuario.password != null)
            {
                var eluser = db.users.Where(u => u.email == usuario.email).Where(i => i.password == usuario.password).ToList<Usuario>();

                if (eluser.Count == 1)
                {
                    Usuario u = eluser[0];
                    u.apellido = "";
                    u.ci = "";
                    u.password = "";

                    Session["user"] = u;
                    //aca creo una variable global para guardar el usuario 
                    //con el usuario guardado al ir a un proyecto , si lo cree yo no voy a poder comentar, si ya lo comente solo podre modificar mi comentario/like
                    return RedirectToAction("Index", "Home");
                }


                ViewBag.errUser = "Email o Contraseña no son validos, por favor vuelva a intentarlo.";
            }
            return View(usuario);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
