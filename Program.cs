/*
 * Programming 2 - Assignment 5 - Winter 2026
 * Created by: Mohammad Arnaout & 2576053
 * Tested by: Hamza (Cousin)
 * Date: April 25th, 2026
 * This program demonstrates the Employee and Car classes by using
 * every constructor, property and method.
 */

namespace Asg5
{
    internal class Program
    {

        // Constants for the menu
        private const int MenuAccelerate = 1;
        private const int MenuBrake = 2;
        private const int MenuRefill = 3;
        private const int MenuExit = 4;

        // Constant for the low fuel threshold message to show up
        private const byte LowFuelThreshold = 20;

        static void Main(string[] args)
        {
            // Header message
            Console.WriteLine("************************************");
            Console.WriteLine("Welcome to \"Programming 2 - Assignment 5 – Winter 2026\"");
            Console.WriteLine("Created by Mohammad Arnaout (2576053) on " + DateTime.Now.ToShortDateString());
            Console.WriteLine("************************************\n");
            
            // Try catch statement (as instructed)
            try
            {
                #region Employee Application

                // Header for the Employee class demonstration
                Console.WriteLine("=== Employee Application ===\n");

                // List variable for employees
                List<Employee> employees = new List<Employee>();

                #region EmployeeInputs

                // 1st employee: ask the user for input, this one specifically for the name
                string name = "";
                bool validName = false;
                while (!validName)
                {
                    Console.Write("Enter Employee Name: ");
                    name = Console.ReadLine();
                    if (ContainsDigit(name))
                    {
                        Console.WriteLine("Name cannot contain digits. Try again.");
                    }
                    else
                    {
                        validName = true;
                    }
                }

                // 1st employee: ask the user for input, this one specifically for the id
                uint id = 0;
                bool validId = false;
                while (!validId)
                {
                    Console.Write("Enter Employee ID (5 or 6 digits): ");
                    if (uint.TryParse(Console.ReadLine(), out id))
                    {
                        if (id < 10000)
                        {
                            Console.WriteLine("ID is too short. Must be 5 or 6 digits. Try again.");
                        }
                        else if (id > 999999)
                        {
                            Console.WriteLine("ID is too long. Must be 5 or 6 digits. Try again.");
                        }
                        else
                        {
                            validId = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid number. Try again.");
                    }
                }

                // 1st employee: ask the user for input, this one specifically for the department
                string department = "";
                bool validDepartment = false;
                while (!validDepartment)
                {
                    Console.Write("Enter Employee Department: ");
                    department = Console.ReadLine();
                    if (ContainsDigit(department))
                    {
                        Console.WriteLine("Department cannot contain digits. Try again.");
                    }
                    else
                    {
                        validDepartment = true;
                    }
                }

                // 1st employee: ask the user for input, this one specifically for the position
                string position = "";
                bool validPosition = false;
                while (!validPosition)
                {
                    Console.Write("Enter Employee Position: ");
                    position = Console.ReadLine();
                    if (ContainsDigit(position))
                    {
                        Console.WriteLine("Position cannot contain digits. Try again.");
                    }
                    else
                    {
                        validPosition = true;
                    }
                }

                #endregion

                // 1st employee: userinput, uses the 4 param constructor
                employees.Add(new Employee(name, id, department, position));

                // 2nd employee: hardcoded, uses the 2 param constructor + property setters
                Employee e2 = new Employee("Mark Jones", 39119);
                e2.Department = "IT";
                e2.Position = "Software engineer";
                employees.Add(e2);

                // 3rd employee: hardcoded, uses default constructor + every property setter
                Employee e3 = new Employee();
                e3.Name = "Annie Simpson";
                e3.IdNumber = 817740;
                e3.Department = "Manufacturing";
                e3.Position = "Engineer";
                employees.Add(e3);

                // Display every employee using a loop (it calls the overriden ToString)
                Console.WriteLine("\n--- All Employees ---");
                foreach (Employee emp in employees)
                {
                    Console.WriteLine(emp);
                }

                #endregion

                #region Car Application

                // Header for the Car class demonstration
                Console.WriteLine("\n=== Car Application ===\n");

                // Default constructor used (fuel = 0, year = 0)
                Car car1 = new Car();
                Console.WriteLine($"Car 1 (default): {car1}");

                // Using the property setters.
                car1.YearModel = 2020;
                car1.Make = "Honda Civic";
                Console.WriteLine($"Car 1 after setting values: {car1}");

                // Params constructor used, (fuel = 100)
                Car car2 = new Car(2024, "Tesla Model 3");
                Console.WriteLine($"Car 2: {car2}");

                // Change the Make for demonstration and print it to the console
                car2.Make = "Tesla Model X";
                Console.WriteLine($"Car 2 after Make change: {car2}\n");

                // Menu loop for "car2" specifically, a demonstration of it.
                bool exited = false;
                do
                {
                    // Menu message
                    Console.WriteLine("\n--- Car Menu ---");
                    Console.WriteLine("1. Accelerate");
                    Console.WriteLine("2. Brake");
                    Console.WriteLine("3. Refill");
                    Console.WriteLine("4. Exit");
                    Console.Write("Choose: ");

                    // Try to get a valid choice out of the user (int)
                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        Console.WriteLine("Invalid choice.");
                        continue;
                    }

                    // Switch case with the constants made above and a default to catch any invalid options.
                    // 1 = accelerate
                    // 2 = brake
                    // 3 = refill
                    // 4 = exit
                    // 1-3 use the class's functions and prints from the switch statement as classes are not meant to handle GUI.
                    switch (choice)
                    {
                        case MenuAccelerate:
                            car2.Accelerate();
                            Console.WriteLine($"Speed: {car2.Speed} km/h | Fuel: {car2.FuelLevel}%");
                            break;
                        case MenuBrake:
                            car2.Brake();
                            Console.WriteLine($"Speed: {car2.Speed} km/h | Fuel: {car2.FuelLevel}%");
                            break;
                        case MenuRefill:
                            try
                            {
                                car2.Refill();
                                Console.WriteLine($"Refilled. Fuel: {car2.FuelLevel}%");
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine($"Cannot refill: {ex.Message}");
                            }
                            break;
                        case MenuExit:
                            exited = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;

                    }

                    // Low fuel warning with 2 if statements, one for if the car's fuel level is below or equal to the threshold AND not 0
                    // in that case, show a low fuel warning. The other for is the car's fuel is 0, then show out of fuel.
                    // The <= sign is redundant, but I added it just incase. < would work just fine.
                    if (car2.FuelLevel <= LowFuelThreshold && car2.FuelLevel > 0)
                    {
                        Console.WriteLine("Low Fuel Warning!");
                    }
                    if (car2.FuelLevel <= 0)
                    {
                        Console.WriteLine("Out of fuel! Refill needed.");
                    }

                } while (!exited);

                #endregion

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Out of range error: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Argument error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();

        }


        // Helper that checks if a string has at least one digit
        static bool ContainsDigit(string text)
        {
            // If we don't have any text, return false
            if (text == null) return false; 

            // go through each character in the string we got, and if it contains any digit return true.
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }

            // otherwise, we return false.
            return false;
        }

    }
}
