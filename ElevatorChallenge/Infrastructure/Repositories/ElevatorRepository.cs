using ElevatorChallenge.Domain.Entities;
using ElevatorChallenge.Domain.Entities.Elevators;
using ElevatorChallenge.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Infrastructure.Repositories
{
    public class ElevatorRepository : IElevatorRepository
    {
        private readonly List<Elevator> _elevators;

        public ElevatorRepository()
        {
            _elevators = new List<Elevator>
            {
                new PassengerElevator(1, 1),
                new PassengerElevator(2, 5),
                new PassengerElevator(3, 10),
                new PassengerElevator(4, 15),
                new PassengerElevator(5, 20)


            };
        }

       

        public Task<List<Elevator>> GetElevatorsAsync()
        {
            // Simulate asynchronous operation
            return Task.FromResult(_elevators);
        }

        public async Task<bool> Save(Elevator elevator)
        {
            var index = _elevators.FindIndex(e => e.Id == elevator.Id);
            if (index != -1)
            {
                _elevators[index] = elevator;
                return true;
            }
           return false;
        }
        public Task UpdateElevatorsAsync(List<Elevator> elevators)
        {
            for (int i = 0; i < _elevators.Count; i++)
            {
                var updatedElevator = elevators.Find(e => e.Id == _elevators[i].Id);
                if (updatedElevator != null)
                {
                    _elevators[i] = updatedElevator;
                }
            }
            return Task.CompletedTask;
        }
    }
}
