using ElevatorChallenge.Domain.Entities;
using ElevatorChallenge.Domain.Entities.Elevators;
using ElevatorChallenge.Domain.Repositories;
using ElevatorChallenge.Infrastructure.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorTestProject
{
    [TestClass]
    public class ElevatorRepositoryTests
    {
        private Mock<IElevatorRepository> _mockRepository;
        private ElevatorRepository _elevatorRepository;

        [TestInitialize]
        public void SetUp()
        {
            _mockRepository = new Mock<IElevatorRepository>();
            _elevatorRepository = new ElevatorRepository();
        }

        [TestMethod]
        public async Task SaveElevatorsAsync_SavesElevatorsCorrectly()
        {
            var elevator = new PassengerElevator(1, 10);


            bool result = await _elevatorRepository.Save(elevator);

            Assert.IsTrue(result); // Assert that saving was successful
        }
    }
}
