using ElevatorChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorTestProject
{
    [TestClass]
    public class ElevatorTests
    {
        [TestMethod]
        public void QuickSortPassengers_SortsPassengersCorrectly()
        {
            // Arrange
            var elevator = new Elevator(1,10);
            var passengers = new List<Passenger>
        {
            new Passenger { Id = 1, DestinationFloor = 5 },
            new Passenger { Id = 2, DestinationFloor = 2 },
            new Passenger { Id = 3, DestinationFloor = 8 },
            new Passenger { Id = 4, DestinationFloor = 3 },
            new Passenger { Id = 5, DestinationFloor = 1 }
        };

            // Act
            var sortedPassengers = elevator.QuickSortPassengers(passengers, 0, passengers.Count - 1);

            // Assert
            Assert.AreEqual(1, sortedPassengers[0].DestinationFloor);
            Assert.AreEqual(2, sortedPassengers[1].DestinationFloor);
            Assert.AreEqual(3, sortedPassengers[2].DestinationFloor);
            Assert.AreEqual(5, sortedPassengers[3].DestinationFloor);
            Assert.AreEqual(8, sortedPassengers[4].DestinationFloor);
        }
    }
}
