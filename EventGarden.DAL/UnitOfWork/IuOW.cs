using EventGarden.DAL.Interfaces;
using EventGarden.Entities.Entitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventGarden.DAL.UnitOfWork
{
    public interface IuOW
    {
        IGenericRepository<T> GetRepository<T>() where T : BaseEntity;
        Task SaveChangesAsync();
        void SaveChanges();
    }
}
