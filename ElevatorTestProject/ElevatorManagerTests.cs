using ElevatorChallenge.Application.Services;
using ElevatorChallenge.Domain.Entities;
using ElevatorChallenge.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorTestProject
{
    [TestClass]
    public class ElevatorManagerTests
    {
        private Mock<IElevatorRepository> _mockRepository;
        private ElevatorManager _elevatorManager;

        [TestInitialize]
        public void SetUp()
        {
            _mockRepository = new Mock<IElevatorRepository>();
            _elevatorManager = new ElevatorManager(_mockRepository.Object);
        }

        [TestMethod]
        public async Task AddPassengersToElevators_DistributesPassengersCorrectly()
        {
            // Arrange
            var elevators = new List<Elevator>
            {
                new Elevator(1, 1) ,
                new Elevator(2, 1)
            };

            _mockRepository.Setup(repo => repo.GetElevatorsAsync()).ReturnsAsync(elevators);

            var passengers = new List<Passenger>
            {
                new Passenger { Id = 1,DestinationFloor=1 },
                new Passenger { Id = 2, DestinationFloor = 2 },
                new Passenger { Id = 3, DestinationFloor = 3 },
                new Passenger { Id = 4, DestinationFloor = 4 },
                new Passenger { Id = 5, DestinationFloor = 5 },
                new Passenger { Id = 6, DestinationFloor = 6 },
                new Passenger { Id = 7, DestinationFloor = 7 },
                new Passenger { Id = 8, DestinationFloor = 8 },
                new Passenger { Id = 9, DestinationFloor = 9 },
                new Passenger { Id = 10, DestinationFloor = 10 },
                new Passenger{ Id = 11, DestinationFloor = 11 },
                new Passenger { Id = 12, DestinationFloor = 12 },
                new Passenger { Id = 13, DestinationFloor = 13 },
                new Passenger { Id = 14, DestinationFloor = 14 },
                new Passenger { Id = 15, DestinationFloor = 15 }
            };

            // Act
            var elevatorPassengerMap = await _elevatorManager.AddPassengersToElevatorsAsync(passengers);

            // Assert
            Assert.AreEqual(2, elevatorPassengerMap.Count, "There should be 2 elevators in the map.");

            Assert.IsTrue(elevatorPassengerMap.ContainsKey(elevators[0]));
            Assert.IsTrue(elevatorPassengerMap.ContainsKey(elevators[1]));

            Assert.AreEqual(10, elevatorPassengerMap[elevators[0]].Count, "Elevator 1 should have 10 passengers.");
            Assert.AreEqual(5, elevatorPassengerMap[elevators[1]].Count, "Elevator 2 should have 5 passengers.");

            // Verify that the repository update method was called
            _mockRepository.Verify(repo => repo.UpdateElevatorsAsync(elevators), Times.Once);
        }
        [TestMethod]
        public async Task AddPassengersToElevators_DistributesPassengersInCorrectly()
        {
            // Arrange
            var elevators = new List<Elevator>
            {
                new Elevator(1, 1) ,
                new Elevator(2, 1)
            };

            _mockRepository.Setup(repo => repo.GetElevatorsAsync()).ReturnsAsync(elevators);

            var passengers = new List<Passenger>
            {
                new Passenger{ Id = 1, DestinationFloor = 1 },
                new Passenger { Id = 2, DestinationFloor = 2 },
                new Passenger { Id = 3, DestinationFloor = 3 },
                new Passenger { Id = 4, DestinationFloor = 4 },
                new Passenger { Id = 5, DestinationFloor = 5 },
                new Passenger { Id = 6, DestinationFloor = 6 },
                new Passenger { Id = 7, DestinationFloor = 7 },
                new Passenger { Id = 8, DestinationFloor = 8 },
                new Passenger { Id = 9, DestinationFloor = 9 },
                new Passenger { Id = 10, DestinationFloor = 10 },
                new Passenger{ Id = 11, DestinationFloor = 11 },
                new Passenger { Id = 12, DestinationFloor = 12 },
                new Passenger { Id = 13, DestinationFloor = 13 },
                new Passenger { Id = 14, DestinationFloor = 14 },
                new Passenger { Id = 15, DestinationFloor = 15 }
            };

            // Act
            var elevatorPassengerMap = await _elevatorManager.AddPassengersToElevatorsAsync(passengers);

            // Assert
            Assert.AreEqual(2, elevatorPassengerMap.Count, "There should be 2 elevators in the map.");

            Assert.IsTrue(elevatorPassengerMap.ContainsKey(elevators[0]));
            Assert.IsTrue(elevatorPassengerMap.ContainsKey(elevators[1]));

            Assert.AreEqual(10, elevatorPassengerMap[elevators[0]].Count, "Elevator 1 should have 10 passengers.");
            Assert.AreEqual(5, elevatorPassengerMap[elevators[1]].Count, "Elevator 2 should have 5 passengers.");

            // Verify that the repository update method was called
            _mockRepository.Verify(repo => repo.UpdateElevatorsAsync(elevators), Times.Once);
        }

        [TestMethod]
        public async Task MoveToFloorAsync_MovesElevatorsToCorrectFloors()
        {
            // Arrange
            var elevators = new List<Elevator>
            {
                new Elevator(1, 10),
                new Elevator(2, 10)
            };

            var passengers1 = new List<Passenger>
            {
                new Passenger { Id = 1, DestinationFloor = 3 },
                new Passenger { Id = 2, DestinationFloor = 7 },
                new Passenger { Id = 3, DestinationFloor = 5 }
            };

            var passengers2 = new List<Passenger>
            {
                new Passenger { Id = 4, DestinationFloor = 6 },
                new Passenger { Id = 5, DestinationFloor = 8 }
            };

            elevators[0].AddPassengers(passengers1);
            elevators[1].AddPassengers(passengers2);

            _mockRepository.Setup(repo => repo.GetElevatorsAsync()).ReturnsAsync(elevators);

            // Act
            await _elevatorManager.MoveToFloorAsync();

            // Assert
            var updatedElevators = await _mockRepository.Object.GetElevatorsAsync();
            Assert.AreEqual(7, updatedElevators[0].CurrentFloor);
            Assert.AreEqual(8, updatedElevators[1].CurrentFloor);
            Assert.AreEqual(0, updatedElevators[0].Passengers.Count);
            Assert.AreEqual(0, updatedElevators[1].Passengers.Count);
        }
        [TestMethod]
        public async Task DisplayElevatorStatusAsync_DisplaysCorrectStatus()
        {
            // Arrange
            var elevators = new List<Elevator>
            {
                new Elevator(1, 1),
                new Elevator(2, 3)
            };

            _mockRepository.Setup(repo => repo.GetElevatorsAsync()).ReturnsAsync(elevators);

            var statuses = await _elevatorManager.DisplayElevatorStatusAsync();

            var expectedStatuses = new List<string>
            {
                "Elevator 1: Floor 1, Direction: Stationary, Is Moving: False, Passengers: 0",
                "Elevator 2: Floor 3, Direction: Stationary, Is Moving: False, Passengers: 0"
            };

            CollectionAssert.AreEqual(expectedStatuses, statuses);
        }
        }
    
}
