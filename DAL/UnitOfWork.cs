using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly AuctionContext BD;

        public ContextRepository<Lot> Lots { get; }

        public ContextRepository<Role> Roles { get; }

        public ContextRepository<User> Users { get; }

        private bool Disposed;

        public UnitOfWork(AuctionContext bD, ContextRepository<Lot> lots, ContextRepository<Role> roles, ContextRepository<User> users)
        {
            BD = bD;
            Lots = lots;
            Roles = roles;
            Users = users;

        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed) return;
            if (disposing)
            {
                BD.Dispose();
            }

            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            BD.SaveChanges();
        }
    }
}
