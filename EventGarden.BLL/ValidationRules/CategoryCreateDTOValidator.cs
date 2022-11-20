using EventGarden.DTOs.CategoryDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.BLL.ValidationRules
{
    public class CategoryCreateDTOValidator:AbstractValidator<CategoryCreateDTO>
    {
        public CategoryCreateDTOValidator()
        {
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Kategori Adı En Az 3 Karekter Olmalıdır");
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Kategori Adı Boş Olmaz");
        }
    }
}
