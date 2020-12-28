using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehiclesProject
{
    class SortCompany : Vehicles, IComparer
    {
        public int Compare(object x, object y)
        {
            Vehicles vehicle1 = (Vehicles)x;
            Vehicles vehicle2 = (Vehicles)y;
            return vehicle1.Company.CompareTo(vehicle2.Company);
        }
    }
}
