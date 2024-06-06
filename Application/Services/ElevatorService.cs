using ElevatorChallenge.Application.DTOs;
using ElevatorChallenge.Domain.Entities;
using ElevatorChallenge.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Application.Services
{
    public class ElevatorService
    {
        private readonly IElevatorRepository _elevatorRepository;

        public ElevatorService(IElevatorRepository elevatorRepository)
        {
            _elevatorRepository = elevatorRepository;
        }

        public async Task RequestElevatorAsync(int floor, List<PassengerDTO> passengerDTOs)
        {
            var elevator = _elevatorRepository.GetNearestAvailableElevator(floor);
            if (elevator != null)
            {
                elevator.RequestFloor(floor);
                _elevatorRepository.Save(elevator);

                await OperateElevatorAsync(elevator, floor, passengerDTOs);
            }
            else
            {
                Console.WriteLine("No available elevators at the moment.");
            }
        }

        public async Task OperateElevatorAsync(Elevator elevator, int requestFloor, List<PassengerDTO> passengerDTOs)
        {
            var nextFloor = elevator.GetNextFloorRequest();
            while (nextFloor.HasValue)
            {
                await elevator.MoveToFloorAsync(nextFloor.Value, elevator.Passengers);

                // Add passengers when the elevator arrives at the requested floor
                if (elevator.CurrentFloor == requestFloor)
                {
                    var passengers = passengerDTOs
                        .Select(dto => new Passenger(dto.DestinationFloor))
                        .ToList();

                    elevator.AddPassengers(passengers);

                    // Request destination floors for each passenger
                    foreach (var passenger in passengers)
                    {
                        elevator.RequestFloor(passenger.DestinationFloor);
                    }
                }

                nextFloor = elevator.GetNextFloorRequest();
                _elevatorRepository.Save(elevator);
            }
        }

        public void DisplayElevatorStatuses()
        {
            foreach (var elevator in _elevatorRepository.GetAllElevators())
            {
                elevator.DisplayStatus();
            }
        }
    }
}
