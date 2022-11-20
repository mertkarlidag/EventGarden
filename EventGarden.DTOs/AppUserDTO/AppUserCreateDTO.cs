using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.DTOs.AppUserDTO
{
    public class AppUserCreateDTO
    {
        [Required(ErrorMessage ="Kullanıcı Adı Gereklidir")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Kullanıcı Surname Gereklidir")]



        public string Surname { get; set; }
        [Required(ErrorMessage = "Kullanıcı Username Gereklidir")]



        public string Username { get; set; }
        [Required(ErrorMessage = "Kullanıcı Email Gereklidir")]



        public string Email { get; set; }
        [Required(ErrorMessage = "Kullanıcı Parola Gereklidir")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",ErrorMessage ="Şifre En Az Bir Küçük Karekter,Bir Büyük Karekter,Bir Rakam ve Bir Özel Karekter İçermeli ve En az 8 Karekter Olmalıdır")]




        public string Password { get; set; }
        [Required(ErrorMessage = "Tekrar Parola Gereklidir")]
        [Compare("Password")]



        public string ConfirmPassword { get; set; }
    }
}
