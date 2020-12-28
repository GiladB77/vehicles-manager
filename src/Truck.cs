using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesProject
{
    [Serializable]
    class Truck:Vehicles
    {
        int wheels;
        int maximumSpeed;

        public int Wheels
        {
            get { return this.wheels; }
            set { this.wheels = value; }
        }
        public int MaximumSpeed
        {
            get { return this.maximumSpeed; }
            set { this.maximumSpeed = value; }
        }
        public Truck()
        {

        }
        public Truck(int yearOfProduction, string model, string company, int licensePlate, int wheels, int maximumSpeed)
            : base(yearOfProduction, model, company, licensePlate)
        {
            Wheels = wheels;
            MaximumSpeed = maximumSpeed;
        }
        public override string ToString()
        {
            return base.ToString() +
                string.Format(", Wheels:{0}, Maximum Speed:{1}", Wheels,MaximumSpeed);
        }
        public override string PrintForFile()
        {
            return string.Format("Truck, " + base.PrintForFile() + " ,{0},{1}", Wheels, MaximumSpeed);
        }
    }
}
