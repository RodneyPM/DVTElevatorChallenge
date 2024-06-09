# Elevator Simulation

## Overview

This console application simulates the behavior of elevators in a building. It includes the following features:

1. **Real-Time Elevator Status**: Displays the real-time status of each elevator.
2. **Interactive Elevator Control**: Allows users to call elevators to specific floors and specify the number of passengers.
3. **Multiple Floors and Elevators Support**: Supports multiple floors and elevators.
4. **Efficient Elevator Dispatching**: Implements an algorithm to efficiently direct the nearest available elevator.
5. **Passenger Limit Handling**: Considers the maximum passenger limit for each elevator.
6. **Consideration for Different Elevator Types**: Designed to accommodate different elevator types in the future.

## Features

### 1. Real-Time Elevator Status

Displays the current floor, direction of movement, whether it's in motion or stationary, and the number of passengers each elevator is carrying.

### 2. Interactive Elevator Control

Users can interact with the elevators through the console application, calling an elevator to a specific floor and indicating the number of passengers waiting on each floor.

### 3. Multiple Floors and Elevators Support

The application can accommodate buildings with multiple floors and multiple elevators, ensuring efficient movement between different floors.

### 4. Efficient Elevator Dispatching

An algorithm efficiently directs the nearest available elevator to respond to an elevator request, minimizing wait times for passengers and optimizing elevator usage.

### 5. Passenger Limit Handling

The application considers the maximum passenger limit for each elevator, preventing overload and handling scenarios where additional elevators might be required.

### 6. Consideration for Different Elevator Types

The application architecture is designed to accommodate different elevator types in the future, such as high-speed elevators, glass elevators, and freight elevators.

## Running the Application

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio.
3. Build the solution.
4. Run the `ElevatorSimulation` project.
5. Follow the console prompts to interact with the application.

## Example Usage

1. **Call Elevator**: 
    - Enter the floor number and the number of passengers.
    - Specify the destination floor for each passenger.

2. **Display Elevators Status**: 
    - View the current status of all elevators in the system.

3. **Exit**: 
    - Exit the application.

## Top Methods Explained

### ElevatorManager

#### `AddPassengersToElevatorsAsync(List<Passenger> passengers)`
This method distributes passengers among available elevators based on their capacity.

- **Parameters:**
  - `List<Passenger> passengers`: List of passengers to be added to the elevators.
- **Returns:**
  - A list of elevators with updated passengers.

#### `MoveToFloorAsync()`
This method instructs all elevators to move to their respective next destination floors based on the passengers they are carrying.

- **Returns:**
  - A task representing the asynchronous operation.

#### `DisplayElevatorStatusAsync()`
This method retrieves and displays the current status of all elevators, including their current floor, direction, movement status, and the number of passengers.

- **Returns:**
  - A list of strings representing the status of each elevator.

### Elevator

#### `MoveToFloorAsync()`
This method moves the elevator to the next destination floor based on the passengers' destination floors. It sorts the passengers using the QuickSort algorithm and moves the elevator accordingly.

- **Returns:**
  - A task representing the asynchronous operation.

### ElevatorRepository

#### `GetElevatorsAsync()`
This method retrieves all elevators from the repository.

- **Returns:**
  - A list of elevators.

#### `SaveElevatorAsync(Elevator elevator)`
This method saves the state of a specific elevator in the repository.

- **Parameters:**
  - `Elevator elevator`: The elevator to be saved.
- **Returns:**
  - A task representing the asynchronous operation.

#### `UpdateElevatorsAsync(List<Elevator> elevators)`
This method updates the state of multiple elevators in the repository.

- **Parameters:**
  - `List<Elevator> elevators`: The list of elevators to be updated.
- **Returns:**
  - A task representing the asynchronous operation.

## Unit Tests

The project includes unit tests using MSTest. To run the tests:

1. Open the Test Explorer in Visual Studio.
2. Build the solution.
3. Run the tests to ensure the functionality is correct.

### ElevatorManagerTests

#### `TestAddPassengersToElevatorsAsync()`
This test verifies that passengers are correctly added to elevators and that the distribution of passengers respects the elevators' capacity.

#### `TestMoveToFloorAsync()`
This test checks that elevators move to the correct floors based on the passengers they carry.

#### `TestDisplayElevatorStatusAsync()`
This test ensures that the status of each elevator is correctly retrieved and displayed.

### ElevatorTests

#### `TestQuickSortPassengers()`
This test verifies that the `QuickSortPassengers` method correctly sorts passengers by their destination floor.

### ElevatorRepositoryTests

#### `TestSaveElevator()`
This test checks that an elevator's state is correctly saved in the repository.

#### `TestUpdateElevatorsAsync()`
This test verifies that multiple elevators' states are correctly updated in the repository.

## Conclusion

This documentation provides an overview of the application's features, usage instructions, and detailed explanations of the key methods and their functionalities. The included unit tests ensure the application's reliability and correctness.
