using EventGarden.DTOs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.DTOs.CategoryDTOs
{
    public class CategoryCreateDTO:IDTO
    {
        public string Name { get; set; }
    }
}
