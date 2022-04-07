using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Assignment2.Data;
using Assignment2.Models;

using (var context = new ApplicationDbContext())
{

    var item = new Property_Type() { Item = "Phone" };

    context.Property_Types.Add(item);

    context.SaveChanges();

    Console.WriteLine(context.Property_Types.Include(x => x.Item).ToList().ToString());
}