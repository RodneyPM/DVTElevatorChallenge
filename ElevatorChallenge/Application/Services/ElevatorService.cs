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
        private readonly ElevatorManager _elevatorManager;

        public ElevatorService(ElevatorManager elevatorManager)
        {
            _elevatorManager = elevatorManager;
        }

        public async Task RequestElevatorAsync(int floor, List<Passenger> passengers)
        {
            // Sort passengers by destination floor from lowest to highest
            passengers = passengers.OrderBy(p => p.DestinationFloor).ToList();
            // Split passengers to different elevators

            //await _elevatorManager.AddPassengersToElevators(passengers);

            // Move elevators to the respective floors for each passenger
            foreach (var passenger in passengers)
            {
                await _elevatorManager.MoveToFloorAsync();
            }
        }

        public async Task DisplayElevatorsStatusAsync()
        {
            await _elevatorManager.DisplayElevatorStatusAsync();
        }
    }
}
