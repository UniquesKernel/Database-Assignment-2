using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Assignment2.Data;
using Assignment2.Models;

using (var context = new ApplicationDbContext())
{
  using (var contex = new ApplicationDbContext())
  {
    //context.SeedDatabase();
    //Console.WriteLine("Query the database by using one of 3 available options");
    //Console.WriteLine("\t Press 1 to Query for all rooms in the municipality");
    //Console.WriteLine("\t Press 2 to Query all societies by Activity");
    //Console.WriteLine("\t Press 1 to Query booked rooms, the booking society and chairman");
    
    //while (true)
    //{
    //  Console.WriteLine("");
    //  Console.Write("> ");
    //  var input = Console.ReadLine();

    //  switch (input)
    //  {
    //    case "1":
    //      context.QueryMunicipality();
    //      break;
    //    case "2":
    //      Console.WriteLine("Please input the activity that you are looking for");
    //      Console.Write("> ");
    //      var searchString = Console.ReadLine();
    //      context.QuerySocieties(searchString);
    //      break;
    //    case "3":
    //      context.QueryBookedRooms();
    //      break;
    //    default:
    //      Console.Clear();
    //      Console.WriteLine("It seems you input was invalid, please try again");
    //      break;
    //  }
    //}
  }
}