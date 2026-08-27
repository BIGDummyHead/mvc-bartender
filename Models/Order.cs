namespace cis_proj.Models;

/// <summary>
/// Represents an order in the system.
/// </summary>
public class Order
{
    /// <summary>
    /// The unique identifier of the order.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The date and time the order was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// The date and time the order was finished.
    /// </summary>
    public DateTime? FinishedAt { get; set; }

    /// <summary>
    /// The name of the customer who placed the order.
    /// </summary>
    public string CustomerName { get; set; }

    /// <summary>
    /// The bartender who is assigned to the order.
    /// </summary>
    public User? AssignedBartender { get; set; }

    /// <summary>
    /// The status of the order.
    /// </summary>
    public int OrderStatus { get; set; }
}
