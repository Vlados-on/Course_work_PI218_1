using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using BLL.Models;
using NUnit.Framework;
using Moq;
using DAL.Models;
using DAL;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace BLL_Tests
{
    [TestClass]
    public class LotTests
    {
        private UnitOfWork uow;
        AuctionContext context = new AuctionContext();
        Mock<LotActions> mock;

        public LotTests()
        {
            mock = new Mock<LotActions>();
            uow = new UnitOfWork(context, new ContextRepository<Lot>(context),
                new ContextRepository<Role>(context), new ContextRepository<User>(context));
        }

        [TestMethod]
        public void GetLotsTest()
        {
            List<MLot> list = new List<MLot>();
            mock.Setup(a => a.GetLots()).Returns(list);

            Assert.That(mock.Object.GetLots(), Is.Not.Null);
        }

        [TestMethod]
        public void GetLotByIdTest()
        {
            MLot bt = new MLot() { Lot_ID = 5 };

            mock.Setup(a => a.GetLotById(5)).Returns(bt);

            Assert.That(mock.Object.GetLotById(5), Is.EqualTo(bt));
        }


        [TestMethod]
        public void AddBookedTourTest()
        {
            MLot bt = new MLot() { Lot_ID = 5 };

            mock.Setup(a => a.AddLot(bt)).Returns(true);

            Assert.That(mock.Object.AddLot(bt), Is.True);
        }

        [TestMethod]
        public void DeleteLotByIDTest()
        {
            MLot bt = new MLot() { Lot_ID = 5 };

            mock.Setup(a => a.AddLot(bt));
            mock.Setup(a => a.DeleteLotByID(5)).Returns(true);

            Assert.That(mock.Object.DeleteLotByID(5), Is.True);
        }

        [TestMethod]
        public void ChangeLotTest()
        {
            MLot bt = new MLot() { Price = 50 };
            MLot bt2 = new MLot() { Price = 100 };


            mock.Setup(a => a.AddLot(bt)).Returns(true);
            mock.Setup(a => a.ChangeLot(bt2)).Returns(true);


            Assert.That(mock.Object.ChangeLot(bt2), Is.True);
        }

        [TestMethod]
        public void GetActiveLotsTest()
        {
            List<MLot> list = new List<MLot>();
            list.Add(new MLot { IsActive = true });
            mock.Setup(a => a.GetActiveLots()).Returns(list);

            Assert.That(mock.Object.GetActiveLots(), Is.EqualTo(list));
        }

        [TestMethod]
        public void GetNonActiveLotsTest()
        {
            List<MLot> list = new List<MLot>();
            list.Add(new MLot { IsActive = true });
            mock.Setup(a => a.GetNonActiveLots()).Returns(list);

            Assert.That(mock.Object.GetNonActiveLots(), Is.EqualTo(list));
        }
    }
}
