namespace cis_proj.Models;

/// <summary>
/// The status of an order.
/// </summary>
public enum OrderStatus
{
    /// <summary>
    /// The order has been placed but not yet started.
    /// </summary>
    Ordered = 0,

    /// <summary>
    /// The order has been started but not yet finished.
    /// </summary>
    Started = 1,

    /// <summary>
    /// The order has been finished.
    /// </summary>
    Finished = 2
}
