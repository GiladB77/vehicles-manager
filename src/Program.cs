using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace VehiclesProject
{
    class Program
    {
        static List<Vehicles> vehicles = new List<Vehicles>();
        static string FilePath = "Gilad.txt";

        public enum ChoiceUser
        {
            VehicleEntry = 1,
            PrintVehicle = 2,
            CreateTextFile = 3,
            ReadingTextFile = 4,
            AddVehicle = 5,
            DeletingVehicle = 6,
            UpdateVehicle = 7,
            SaveToFileBinary = 8,
            ReadFromFileBinary = 9,
            SortVehicles = 10,
            SearchVehicle = 11,
            ViewReport = 12,
            Exit = 13
        }
        //public enum ChoiceUser2
        //{
        //    Car = 1,
        //    Motorcycle = 2,
        //    Truck = 3,
        //    ReturnBack = 4
        //}
        static void Main(string[] args)
        {
            OptionsMenu();

            Console.ReadLine();
        }
        static ChoiceUser Menu()
        {
            ChoiceUser choice;
            Console.WriteLine("*********************************************");
            Console.WriteLine("*            Welcome To Vehicles App             *");
            Console.WriteLine("*********************************************");
            Console.WriteLine("1.Manually input data");
            Console.WriteLine("2.Print data to the screen");
            Console.WriteLine("3.Save vehicles to file");
            Console.WriteLine("4.Vehicle absorption from file to array");
            Console.WriteLine("5.Add a vehicle");
            Console.WriteLine("6.Deleting a vehicle");
            Console.WriteLine("7.Update Vehicle");
            Console.WriteLine("8.Save Cars To File Binary Format");
            Console.WriteLine("9.Read Cars To Array From Saved File Binary Format");
            Console.WriteLine("10.Sort vehicles");
            Console.WriteLine("11.Search vehicle");
            Console.WriteLine("12.View data report");
            Console.WriteLine("13.Exit");
            Console.WriteLine();
            Console.WriteLine("Please enter your choice");
            Enum.TryParse(Console.ReadLine(), out choice);
            return choice;
        }
        static void OptionsMenu()
        {
            ReadingTextFile();
            do
            {
                ChoiceUser choice = Menu();
                switch (choice)
                {
                    case ChoiceUser.VehicleEntry:
                        Console.ForegroundColor = ConsoleColor.White;
                        VehicleEntry();
                        break;
                    case ChoiceUser.PrintVehicle:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Print();
                        break;
                    case ChoiceUser.CreateTextFile:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        CreateTextFile();
                        break;
                    case ChoiceUser.ReadingTextFile:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        ReadingTextFile();
                        break;
                    case ChoiceUser.AddVehicle:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        AddVehicles();
                        break;
                    case ChoiceUser.DeletingVehicle:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        RemoveCar();
                        break;
                    case ChoiceUser.UpdateVehicle:
                        Console.ForegroundColor = ConsoleColor.Red;
                        UpdateVehicle();
                        break;
                    case ChoiceUser.SortVehicles:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        SortVehicles();
                        break;
                    case ChoiceUser.SaveToFileBinary:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        SaveToFileBinary();
                        break;
                    case ChoiceUser.ReadFromFileBinary:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        ReadFromFileBinary();
                        break;
                    case ChoiceUser.SearchVehicle:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        SearchVehicle();
                        break;
                    case ChoiceUser.ViewReport:
                        PrintReport();
                        break;
                    case ChoiceUser.Exit:
                        Console.WriteLine("Have a good day!");
                        return;
                    default:
                        Console.WriteLine("Invalid number, please try again");
                        break;
                }
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                Console.Clear();
            } while (true);
        }
        static Car GetCar()
        {
            Car car = new Car();

            car.YearOfProduction = GetIntValueFromUser("What is the year of manufacture ?", "Error, Please enter a integer");
            Console.WriteLine("Which model ?");
            car.Model = Console.ReadLine();
            Console.WriteLine("What is the company ?");
            car.Company = Console.ReadLine();
            car.LicensePlate = GetIntValueFromUser("What is the license plate number ?", "Error, Please enter a integer");
            car.Doors = GetIntValueFromUser("How many doors are in the car ?", "Error, Please enter a integer");
            car.Engine = GetIntValueFromUser("What is the engine volume ?", "Error, Please enter a integer");

            return car;
        }
        static Motorcycle GetMotorcycle()
        {
            Motorcycle motorcycle = new Motorcycle();

            motorcycle.YearOfProduction = GetIntValueFromUser("What is the year of manufacture ?", "Error, Please enter a integer");
            Console.WriteLine("Which model?");
            motorcycle.Model = Console.ReadLine();
            Console.WriteLine("What is the company?");
            motorcycle.Company = Console.ReadLine();
            motorcycle.LicensePlate = GetIntValueFromUser("What is the license plate number ?", "Error, Please enter a integer");
            motorcycle.Seats = GetIntValueFromUser("How many motorcycle seats ?", "Error, Please enter a integer");
            motorcycle.Wheels = GetIntValueFromUser("How many wheels does a motorcycle have ?", "Error, Please enter a integer");

            return motorcycle;
        }
        static Truck GetTruck()
        {
            Truck truck = new Truck();

            truck.YearOfProduction = GetIntValueFromUser("What is the year of manufacture ?", "Error, Please enter a integer");
            Console.WriteLine("Which model?");
            truck.Model = Console.ReadLine();
            Console.WriteLine("What is the company?");
            truck.Company = Console.ReadLine();
            truck.LicensePlate = GetIntValueFromUser("What is the license plate number ?", "Error, Please enter a integer");
            truck.Wheels = GetIntValueFromUser("Some seats are in the truck ?", "Error, Please enter a integer");
            truck.MaximumSpeed = GetIntValueFromUser("What is the maximum speed the truck reaches ?", "Error, Please enter a integer");

            return truck;
        }
        static int GetIntValueFromUser(string msgForUser, string errorMsg)
        {
            Console.WriteLine(msgForUser);

            string value = Console.ReadLine();
            int num;
            bool a = int.TryParse(value, out num);

            if (a == true)
            {
                return num;
            }
            else
            {
                Console.WriteLine(errorMsg);

                return GetIntValueFromUser(msgForUser, errorMsg);
            }
        }
        static void CarList()
        {
            Console.WriteLine("How many cars do you want to add?");
            try
            {
                int add = int.Parse(Console.ReadLine());
                for (int i = 0; i < add; i++)
                {
                    Console.WriteLine("Car number" + (i + 1));
                    vehicles.Add(GetCar());
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a integer");
                CarList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void MotorcycleList()
        {
            Console.WriteLine("How many motorcycle do you want to add?");
            try
            {
                int add = int.Parse(Console.ReadLine());
                for (int i = 0; i < add; i++)
                {
                    Console.WriteLine("Motorcycle number" + (i + 1));
                    vehicles.Add(GetMotorcycle());
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a integer");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void TruckList()
        {
            Console.WriteLine("How many truck do you want to add?");
            try
            {
                int add = int.Parse(Console.ReadLine());
                for (int i = 0; i < add; i++)
                {
                    Console.WriteLine("Truck number" + (i + 1));
                    vehicles.Add(GetTruck());
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a integer");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //static ChoiceUser2 VehicleEntry()
        //{
        //    ChoiceUser2 choice;
        //    Console.WriteLine("Choose which vehicles would you like to enter?");
        //    Console.WriteLine("1. Car");
        //    Console.WriteLine("2. Motorcycle");
        //    Console.WriteLine("3. Truck");
        //    Console.WriteLine("4. Return back");
        //    Enum.TryParse(Console.ReadLine(), out choice);
        //    return choice;
        //}
        //public void Option()
        //{
        //    do
        //    {
        //        ChoiceUser2 choich = VehicleEntry();
        //        switch (choich)
        //        {
        //            case ChoiceUser2.Car:
        //                CarList();
        //                break;
        //            case ChoiceUser2.Motorcycle:
        //                MotorcycleList();
        //                break;
        //            case ChoiceUser2.Truck:
        //                TruckList();
        //                break;
        //            case ChoiceUser2.ReturnBack:
        //                break;
        //            default:
        //                Console.WriteLine("Invalid number");
        //                break;
        //        }
        //    }while(true);

        //}
        static void VehicleEntry()
        {
            Console.WriteLine("Choose which vehicles would you like to enter?");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Motorcycle");
            Console.WriteLine("3. Truck");
            Console.WriteLine("4. Return back");

            int choich = int.Parse(Console.ReadLine());
            switch (choich)
            {
                case 1:
                    CarList();
                    break;
                case 2:
                    MotorcycleList();
                    break;
                case 3:
                    TruckList();
                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Invalid Number");
                    break;
            }
        }
        static void Print()
        {
            for (int i = 0; i < vehicles.Count; i++)
            {
                if (vehicles[i] != null)
                {
                    Console.WriteLine("*************************************************");
                    Console.WriteLine("Vehicle number " + (i + 1));
                    Console.WriteLine(vehicles[i].ToString());
                    Console.WriteLine("*************************************************");
                }
            }
        }
        static void CreateTextFile()
        {
            StreamWriter writer = new StreamWriter(FilePath);

            for (int i = 0; i < vehicles.Count; i++)
            {
                if (vehicles[i] != null)
                {
                    writer.WriteLine(vehicles[i].PrintForFile());
                }
            }
            writer.Close();
            Console.WriteLine("File saved");
        }
        static void ReadingTextFile()
        {
            if (File.Exists(FilePath))
            {
                StreamReader reader = new StreamReader(FilePath);
                string[] temp;
                string str;

                while ((str = reader.ReadLine()) != null)
                {
                    temp = str.Split(',');
                    if (temp[0] == "Car")
                    {
                        Car car = new Car();
                        car.YearOfProduction = int.Parse(temp[1]);
                        car.Model = temp[2];
                        car.Company = temp[3];
                        car.LicensePlate = int.Parse(temp[4]);
                        car.Doors = int.Parse(temp[5]);
                        car.Engine = int.Parse(temp[6]);
                        vehicles.Add(car);
                    }
                    if (temp[0] == "Motorcycle")
                    {
                        Motorcycle motorcycle = new Motorcycle();
                        motorcycle.YearOfProduction = int.Parse(temp[1]);
                        motorcycle.Model = temp[2];
                        motorcycle.Company = temp[3];
                        motorcycle.LicensePlate = int.Parse(temp[4]);
                        motorcycle.Seats = int.Parse(temp[5]);
                        motorcycle.Wheels = int.Parse(temp[6]);
                        vehicles.Add(motorcycle);
                    }
                    if (temp[0] == "Truck")
                    {
                        Truck truck = new Truck();
                        truck.YearOfProduction = int.Parse(temp[1]);
                        truck.Model = temp[2];
                        truck.Company = temp[3];
                        truck.LicensePlate = int.Parse(temp[4]);
                        truck.Wheels = int.Parse(temp[5]);
                        truck.MaximumSpeed = int.Parse(temp[6]);

                        vehicles.Add(truck);
                    }
                }
                reader.Close();
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        }
        static void AddCar()
        {
            vehicles.Add(GetCar());
        }
        static void AddMotorcycle()
        {
            vehicles.Add(GetMotorcycle());
        }
        static void AddTruck()
        {
            vehicles.Add(GetTruck());
        }
        static void AddVehicles()
        {
            Console.WriteLine("Which vehicles would you like to add?");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Motorcycle");
            Console.WriteLine("3. Truck");
            Console.WriteLine("4. Return back");
            try
            {
                int choich = int.Parse(Console.ReadLine());

                switch (choich)
                {
                    case 1:
                        AddCar();
                        break;
                    case 2:
                        AddMotorcycle();
                        break;
                    case 3:
                        AddTruck();
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Invalid number");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a integer");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        static void RemoveCar()
        {
            Console.WriteLine("What is the vehicle license plate number?");
            try
            {
                int TempLicensePlate = int.Parse(Console.ReadLine());
                for (int i = 0; i < vehicles.Count; i++)
                {
                    if ((vehicles[i].LicensePlate == TempLicensePlate))
                    {
                        vehicles.Remove(vehicles[i]);
                        Console.WriteLine("Vehicle removed successfully");
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a integer");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void UpdateCar()
        {
            Console.WriteLine("What is the license plate number of the car you want to update data?");
            try
            {
                int licensePlate = int.Parse(Console.ReadLine());

                for (int i = 0; i < vehicles.Count; i++)
                {
                    Car car = vehicles[i] as Car;
                    if (car != null && car.LicensePlate == licensePlate)
                    {
                        Console.WriteLine("Choose which parameter you want to update");
                        Console.WriteLine("1. Year Of Production");
                        Console.WriteLine("2. Model");
                        Console.WriteLine("3. Company");
                        Console.WriteLine("4. License Plate");
                        Console.WriteLine("5. Number of Doors");
                        Console.WriteLine("6. Engine volume");
                        try
                        {
                            int choice = int.Parse(Console.ReadLine());

                            switch (choice)
                            {
                                case 1:
                                    int newYear = GetIntValueFromUser("Please enter the update year", "Error, Please enter a integer");
                                    car.YearOfProduction = newYear;
                                    break;
                                case 2:
                                    Console.WriteLine("Please enter the update model");
                                    string newModel = Console.ReadLine();
                                    car.Model = newModel;
                                    break;
                                case 3:
                                    Console.WriteLine("Please enter the update company");
                                    string newCompany = Console.ReadLine();
                                    car.Company = newCompany;
                                    break;
                                case 4:
                                    int newLicensePlate = GetIntValueFromUser("Please enter the update license plate", "Error, Please enter a integer");
                                    car.LicensePlate = newLicensePlate;
                                    break;
                                case 5:
                                    int newDoors = GetIntValueFromUser("Please enter the updated number of doors", "Error, Please enter a integer");
                                    car.Doors = newDoors;
                                    break;
                                case 6:
                                    Console.WriteLine("Please enter the update engine volume");
                                    int newEngine = GetIntValueFromUser("Please enter the update Maximum Speed", "Error, Please enter a integer");
                                    car.Engine = newEngine;
                                    break;
                                default:
                                    Console.WriteLine("Invalid number, Try again");
                                    break;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please enter a integer");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a integer");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void UpdateMotorcycle()
        {
            Console.WriteLine("What is the license plate number of the motorcycle you want to update data?");
            try
            {
                int licensePlate = int.Parse(Console.ReadLine());

                for (int i = 0; i < vehicles.Count; i++)
                {
                    Motorcycle motorcycle = vehicles[i] as Motorcycle;
                    if (motorcycle != null && motorcycle.LicensePlate == licensePlate)
                    {
                        Console.WriteLine("Choose which parameter you want to update");
                        Console.WriteLine("1. Year Of Production");
                        Console.WriteLine("2. Model");
                        Console.WriteLine("3. Company");
                        Console.WriteLine("4. License Plate");
                        Console.WriteLine("5. Seats");
                        Console.WriteLine("6. Wheels");
                        try
                        {
                            int choice = int.Parse(Console.ReadLine());

                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine("Please enter the update year");
                                    int newYear = int.Parse(Console.ReadLine());
                                    motorcycle.YearOfProduction = newYear;
                                    break;
                                case 2:
                                    Console.WriteLine("Please enter the update model");
                                    string newModel = Console.ReadLine();
                                    motorcycle.Model = newModel;
                                    break;
                                case 3:
                                    Console.WriteLine("Please enter the update company");
                                    string newCompany = Console.ReadLine();
                                    motorcycle.Company = newCompany;
                                    break;
                                case 4:
                                    Console.WriteLine("Please enter the update license plate");
                                    int newLicensePlate = int.Parse(Console.ReadLine());
                                    motorcycle.LicensePlate = newLicensePlate;
                                    break;
                                case 5:
                                    Console.WriteLine("Please enter the update seats");
                                    int newSeats = int.Parse(Console.ReadLine());
                                    motorcycle.Seats = newSeats;
                                    break;
                                case 6:
                                    Console.WriteLine("Please enter the update number of wheels");
                                    int newLWheels = int.Parse(Console.ReadLine());
                                    motorcycle.Wheels = newLWheels;
                                    break;
                                default:
                                    Console.WriteLine("Invalid number, Try again");
                                    break;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please enter a integer");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a integer");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void UpdateTruck()
        {
            Console.WriteLine("What is the license plate number of the truck you want to update data?");
            try
            {
                int licensePlate = int.Parse(Console.ReadLine());

                for (int i = 0; i < vehicles.Count; i++)
                {
                    Truck truck = vehicles[i] as Truck;
                    if (truck != null && truck.LicensePlate == licensePlate)
                    {
                        Console.WriteLine("Choose which parameter you want to update");
                        Console.WriteLine("1. Year Of Production");
                        Console.WriteLine("2. Model");
                        Console.WriteLine("3. Company");
                        Console.WriteLine("4. License Plate");
                        Console.WriteLine("5. Wheels");
                        Console.WriteLine("6. Maximum speed");
                        try
                        {
                            int choice = int.Parse(Console.ReadLine());

                            switch (choice)
                            {
                                case 1:
                                    int newYear = GetIntValueFromUser("Please enter the update year", "Error, Please enter a integer");
                                    truck.YearOfProduction = newYear;
                                    break;
                                case 2:
                                    Console.WriteLine("Please enter the update model");
                                    string newModel = Console.ReadLine();
                                    truck.Model = newModel;
                                    break;
                                case 3:
                                    Console.WriteLine("Please enter the update company");
                                    string newCompany = Console.ReadLine();
                                    truck.Company = newCompany;
                                    break;
                                case 4:
                                    int newLicensePlate = GetIntValueFromUser("Please enter the update license plate", "Error, Please enter a integer");
                                    truck.LicensePlate = newLicensePlate;
                                    break;
                                case 5:
                                    int newWheels = GetIntValueFromUser("Please enter the updated number of wheels", "Error, Please enter a integer");
                                    truck.Wheels = newWheels;
                                    break;
                                case 6:
                                    Console.WriteLine("Please enter the update engine volume");
                                    int newMaximumSpeed = GetIntValueFromUser("Please enter the update Maximum Speed", "Error, Please enter a integer");
                                    truck.MaximumSpeed = newMaximumSpeed;
                                    break;
                                default:
                                    Console.WriteLine("Invalid number, Try again");
                                    break;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please enter a integer");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a integer");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void UpdateVehicle()
        {
            Console.WriteLine("Which vehicles would you like to update?");
            Console.WriteLine("1.Car");
            Console.WriteLine("2.Motorcycle");
            Console.WriteLine("3. Truck");
            Console.WriteLine("4.Return back");
            try
            {
                int choich = int.Parse(Console.ReadLine());

                switch (choich)
                {
                    case 1:
                        UpdateCar();
                        break;
                    case 2:
                        UpdateMotorcycle();
                        break;
                    case 3:
                        UpdateTruck();
                        break;
                    case 4:
                        UpdateCar();
                        break;
                    default:
                        Console.WriteLine("Invalid number");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a integer");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void SortCarsByYear()
        {
            vehicles.Sort();
            Console.WriteLine("Successfully sorted by year");
        }
        static void SortByCompany()
        {
            SortCompany company = new SortCompany();
            vehicles.Sort(company.Compare);
            Console.WriteLine("Successfully sorted by company");
        }
        static void SortByYearAndCompany()
        {
            vehicles.Sort((first, second) =>
            {
                var c = first.YearOfProduction.CompareTo(second.YearOfProduction);
                if (c == 0)
                {
                    return c;
                }
                else
                {
                    return first.Company.CompareTo(second.Company);
                }
            });
        }
        static void SortVehicles()
        {
            Console.WriteLine("Which way would you like to arrange the list?");
            Console.WriteLine("1. By year");
            Console.WriteLine("2. By company");
            Console.WriteLine("3. By year and company");
            Console.WriteLine("4. Return back");
            try
            {
                int choich = int.Parse(Console.ReadLine());

                switch (choich)
                {
                    case 1:
                        SortCarsByYear();
                        break;
                    case 2:
                        SortByCompany();
                        break;
                    case 3:
                        SortByYearAndCompany();
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Invalid number");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a integer");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void SaveToFileBinary()
        {
            FileStream file = new FileStream("Gilad.dat", FileMode.Create, FileAccess.Write);
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, vehicles);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine("Failed because " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                file.Close();
                Console.WriteLine("File saved");
            }
        }
        static void ReadFromFileBinary()
        {
            FileStream file = null;
            try
            {
                file = new FileStream("Gilad.dat", FileMode.Open, FileAccess.ReadWrite);
                BinaryFormatter bf = new BinaryFormatter();
                vehicles = (List<Vehicles>)bf.Deserialize(file);
            }
            catch (SerializationException ex)
            {
                Console.WriteLine("Failed because " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }
        }
        static List<Vehicles> SearchByYearOfProduction()
        {
            Console.WriteLine("Please enter the year of vehicle production");
            try
            {
                int year = int.Parse(Console.ReadLine());
                for (int i = 0; i < vehicles.Count; i++)
                {
                    if (vehicles[i].YearOfProduction == year)
                    {
                        Console.WriteLine(vehicles[i].ToString());
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a integer");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return vehicles;
        }
        static List<Vehicles> SearchByCompany()
        {
            Console.WriteLine("Please enter the company name of the vehicle");
            string company = Console.ReadLine();
            for (int i = 0; i < vehicles.Count; i++)
            {
                if (vehicles[i].Company == company)
                {
                    Console.WriteLine(vehicles[i].ToString());
                }
            }
            return vehicles;
        }
        static List<Vehicles> SearchByLicensePlate()
        {
            Console.WriteLine("Please enter the license Plate of the vehicle");
            try
            {
                int licensePlate = int.Parse(Console.ReadLine());
                for (int i = 0; i < vehicles.Count; i++)
                {
                    if (vehicles[i].LicensePlate == licensePlate)
                    {
                        Console.WriteLine(vehicles[i].ToString());
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a integer");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return vehicles;
        }
        static List<Vehicles> SearchLatestVehiclesAddedToList()
        {
            try
            {
                if (vehicles != null)
                {
                    Console.WriteLine(vehicles.Last().ToString());
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("The list of vehicles is empty");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return vehicles;
        }
        static void SearchVehicle()
        {
            Console.WriteLine("Please select one of the options");
            Console.WriteLine("1. Search by year of production");
            Console.WriteLine("2. Search by company");
            Console.WriteLine("3. Search by license plate");
            Console.WriteLine("4. Search for the latest vehicles added to the list");
            Console.WriteLine("5. Return back");
            try
            {
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        SearchByYearOfProduction();
                        break;
                    case 2:
                        SearchByCompany();
                        break;
                    case 3:
                        SearchByLicensePlate();
                        break;
                    case 4:
                        SearchLatestVehiclesAddedToList();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Invalid number");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a integer");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void PrintReport()
        {
            Console.Clear();
            Console.WriteLine("The number of vehicles there is: {0}", vehicles.Count);

            Console.WriteLine("\nThe last vehicles entered is: {0}", vehicles.Last());
            vehicles.Sort();
            Console.WriteLine("\nThe newest vehicles on the list: {0}", vehicles.Last());
        }
    }
}
