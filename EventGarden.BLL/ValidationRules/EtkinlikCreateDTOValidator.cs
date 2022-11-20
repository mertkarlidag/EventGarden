using EventGarden.DTOs.EtkinlikDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.BLL.ValidationRules
{
    public class EtkinlikCreateDTOValidator:AbstractValidator<EtkinlikCreateDTO>
    {
        public EtkinlikCreateDTOValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Etkinlik Adı Gereklidir.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Girilmesi Gereklidir. ");
            RuleFor(x => x.ImagePath).NotEmpty().WithMessage("Etkinlik Resmi Gereklidir");
            RuleFor(x => x.CategoryId).NotEmpty().NotNull().Must(isIdCheck).WithMessage("Kategori Gereklidir");
        }

        private bool isIdCheck(int arg)
        {
            if (arg>0)
            {
                return true;
            }
            return false;
        }
    }
}
