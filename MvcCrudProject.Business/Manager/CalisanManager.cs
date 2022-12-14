using MvcCrudProje.Models;
using MvcCrudProje.Models.Context;
using MvcCrudProject.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCrudProject.Business.Manager
{
    public class CalisanManager : ICalisanManager
    {
        //public void Ekle(Calisan calisan)
        //{
        //    using (CrudDbContext db = new CrudDbContext())
        //    {
        //        db.Calisan.Add(calisan);
        //        db.SaveChanges();
        //    }
        //}

        //public void Guncelle(Calisan calisan)
        //{
        //    using (CrudDbContext db = new CrudDbContext())
        //    {
        //        db.Entry(calisan).State = EntityState.Modified;
        //        db.SaveChanges();
        //    }
        //}


        public List<Calisan> HepsiniGetir()
        {
            using (CrudDbContext db = new CrudDbContext())
            {
                return db.Calisan.ToList();
            }
        }

        public Calisan IdyeGoreGetir(int id)
        {
            using (CrudDbContext db = new CrudDbContext())
            {
                return db.Calisan.FirstOrDefault(x => x.Id == id);
            }
        }

        public void Kaydet(Calisan calisan)
        {
            using (CrudDbContext db = new CrudDbContext())
            {
                if (calisan.Id == 0)
                {
                    db.Calisan.Add(calisan);
                }
                else
                {
                    var guncellenecekCalisan = db.Calisan.Find(calisan.Id);
                    if (guncellenecekCalisan == null)
                    {
                        return;
                    }
                    var kontrol = db.Calisan.Find(calisan.departmanId);
                    if (kontrol == null)
                    {
                        return;
                    }
                    //if (calisan.departmanId == null)
                    //{

                    //}
                    guncellenecekCalisan.Ad = calisan.Ad;
                    guncellenecekCalisan.Soyad = calisan.Soyad;
                    guncellenecekCalisan.Maas = calisan.Maas;
                    guncellenecekCalisan.departmanId = calisan.departmanId;
                }
                db.SaveChanges();
            }
        }

        public void Sil(int id)
        {
            using (CrudDbContext db = new CrudDbContext())
            {
                var silinecekCalisan = db.Calisan.Find(id);
                db.Calisan.Remove(silinecekCalisan);
                db.SaveChanges();
            }
        }
    }
}
