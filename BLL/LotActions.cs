using AutoMapper;
using BLL.Models;
using DAL;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class LotActions
    {
        IMapper LotsM = new MapperConfiguration(cfg => cfg.CreateMap<Lot, MLot>()).CreateMapper();
        private readonly UnitOfWork uow;

        public LotActions(UnitOfWork uow)
        {
            this.uow = uow;
        }

        public LotActions()
        {
            AuctionContext context = new AuctionContext();
            uow = new UnitOfWork(context, new ContextRepository<Lot>(context), new ContextRepository<Role>(context), new ContextRepository<User>(context));
        }


        public virtual List<MLot> GetLots()
        {
            return LotsM.Map<IEnumerable<Lot>, List<MLot>>(uow.Lots.Get());
        }

        public virtual MLot GetLotById(int id)
        {
            return LotsM.Map<Lot, MLot>(uow.Lots.GetOne(x => (x.Lot_ID == id)));
        }

        public virtual bool AddLot(MLot New)
        {
            uow.Lots.Create(new Lot { Lot_Name = New.Lot_Name, Price = New.Price, User_FK = New.User_FK, IsBought = false, IsActive = false, Current_Price = null, Category = New.Category });
            uow.Save();
            return true;
        }

        public virtual bool DeleteLotByID(int id)
        {
            uow.Lots.Remove(uow.Lots.FindById(id));
            uow.Save();
            return true;
        }

        public virtual bool ChangeLot(MLot New)
        {
            uow.Lots.Update(new Lot { Lot_Name = New.Lot_Name, Price = New.Price, User_FK = New.User_FK, IsBought = New.IsBought, IsActive = New.IsActive, Current_Price = New.Current_Price, Category = New.Category, Lot_ID = New.Lot_ID, User_Bought_FK = New.User_Bought_FK });
            uow.Save();
            return true;
        }

        public virtual List<MLot> GetActiveLots()
        {
            return LotsM.Map<IEnumerable<Lot>, List<MLot>>(uow.Lots.Get()).Where(x => x.IsActive == true).ToList();
        }

        public virtual List<MLot> GetNonActiveLots()
        {
            return LotsM.Map<IEnumerable<Lot>, List<MLot>>(uow.Lots.Get()).Where(x => x.IsActive == false).ToList();
        }
    }
}
