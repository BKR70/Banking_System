using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection
{
    public interface VehicleInterface 
    {   
        void Start();
    }
    public class Driver
    {
        private readonly VehicleInterface _vehicleInterface;
        public Driver(VehicleInterface obj)
        {
            _vehicleInterface = obj;
        }
        public void ShowOutput()
        {
            _vehicleInterface.Start();
        }

    }
    public class Bike : VehicleInterface
    {
        public void Start()
        {
            Console.WriteLine("Bike Started");
        }
    }
    public class Bus : VehicleInterface
    {
        public void Start()
        {
            Console.WriteLine("Bus Started");
        }
    }
    public class Car : VehicleInterface
    {
        public void Start()
        {
            Console.WriteLine("Car Started");
        }
    }
    
    public class Program
    {
        public static void Main(String[] args)
        {
            Bike obb = new Bike();
            Car obc = new Car();
            Bus obd = new Bus();
            Driver ob1 = new Driver(obb);
            ob1.ShowOutput();
        }
    }
}

