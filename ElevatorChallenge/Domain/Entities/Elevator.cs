using ElevatorChallenge.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Domain.Entities
{

    public abstract class Elevator
    {
        public int Id { get; }
        public int CurrentFloor { get; set; }
        public string Direction { get; set; }
        public bool IsMoving { get; set; }
        public List<Passenger> Passengers { get; set; }
        public int MaxCapacity { get; } = 10;

        public Elevator(int id, int currentFloor)
        {
            Id = id;
            CurrentFloor = currentFloor;
            Direction = "Stationary";
            IsMoving = false;
            Passengers = new List<Passenger>();
        }
        public abstract Task MoveToFloorAsync();
        public abstract void AddPassengers(List<Passenger> passengers);
        public abstract bool CanTakeMorePassengers(int passengerCount);
        public abstract List<Passenger> QuickSortPassengers(List<Passenger> passengers, int low, int high);
        public abstract int Partition(List<Passenger> passengers, int low, int high);
        public abstract void Swap(List<Passenger> passengers, int i, int j);
     

       

        

        

        

        
    }
}

