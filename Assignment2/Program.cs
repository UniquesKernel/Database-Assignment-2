using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Assignment2.Data;
using Assignment2.Models;

using (var context = new ApplicationDbContext())
{

    var item = new Property_Type() { Item = "Phone" };

    context.Property_Types.Add(item);

    context.SaveChanges();

    var getProperties = context.Property_Types.ToList();
    
    foreach (var property in getProperties)
    {
        Console.WriteLine(property.Item);
    }
    
}