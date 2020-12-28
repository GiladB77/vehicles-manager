 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesProject
{
    [Serializable]
    class Vehicles: IComparable
    {
        int yearOfProduction;
        string model;
        string company;
        int licensePlate;

        public int YearOfProduction
        {
            get { return this.yearOfProduction; }
            set { this.yearOfProduction = value; }
        }
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public string Company
        {
            get { return this.company; }
            set { this.company = value; }
        }
        public int LicensePlate
        {
            get { return this.licensePlate; }
            set { this.licensePlate = value; }
        }


        public Vehicles()
        {

        }
        public Vehicles(int yearOfProduction, string model, string company, int licensePlate)
        {
            YearOfProduction = yearOfProduction;
            Model = model;
            Company = company;
            LicensePlate = licensePlate;
        }

        public override string ToString()
        {
            string print = string.Format("Year Of Production:{0}, Model:{1}, Company:{2}, License Plate:{3}", YearOfProduction,Model,Company, LicensePlate);

            return print;
        }

        public virtual string PrintForFile()
        {
            string print = string.Format("{0},{1},{2},{3}", YearOfProduction, Model, Company, LicensePlate);
            
            return print;
        }

        int IComparable.CompareTo(object obj)
        {
            Vehicles vehicle = null;
            if (obj is Vehicles)
            {
                vehicle = (Vehicles)obj;
                if(vehicle.YearOfProduction > YearOfProduction)
                {
                    return -1;
                }
                if (vehicle.YearOfProduction < YearOfProduction)
                {
                    return 1;
                }               
            }return 0;
        }

    }
}
