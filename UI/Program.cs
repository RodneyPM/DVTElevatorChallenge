// See https://aka.ms/new-console-template for more information
using ElevatorChallenge.Application.DTOs;
using ElevatorChallenge.Application.Services;
using ElevatorChallenge.Domain.Entities;
using ElevatorChallenge.Domain.Repositories;
using ElevatorChallenge.Infrastructure.Repositories;

IElevatorRepository elevatorRepository = new ElevatorRepository(); // Implement this interface
ElevatorManager elevatorManager = new ElevatorManager(elevatorRepository);

while (true)
{
    Console.WriteLine("1. Call Elevator");
    Console.WriteLine("2. Display Elevators Status");
    Console.WriteLine("3. Exit");
    Console.Write("Select an option: ");

    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.Write("Enter floor number: ");
            var floor = int.Parse(Console.ReadLine());

            Console.Write("Enter number of passengers: ");
            var numberOfPassengers = int.Parse(Console.ReadLine());

            List<Passenger> passengers = new List<Passenger>();
            for (int i = 1; i <= numberOfPassengers; i++)
            {
                Console.Write($"Enter destination floor for passenger {i}: ");
                var destinationFloor = int.Parse(Console.ReadLine());
                passengers.Add(new Passenger(destinationFloor) { Id = i });
            }

            await elevatorManager.AddPassengersToElevatorsAsync(passengers);
            break;

        case "2":
            await elevatorManager.DisplayElevatorStatusAsync();
            break;

        case "3":
            return;

        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}