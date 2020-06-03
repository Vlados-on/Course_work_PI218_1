using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork
    {
        ContextRepository<Lot> Lots { get; }

        ContextRepository<Role> Roles { get; }

        ContextRepository<User> Users { get; }
        void Save();
        void Dispose();
    }
}
