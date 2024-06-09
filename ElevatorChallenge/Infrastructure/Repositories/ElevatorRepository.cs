using ElevatorChallenge.Domain.Entities;
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
            // Initialize with some elevators
            _elevators = new List<Elevator>
            {
                new Elevator(1, 0),
                new Elevator(2, 0),
                new Elevator(3, 0)
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
