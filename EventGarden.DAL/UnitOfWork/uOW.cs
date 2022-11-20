using EventGarden.DAL.Concretes;
using EventGarden.DAL.Contexts;
using EventGarden.DAL.Interfaces;
using EventGarden.Entities.Entitity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.DAL.UnitOfWork
{
    public class uOW:IuOW
    {
        private readonly AppDbContext _context;

        public uOW(AppDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new GenericRepository<T>(_context);//REPOSİTORY NESNESİ ÜRETİYORUZ CONSTRUCTIRINA DA _CONTEXT NESNEMİZİ GEÇİYORUZ
            //DI DAN ALDIĞIIMIZ
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
