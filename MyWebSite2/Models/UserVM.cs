using MyWebSite2.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebSite2.Models
{
    public class UserVM
    {
        public int UserId { get; set; }

        [Required(ErrorMessage ="Lütfen isim alanını boş geçmeyin")]
        [MaxLength(20,ErrorMessage ="İsim alanı 20 karakterden fazla olamaz")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lütfen isim alanını boş geçmeyin")]
        [MaxLength(20, ErrorMessage = "İsim alanı 20 karakterden fazla olamaz")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Lütfen isim alanını boş geçmeyin")]
        [MaxLength(20, ErrorMessage = "İsim alanı 20 karakterden fazla olamaz")]
        [EmailAddress(ErrorMessage ="Mail formatına uygun giriş yapınız.")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Parolayı boş geçemezsiniz!!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Cinsiyeti boş geçemezsiniz!!")]
        public bool Gender { get; set; }
    }
}