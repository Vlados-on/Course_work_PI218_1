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
    public class UserActionsTests
    {

        private UnitOfWork uow;
        AuctionContext context = new AuctionContext();
        Mock<UserActions> mock;
        UserActions ua;

        public UserActionsTests()
        {
            mock = new Mock<UserActions>();
            uow = new UnitOfWork(context, new ContextRepository<Lot>(context),
                new ContextRepository<Role>(context), new ContextRepository<User>(context));
        }

        [TestMethod]
        public void GetUsers()
        {

            List<MUser> list = new List<MUser>();

            mock.Setup(a => a.GetUsers()).Returns(list);

            Assert.That(mock.Object.GetUsers(), Is.Not.Null);
        }


        [TestMethod]
        public void GetUserById()
        {

            mock.Setup(a => a.GetUserById(0)).Returns(new MUser());

            Assert.That(mock.Object.GetUserById(0), Is.Not.Null);
        }

        [TestMethod]
        public void AddUser()
        {

            MUser m = new MUser();
            mock.Setup(a => a.AddUser(m)).Returns(true);

            Assert.That(mock.Object.AddUser(m), Is.True);
        }

        [TestMethod]
        public void DeleteUserByID()
        {

            MUser m = new MUser();
            mock.Setup(a => a.DeleteUserByID(0)).Returns(true);

            Assert.That(mock.Object.DeleteUserByID(0), Is.True);
        }
    }
}