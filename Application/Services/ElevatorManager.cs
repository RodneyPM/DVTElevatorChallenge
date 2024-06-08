using ElevatorChallenge.Domain.Entities;
using ElevatorChallenge.Domain.Repositories;
using ElevatorChallenge.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Application.Services
{
    public class ElevatorManager
    {
        private readonly IElevatorRepository _elevatorRepository;

        public ElevatorManager(IElevatorRepository elevatorRepository)
        {
            _elevatorRepository = elevatorRepository;
        }

        public async Task AddPassengersToElevatorsAsync(List<Passenger> passengers)
        {
            var elevators = await _elevatorRepository.GetElevatorsAsync();

            // Distribute passengers among elevators
            int i = 0;
            while (i < passengers.Count)
            {
                bool added = false;
                foreach (var elevator in elevators)
                {
                    int remainingCapacity = elevator.MaxCapacity - elevator.Passengers.Count;
                    if (remainingCapacity > 0)
                    {
                        int passengersToAdd = Math.Min(remainingCapacity, passengers.Count - i);
                        List<Passenger> sublist = passengers.GetRange(i, passengersToAdd);
                        elevator.AddPassengers(sublist);
                        i += passengersToAdd;
                        added = true;
                        break;
                    }
                }

                if (!added)
                {
                    throw new InvalidOperationException("All elevators are at full capacity.");
                }
            }

            // Move each elevator to the necessary floors
            foreach (var elevator in elevators)
            {
                if (elevator.Passengers.Any())
                {
                    await elevator.MoveToFloorAsync();
                }
            }

            // Update repository with the new elevator states
            await _elevatorRepository.UpdateElevatorsAsync(elevators);
            // Display the status of the elevators
            await DisplayElevatorStatusAsync();
        }

        public async Task MoveToFloorAsync(int floor)
        {
            var elevators = await _elevatorRepository.GetElevatorsAsync();

            foreach (var elevator in elevators)
            {
                await elevator.MoveToFloorAsync();
            }

            // Update repository with the new elevator states
            await _elevatorRepository.UpdateElevatorsAsync(elevators);
            // Display the status of the elevators
            await DisplayElevatorStatusAsync();
        }

        public async Task DisplayElevatorStatusAsync()
        {
            var elevators = await _elevatorRepository.GetElevatorsAsync();

            foreach (var elevator in elevators)
            {
                Console.WriteLine($"Elevator {elevator.Id}: Floor {elevator.CurrentFloor}, Direction: {elevator.Direction}, Is Moving: {elevator.IsMoving}, Passengers: {elevator.Passengers.Count}");
            }
        }
    }
}
