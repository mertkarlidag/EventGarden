using EventGarden.DTOs.EtkinlikDTOs;
using EventGarden.DTOs.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.DTOs.CategoryDTOs
{
    public class CategoryListDTO:IDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EtkinlikListDTO> Etkinliks { get; set; }
    }
}
