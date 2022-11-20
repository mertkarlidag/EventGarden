using EventGarden.DTOs.CategoryDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.BLL.ValidationRules
{
    public class CategoryUpdateDTOValidator:AbstractValidator<CategoryUpdateDTO>
    {
        public CategoryUpdateDTOValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Kategori Adı Gereklidir");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Kategori Adı En Az 3 Karekterden Küçük Olamaz");
        }
    }
}
