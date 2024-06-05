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

        public Elevator(int id, int initialFloor, int maxCapacity)
        {
            Id = id;
            CurrentFloor = initialFloor;
            Direction = Direction.Stationary;
            IsMoving = false;
            Passengers = new List<Passenger>();
            MaxCapacity = maxCapacity;
        }

        public void MoveToFloor(int floor)
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
                Thread.Sleep(1000);

                // Display the current status of the elevator
                DisplayStatus();
            }

            Direction = Direction.Stationary;
            IsMoving = false;
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"Elevator {Id}: Floor {CurrentFloor}, Direction: {Direction}, Passengers: {Passengers.Count}");
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

        public void RemovePassengers()
        {
            Passengers.RemoveAll(p => p.DestinationFloor == CurrentFloor);
        }
    }
}
