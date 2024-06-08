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
        public int Id { get; }
        public int CurrentFloor { get; private set; }
        public string Direction { get; private set; }
        public bool IsMoving { get; private set; }
        public List<Passenger> Passengers { get; private set; }
        public int MaxCapacity { get; } = 10;

        public Elevator(int id, int currentFloor)
        {
            Id = id;
            CurrentFloor = currentFloor;
            Direction = "Stationary";
            IsMoving = false;
            Passengers = new List<Passenger>();
        }

        public async Task MoveToFloorAsync()
        {
            // Sort passengers by destination floor using quicksort
            QuickSortPassengers(Passengers, 0, Passengers.Count - 1);

            while (Passengers.Any())
            {
                var nextDestination = Passengers.First().DestinationFloor;

                if (nextDestination > CurrentFloor)
                {
                    Direction = "Up";
                }
                else if (nextDestination < CurrentFloor)
                {
                    Direction = "Down";
                }
                else
                {
                    Direction = "Stationary";
                }

                IsMoving = true;
                Console.WriteLine($"Elevator {Id} is moving to floor {nextDestination} with {Passengers.Count} passengers.");

                // Simulate the elevator moving to the specified floor
                await Task.Delay(1000); // Simulate time delay for moving
                CurrentFloor = nextDestination;

                // Remove passengers whose destination floor is reached
                var arrivedPassengers = Passengers.Where(p => p.DestinationFloor == CurrentFloor).ToList();
                foreach (var p in arrivedPassengers)
                {
                    Passengers.Remove(p);
                    Console.WriteLine($"Passenger {p.Id} arrived at floor {CurrentFloor}");
                }

                if (!Passengers.Any())
                {
                    Direction = "Stationary";
                    IsMoving = false;
                }
            }
        }

        private void QuickSortPassengers(List<Passenger> passengers, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(passengers, low, high);

                QuickSortPassengers(passengers, low, pi - 1);
                QuickSortPassengers(passengers, pi + 1, high);
            }
        }

        private int Partition(List<Passenger> passengers, int low, int high)
        {
            int pivot = passengers[high].DestinationFloor;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (passengers[j].DestinationFloor <= pivot)
                {
                    i++;
                    Swap(passengers, i, j);
                }
            }

            Swap(passengers, i + 1, high);
            return i + 1;
        }

        private void Swap(List<Passenger> passengers, int i, int j)
        {
            Passenger temp = passengers[i];
            passengers[i] = passengers[j];
            passengers[j] = temp;
        }

        public bool CanTakeMorePassengers(int count)
        {
            return Passengers.Count + count <= MaxCapacity;
        }

        public void AddPassengers(List<Passenger> passengers)
        {
            if (CanTakeMorePassengers(passengers.Count))
            {
                Passengers.AddRange(passengers);
                if (!IsMoving)
                {
                    IsMoving = true; // Set IsMoving to true if passengers are added and the elevator is not moving
                }
            }
            else
            {
                throw new InvalidOperationException("Cannot add passengers. Elevator capacity exceeded.");
            }
        }
    }
}

