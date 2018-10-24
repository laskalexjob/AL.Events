using AL.Events.Business.Service.Implementations;
using AL.Events.Common.Cache;
using AL.Events.Common.Entities;
using AL.Events.DAL.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace AL.Events.Business.Tests.Services.Implementations
{
    [TestClass]
    public class EventServiceTests
    {
        #region Initializing
        private Mock<IEventRepository> _repositoryMoq;
        private Mock<IAppCache> _cacheMoq;
        private EventService _provider;

        [TestInitialize]
        public void TestInitialize()
        {
            _repositoryMoq = new Mock<IEventRepository>();
            _cacheMoq = new Mock<IAppCache>();
            _provider = new EventService(_repositoryMoq.Object, _cacheMoq.Object);
        }
        #endregion

        [TestMethod]
        public void DeleteById_InvokesCacheDelete()
        {
            //Arrange
            int id = 1;

            //Act
            _provider.DeleteById(id);

            //Assert

            _repositoryMoq.Verify(m => m.Delete(id), Times.Once);
            _cacheMoq.Verify(m => m.Delete("EventCache"), Times.Once);
        }

        [TestMethod]
        public void Create_InvokesCacheAndRepository()
        {
            //Arrange
            var someEvent = new Event
            {
                Id = 1,
                Name = "SOme",
                Address = "Street"
            };

            //Act
            _provider.Create(someEvent);

            //Assert
            _repositoryMoq.Verify(m => m.Create(someEvent), Times.Once);
            _cacheMoq.Verify(m => m.Delete("EventCache"), Times.Once);
        }

        [TestMethod]
        public void Update_InvokesRepoAndCacheDelete()
        {
            //Arrange
            var someEvent = new Event
            {
                Id = 1,
                Name = "SOme",
                Address = "Street"
            };

            //Act
            _provider.Update(someEvent);

            //Assert
            _repositoryMoq.Verify(m => m.Update(someEvent), Times.Once);
            _cacheMoq.Verify(m => m.Delete("EventCache"), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),"You must take the object to method")]
        public void Update_NullParameter_ThrowsWrongArgumentException()
        {
            //Arrange
            Event someEvent = null;

            //Act
            _provider.Update(someEvent);

            //Assert
        }
    }
}
