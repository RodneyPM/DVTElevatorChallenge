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
            _elevators = new List<Elevator>
            {
                new Elevator(1, 1, 5),
                new Elevator(2, 1, 5),
                new Elevator(3, 1, 5)
            };
        }

        public IEnumerable<Elevator> GetAllElevators()
        {
            return _elevators;
        }

        public Elevator GetNearestAvailableElevator(int floor)
        {
            return _elevators
                .Where(e => !e.IsMoving)
                .OrderBy(e => System.Math.Abs(e.CurrentFloor - floor))
                .FirstOrDefault();
        }

        public void Save(Elevator elevator)
        {
            var index = _elevators.FindIndex(e => e.Id == elevator.Id);
            if (index >= 0)
            {
                _elevators[index] = elevator;
            }
        }
    }
}
