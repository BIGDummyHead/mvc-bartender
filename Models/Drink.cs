namespace cis_proj.Models;

/// <summary>
/// Represents a drink in the system.
/// </summary>
public class Drink
{
    /// <summary>
    /// The unique ID of the drink on the menu.
    /// </summary>
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
}
