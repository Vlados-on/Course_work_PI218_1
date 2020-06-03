
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start
{
    class Program
    {
        static void Main(string[] args)
        {
            AuctionContext context = new AuctionContext();
            UnitOfWork uow = new UnitOfWork(context, new ContextRepository<Lot>(context), new ContextRepository<Role>(context), new ContextRepository<User>(context));

            uow.Roles.Create(new Role() { Role_name = "Admin" });
            uow.Roles.Create(new Role() { Role_name = "Manager" });
            uow.Roles.Create(new Role() { Role_name = "User" });
            uow.Roles.Create(new Role() { Role_name = "Guest" });
            uow.Save();
            uow.Users.Create(new User() { Login = "Admin", Pass = "Admin", Name = "Admin1", Role_FK = 1 });
            uow.Save();
            Console.WriteLine("Done");
            Console.ReadLine();

        }
    }
}
