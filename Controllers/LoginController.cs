using MvcCrudProje.Models.Context;
using MvcCrudProject.Business.Manager;
using MvcCrudProject.Business.Repository.GenericRepositoryManager;
using MvcCrudProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCrudProje.Controllers
{
    public class LoginController : Controller
    {
        GenericRepository<Login> repo = new GenericRepository<Login>();
        CrudDbContext db = new CrudDbContext();
        // GET: Login
        public ActionResult Index()
        {
            List<Login> giris = repo.HepsiniGetir();
            return View(giris);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            var kullanici = db.Login.FirstOrDefault(x => x.KullaniciAdi == login.KullaniciAdi && x.Sifre == login.Sifre);
            if (kullanici != null)
            {
                return RedirectToAction("Index", "Departman");
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult Ekle()
        {
            return View("Ekle");
        }

        [HttpPost]
        public ActionResult Ekle(Login login)
        {
            repo.Ekle(login);
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Guncelle(Login login)
        {
            repo.Guncelle(login);
            return RedirectToAction("Login", "Login");
        }

        public ActionResult Guncelle(int id)
        {
            var model = db.Login.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("Guncelle", model);
        }

        public ActionResult Sil(int id)
        {
            repo.Sil(id);
            return RedirectToAction("Index");
        }
    }
}