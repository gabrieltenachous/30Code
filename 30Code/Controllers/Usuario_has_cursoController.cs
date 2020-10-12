using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _30Code.Models;

namespace _30Code.Controllers
{
    public class Usuario_has_cursoController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Usuario_has_curso
        public ActionResult Index()
        {
            var usuario_has_curso = db.Usuario_has_curso.Include(u => u.Curso).Include(u => u.Usuario);
            return View(usuario_has_curso.ToList());
        }

        // GET: Usuario_has_curso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario_has_curso usuario_has_curso = db.Usuario_has_curso.Find(id);
            if (usuario_has_curso == null)
            {
                return HttpNotFound();
            }
            return View(usuario_has_curso);
        }

        // GET: Usuario_has_curso/Create
        public ActionResult Create()
        {
            ViewBag.CursoId = new SelectList(db.Curso, "Id", "Nome");
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome");
            return View();
        }

        // POST: Usuario_has_curso/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UsuarioId,CursoId")] Usuario_has_curso usuario_has_curso)
        {
            if (ModelState.IsValid)
            {
                db.Usuario_has_curso.Add(usuario_has_curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoId = new SelectList(db.Curso, "Id", "Nome", usuario_has_curso.CursoId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome", usuario_has_curso.UsuarioId);
            return View(usuario_has_curso);
        }

        // GET: Usuario_has_curso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario_has_curso usuario_has_curso = db.Usuario_has_curso.Find(id);
            if (usuario_has_curso == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoId = new SelectList(db.Curso, "Id", "Nome", usuario_has_curso.CursoId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome", usuario_has_curso.UsuarioId);
            return View(usuario_has_curso);
        }

        // POST: Usuario_has_curso/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UsuarioId,CursoId")] Usuario_has_curso usuario_has_curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario_has_curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoId = new SelectList(db.Curso, "Id", "Nome", usuario_has_curso.CursoId);
            ViewBag.UsuarioId = new SelectList(db.Usuario, "Id", "Nome", usuario_has_curso.UsuarioId);
            return View(usuario_has_curso);
        }

        // GET: Usuario_has_curso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario_has_curso usuario_has_curso = db.Usuario_has_curso.Find(id);
            if (usuario_has_curso == null)
            {
                return HttpNotFound();
            }
            return View(usuario_has_curso);
        }

        // POST: Usuario_has_curso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario_has_curso usuario_has_curso = db.Usuario_has_curso.Find(id);
            db.Usuario_has_curso.Remove(usuario_has_curso);
            db.SaveChanges();
            return RedirectToAction("Index");
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
