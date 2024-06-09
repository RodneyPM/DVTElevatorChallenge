using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Domain.Entities.Elevators
{
    public class HighSpeedElevator : Elevator
    {
        public HighSpeedElevator(int id, int currentFloor) : base(id, currentFloor)
        {
        }

        public override void AddPassengers(List<Passenger> passengers)
        {
            throw new NotImplementedException();
        }

        public override bool CanTakeMorePassengers(int passengerCount)
        {
            throw new NotImplementedException();
        }

        public override Task MoveToFloorAsync()
        {
            throw new NotImplementedException();
        }

        public override int Partition(List<Passenger> passengers, int low, int high)
        {
            throw new NotImplementedException();
        }

        public override List<Passenger> QuickSortPassengers(List<Passenger> passengers, int low, int high)
        {
            throw new NotImplementedException();
        }

        public override void Swap(List<Passenger> passengers, int i, int j)
        {
            throw new NotImplementedException();
        }
    }
}
