using AutoMapper;
using BLL.Models;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserActions
    {
        IMapper UsersM = new MapperConfiguration(cfg => cfg.CreateMap<User, MUser>()).CreateMapper();
        private readonly UnitOfWork uow;

        public UserActions(UnitOfWork uow)
        {
            this.uow = uow;
        }

        public UserActions()
        {
            AuctionContext context = new AuctionContext();
            uow = new UnitOfWork(context, new ContextRepository<Lot>(context), new ContextRepository<Role>(context), new ContextRepository<User>(context));
        }


        public virtual List<MUser> GetUsers()
        {
            return UsersM.Map<IEnumerable<User>, List<MUser>>(uow.Users.Get());
        }

        public virtual MUser GetUserById(int id)
        {
            return UsersM.Map<User, MUser>(uow.Users.GetOne(x => (x.User_ID == id)));
        }

        public virtual bool AddUser(MUser newuser)
        {
            uow.Users.Create(new User { Name = newuser.Name, Login = newuser.Login, Pass = newuser.Pass, Role_FK = newuser.Role_FK });
            uow.Save();
            return true;
        }

        public virtual bool DeleteUserByID(int id)
        {
            uow.Users.Remove(uow.Users.FindById(id));
            uow.Save();
            return true;
        }
    }
}
