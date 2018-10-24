using AL.Events.Common.Cache;
using AL.Events.DAL.Repositories;
using AL.Events.Business.Providers.Implementations;
using AL.Events.Common.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;

namespace AL.Events.Business.Tests.Providers.Implementations
{
    [TestClass]
    public class EventProviderTests
    {
        #region Initializing
        private Mock<IEventRepository> _repositoryMoq;
        private Mock<IAppCache> _cacheMoq;
        private EventProvider _provider;

        [TestInitialize]
        public void TestInitialize()
        {
            _repositoryMoq = new Mock<IEventRepository>();
            _cacheMoq = new Mock<IAppCache>();
            _provider = new EventProvider(_repositoryMoq.Object, _cacheMoq.Object);
        }
        #endregion

        [TestMethod]
        public void GetById_Invalid_Id_ReturnNull()
        {
            //Arrange
            int idArg = -1;
            //Act
            var actual = _provider.GetById(idArg);
            //Assert
            Assert.AreEqual(null, actual);
        }

        [TestMethod]
        public void GetById_Valid_Id_ReturnEvent()
        {
            //Arrange
            int idArg = 1;

            _repositoryMoq.Setup(r => r.GetById(It.IsAny<int>())).Returns((int id) =>
            {
                return new Event()
                {
                    Id = id
                };
            });

            //Act
            var actual = _provider.GetById(idArg);

            //Assert
            Assert.AreEqual(1, actual.Id);
            _repositoryMoq.Verify(r => r.GetById(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void GetByUserId_Valid_Id_ReturnIReadOnlyCollectionOfEvents()
        {
            //Arrange
            int idArg = 1;

            _repositoryMoq.Setup(r => r.GetByUserId(It.IsAny<int>())).Returns((int id) =>
            {
                return new List<Event>
                {
                    new Event
                    {
                        Id = id
                    }
                };
            });

            //Act
            var actual = _provider.GetByUserId(idArg);

            //Assert
            Assert.AreNotEqual(null, actual);
        }

        [TestMethod]
        public void GetByUserId_Invalid_Id_ReturnIReadOnlyCollectionOfEvents()
        {
            //Arrange
            int idArg = -1;

            _repositoryMoq.Setup(r => r.GetByUserId(It.IsAny<int>())).Returns((int id) =>
            {
                return new List<Event>
                {
                    new Event
                    {
                        Id = id
                    }
                };
            });

            //Act
            var actual = _provider.GetByUserId(idArg);

            //Assert
            Assert.AreNotEqual(null, actual);
        }
    }
}
