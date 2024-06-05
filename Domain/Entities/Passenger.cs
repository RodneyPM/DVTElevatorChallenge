using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Domain.Entities
{
    public class Passenger
    {
        public int DestinationFloor { get; private set; }

        public Passenger(int destinationFloor)
        {
            DestinationFloor = destinationFloor;
        }
    }
}
