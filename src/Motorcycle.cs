using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesProject
{
    [Serializable]
    class Motorcycle : Vehicles
    {
        int seats;
        int wheels;

        public int Seats
        {
            get { return this.seats; }
            set { this.seats = value; }
        }

        public int Wheels
        {
            get { return this.wheels; }
            set { this.wheels = value; }
        }
        public Motorcycle()
        {

        }
        public Motorcycle(int yearOfProduction, string model, string company, int licensePlate, int seats, int wheels)
          : base(yearOfProduction, model, company, licensePlate)
        {
            Seats = seats;
            Wheels = wheels;
        }

        public override string ToString()
        {
            return base.ToString() +
                string.Format(", Seats:{0}, Wheels:{1}", Seats, Wheels);
        }

        public override string PrintForFile()
        {
            return string.Format("Motorcycle, " +base.PrintForFile() +" ,{0},{1}", Seats, Wheels);
        }


    }

}
