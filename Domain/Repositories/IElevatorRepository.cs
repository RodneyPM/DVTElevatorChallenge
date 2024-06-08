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
        Task<List<Elevator>> GetElevatorsAsync();
        Elevator GetNearestAvailableElevator(int floor);
        void Save(Elevator elevator);
        Task UpdateElevatorsAsync(List<Elevator> elevators);
    }
}
