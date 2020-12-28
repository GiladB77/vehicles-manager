
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesProject
{
    [Serializable]
    class Car: Vehicles
    {
        int doors;
        int engine;

        public int Doors
        {
            get { return this.doors; }
            set { this.doors = value; }
        }

        public int Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }
        public Car()
        {

        }
        public Car(int yearOfProduction, string model, string company, int licensePlate, int doors, int engine)
          : base(yearOfProduction, model, company, licensePlate)
        {
            Doors = doors;
            Engine = engine;
        }

        public override string ToString()
        {
            return base.ToString() +
                string.Format(", Doors:{0}, Engine:{1}", Doors, Engine);
        }
        public override string PrintForFile()
        {
            return string.Format("Car, "+ base.PrintForFile() +",{0},{1}", Doors, Engine);
        }
    }
}
