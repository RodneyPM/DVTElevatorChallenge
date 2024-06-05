using ElevatorChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Domain.Repositories
{
    public interface IElevatorRepository
    {
        IEnumerable<Elevator> GetAllElevators();
        Elevator GetNearestAvailableElevator(int floor);
    }
}
