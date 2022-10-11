using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCrudProject.Business.Repository.GenericRepositoryInterface
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> HepsiniGetir();
        T IdyeGoreGetir(int id);
        //void Kaydet(T entity);
        void Ekle(T entity);
        void Guncelle(T entity);
        void Sil(int id);
    }
}
