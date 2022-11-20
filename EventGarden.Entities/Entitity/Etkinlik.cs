using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.Entities.Entitity
{
    public class Etkinlik:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string ImagePath { get; set; }
        public bool IsStatus { get; set; } = false;
        public DateTime CreatedDate { get; set; }=DateTime.Now;
    }
}
