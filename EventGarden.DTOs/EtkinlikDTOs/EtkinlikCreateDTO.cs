using EventGarden.DTOs.CategoryDTOs;
using EventGarden.DTOs.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.DTOs.EtkinlikDTOs
{
    public class EtkinlikCreateDTO:IDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public SelectList Category { get; set; }
        public string ImagePath { get; set; }
        public bool IsStatus { get; set; }
    }
}
