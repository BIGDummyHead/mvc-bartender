using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace cis_proj.Models;

/// <summary>
/// Represents a drink in the system.
/// </summary>
public class Drink
{
    /// <summary>
    /// The unique ID of the drink on the menu.
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// The name of the drink.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The description of the drink.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The price of the drink.
    /// </summary>
    public decimal Price { get; set; }

    public Drink()
    {
        
    }

    public static void Create(ModelBuilder mig, int id, string name, string description, decimal price)
    {
        var drink = new Drink
        {
            Id = id,
            Name = name,
            Description = description,
            Price = price
        };
        mig.Entity<Drink>().HasData(drink);
    }

}
