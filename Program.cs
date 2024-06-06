// See https://aka.ms/new-console-template for more information
using ElevatorChallenge.Application.DTOs;
using ElevatorChallenge.Application.Services;
using ElevatorChallenge.Infrastructure.Repositories;

var elevatorRepository = new ElevatorRepository();
var elevatorService = new ElevatorService(elevatorRepository);

while (true)
{
    Console.WriteLine("\n1. Call Elevator\n2. Display Elevators Status\n3. Exit");
    Console.Write("Select an option: ");
    if (!int.TryParse(Console.ReadLine(), out int option))
    {
        Console.WriteLine("Invalid input. Please enter a valid option.");
        continue;
    }

    switch (option)
    {
        case 1:
            try
            {
                Console.Write("Enter floor number: ");
                int floor = int.Parse(Console.ReadLine());
                Console.Write("Enter number of passengers: ");
                int passengersCount = int.Parse(Console.ReadLine());
                var passengerDTOs = new List<PassengerDTO>();
                for (int i = 0; i < passengersCount; i++)
                {
                    Console.Write($"Enter destination floor for passenger {i + 1}: ");
                    int destinationFloor = int.Parse(Console.ReadLine());
                    passengerDTOs.Add(new PassengerDTO { DestinationFloor = destinationFloor });
                }
                // Sort passengers by destination floor from lowest to highest
                passengerDTOs = passengerDTOs.OrderBy(p => p.DestinationFloor).ToList();

                await elevatorService.RequestElevatorAsync(floor, passengerDTOs);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}. Please enter valid numbers.");
            }
            break;
        case 2:
            elevatorService.DisplayElevatorStatuses();
            break;
        case 3:
            return;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}