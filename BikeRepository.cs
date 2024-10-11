using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace BikeRentalManagement_V_2
{
    internal class BikeRepository
    {
        string connectionstring = "server=(localdb)\\MSSQLLocalDb;database=BikeRentalManagement;";
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

            Bike bike=new Bike(Id,brand,model,price);

            var query = @"Insert into BikesData (BikeId,Model,Brand,RentalPrice) values(@id,@brand,@model,@price)";

            using (var connection = new SqlConnection(connectionstring))
            {
                using (var command = new SqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@id",Id);
                    command.Parameters.AddWithValue("@brand", brand);
                    command.Parameters.AddWithValue("@model", model);
                    command.Parameters.AddWithValue("@price", price);

                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Added");
                }
            }


        }
    }
}
