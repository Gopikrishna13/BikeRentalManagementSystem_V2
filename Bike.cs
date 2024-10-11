using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRentalManagement_V_2
{
    internal class Bike
    {
       string  BikeId {get ;set;}
   string Brand {get ;set;}
string Model{ get; set; }
   decimal RentalPrice { get; set; }

        public Bike(string bikeId, string brand, string model, decimal rentalPrice)
        {
            BikeId = bikeId;
            Brand = brand;
            Model = model;
            RentalPrice = rentalPrice;
        }
    }
}
