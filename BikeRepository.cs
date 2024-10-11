using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRentalManagement_V_2
{
    internal class BikeRepository
    {
        public void CreateBike()
        {
            Console.Write("Enter ID:");
            string Id=Console.ReadLine();

            Console.Write("Enter Brand:");
            string brand=Console.ReadLine();

            Console.Write("Enter Model:");
            string model=Console.ReadLine();

            Console.Write("Enter Renal:");
            decimal price=decimal.Parse(Console.ReadLine());
        }
    }
}
