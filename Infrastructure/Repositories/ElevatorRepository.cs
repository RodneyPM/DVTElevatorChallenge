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
                new Elevator(1, 0, 10),
                new Elevator(2, 0, 10),
                new Elevator(3, 0, 10)
            };
        }

        public Elevator GetNearestAvailableElevator(int requestFloor)
        {
            return _elevators
                .Where(e => !e.IsMoving)
                .OrderBy(e => System.Math.Abs(e.CurrentFloor - requestFloor))
                .FirstOrDefault();
        }

        public IEnumerable<Elevator> GetAllElevators()
        {
            return _elevators;
        }

        public void Save(Elevator elevator)
        {
            var index = _elevators.FindIndex(e => e.Id == elevator.Id);
            if (index != -1)
            {
                _elevators[index] = elevator;
            }
        }
    }
}
