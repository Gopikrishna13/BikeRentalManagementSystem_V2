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

        public string Capitalize(string value)
        {
            return value.Substring(0, 1).ToUpper() + value.Substring(1);
        }
        public void CreateBike()
        {
            Console.Write("Enter ID:");
            string Id = Console.ReadLine();
            bool chkId = checkID(Id);
            if(!chkId)
            {
                Console.Write("Enter Brand:");
                string brand = Console.ReadLine();
                string cap = Capitalize(brand);

                Console.Write("Enter Model:");
                string model = Console.ReadLine();

                Console.Write("Enter Renal:");
                decimal price = decimal.Parse(Console.ReadLine());

                Bike bike = new Bike(Id, brand, model, price);

                var query = @"Insert into BikesData (BikeId,Model,Brand,RentalPrice) values(@id,@brand,@model,@price)";

                using (var connection = new SqlConnection(connectionstring))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", Id);
                        command.Parameters.AddWithValue("@brand", cap);
                        command.Parameters.AddWithValue("@model", model);
                        command.Parameters.AddWithValue("@price", price);

                        connection.Open();
                        command.ExecuteNonQuery();
                        Console.WriteLine("Added");
                    }
                }

            }
            else
            {
                Console.WriteLine("Already Id exist");
            }

          


        }

        public void ReadBikes()
        {
            var query = @"Select * from BikesData";

            using (var connection = new SqlConnection(connectionstring))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["BikeId"] + "," + reader["Brand"] + "," + reader["Model"] + "," + reader["RentalPrice"]);
                    }
                }

            }
        }

        public void DeleteBike()
        {
            Console.Write("Enter Id:");
            string Id=Console.ReadLine();
            bool chkId = checkID(Id);
            if (chkId)
            {
                var query = @"Delete from BikesData where BikeId=@Id";
                using (var connection = new SqlConnection(connectionstring))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Id", Id);
                        command.ExecuteNonQuery();
                    }
                }

            }
            else
            {
                Console.Write("Invalid");
            }
         
        }
        public bool checkID(string id)
        {
            var query = @"select count(1) from BikesData where BikeId=@Id";
            using(var connection=new SqlConnection(connectionstring))
            {
                using(var command=new SqlCommand(query,connection))
                {
                    connection.Open();
                   command.Parameters.AddWithValue("Id",id);
                    int result =(int)command.ExecuteScalar();
                    return result > 0;
                }
            }
        }

        public void UpdateBike()
        {
            Console.Write("Enter Id:");
            string Id=Console.ReadLine();
            bool chkId=checkID(Id);
            if (chkId)
            {
                Console.Write("Enter Brand:");
                string brand = Console.ReadLine();


                Console.Write("Enter Model:");
                string model = Console.ReadLine();

                Console.Write("Enter Renal:");
                decimal price = decimal.Parse(Console.ReadLine());

                Bike bike = new Bike(Id, brand, model, price);

                var query = @"update BikesData set Brand=@brand,Model=@model,RentalPrice=@price where BikeId=@Id";
                using (var connection = new SqlConnection(connectionstring))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@Id", Id);
                        command.Parameters.AddWithValue("@brand", brand);
                        command.Parameters.AddWithValue("@model", model);
                        command.Parameters.AddWithValue("@price", price);
                        command.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                Console.Write("Invalid ID");
            }

            
        }
    }
}