using MvcCrudProje.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCrudProject.Data.Entities
{
    public class Login : BaseEntity
    {
        [Required (ErrorMessage = "Kullanıcı Adı Boş Geçilemez!")]
        public string KullaniciAdi { get; set; }
        [Required(ErrorMessage = "Şifre Boş Geçilemez!")]
        public string Sifre { get; set; }
    }
}
