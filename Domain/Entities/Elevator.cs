using ElevatorChallenge.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Domain.Entities
{

    public class Elevator
    {
        public int Id { get; private set; }
        public int CurrentFloor { get; private set; }
        public Direction Direction { get; private set; }
        public bool IsMoving { get; private set; }
        public List<Passenger> Passengers { get; private set; }
        public int MaxCapacity { get; private set; }
        private List<int> _floorRequests;

        public Elevator(int id, int initialFloor, int maxCapacity)
        {
            Id = id;
            CurrentFloor = initialFloor;
            Direction = Direction.Stationary;
            IsMoving = false;
            Passengers = new List<Passenger>();
            MaxCapacity = maxCapacity;
            _floorRequests = new List<int>();
        }

        public async Task MoveToFloorAsync(int floor, List<Passenger> passengers)
        {
            IsMoving = true;
            while (CurrentFloor != floor)
            {
                if (CurrentFloor < floor)
                {
                    CurrentFloor++;
                    Direction = Direction.Up;
                }
                else if (CurrentFloor > floor)
                {
                    CurrentFloor--;
                    Direction = Direction.Down;
                }

                // Simulate the time taken to move between floors
                await Task.Delay(1000);

                // Display the current status of the elevator
                DisplayStatus();
            }

            Direction = Direction.Stationary;
            IsMoving = false;

            // Remove passengers who reached their destination
            var passengersToRemove = Passengers.Where(p => p.DestinationFloor == CurrentFloor).ToList();
            foreach (var passenger in passengersToRemove)
            {
                Passengers.Remove(passenger);
                Console.WriteLine($"Passenger arrived at floor {CurrentFloor}. Passengers left: {Passengers.Count}");
            }
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"Elevator {Id}: Floor {CurrentFloor}, Direction: {Direction}, Is Moving: {IsMoving}, Passengers: {Passengers.Count}");
        }

        public bool CanTakeMorePassengers(int passengersCount)
        {
            return Passengers.Count + passengersCount <= MaxCapacity;
        }

        public void AddPassengers(List<Passenger> passengers)
        {
            if (CanTakeMorePassengers(passengers.Count))
            {
                Passengers.AddRange(passengers);
            }
            else
            {
                Console.WriteLine($"Elevator {Id} cannot take more passengers. Maximum capacity reached.");
            }
        }

        public void RequestFloor(int floor)
        {
            if (!_floorRequests.Contains(floor))
            {
                _floorRequests.Add(floor);
            }
        }

        public int? GetNextFloorRequest()
        {
            if (_floorRequests.Count == 0)
                return null;

            // Find the nearest floor request
            int nearestFloor = _floorRequests.OrderBy(f => System.Math.Abs(f - CurrentFloor)).First();
            _floorRequests.Remove(nearestFloor);
            return nearestFloor;
        }
    }
}

