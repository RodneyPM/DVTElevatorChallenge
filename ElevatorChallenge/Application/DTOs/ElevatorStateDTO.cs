using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorChallenge.Application.DTOs
{
    public class ElevatorStateDTO
    {
        public int ElevatorId { get; set; }
        public int CurrentFloor { get; set; }
        public string Direction { get; set; }
        public bool IsMoving { get; set; }
    }
}
