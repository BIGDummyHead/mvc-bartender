using cis_proj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cis_proj.Controllers;

/// <summary>
/// Handles cocktail order related actions (create, edit, and view).
/// </summary>
public class OrderController : Controller
{
    private readonly ApplicationDbContext _context;

    public OrderController(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Displays the cocktail bar menu so a patron can pick a drink to order.
    /// </summary>
    /// <returns>The menu view with the list of drinks from the database</returns>
    [HttpGet]
    public async Task<IActionResult> Menu()
    {
        var drinks = await _context.Drinks.ToListAsync();
        return View(drinks);
    }

    /// <summary>
    /// Displays the order form for the selected drink.
    /// </summary>
    /// <param name="id">The ID of the drink being ordered</param>
    /// <returns>The order form view, or NotFound if the drink does not exist</returns>
    [HttpGet]
    public async Task<IActionResult> Create(int id)
    {
        var drink = await _context.Drinks.FindAsync(id);

        if (drink == null)
            return NotFound();

        return View(drink);
    }

    /// <summary>
    /// Stores a new cocktail order in the database.
    /// </summary>
    /// <param name="drinkId">The ID of the drink being ordered</param>
    /// <param name="customerName">The name of the customer placing the order</param>
    /// <returns>Redirects to the confirmation page for the new order</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(int drinkId, string customerName)
    {
        var drink = await _context.Drinks.FindAsync(drinkId);

        if (drink == null)
            return NotFound();

        if (string.IsNullOrWhiteSpace(customerName))
        {
            ModelState.AddModelError(nameof(customerName), "Please enter your name so we can call your order.");
            return View(drink);
        }

        var order = new Order
        {
            DrinkId = drink.Id,
            CustomerName = customerName.Trim(),
            CreatedAt = DateTime.Now,
            OrderStatus = (int)Models.OrderStatus.Ordered
        };

        _context.Order.Add(order);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Confirmation), new { id = order.Id });
    }

    /// <summary>
    /// Shows the patron a confirmation that their order was placed.
    /// </summary>
    /// <param name="id">The ID of the order</param>
    /// <returns>The confirmation view, or NotFound if the order does not exist</returns>
    [HttpGet]
    public async Task<IActionResult> Confirmation(int id)
    {
        var order = await _context.Order
            .Include(o => o.Drink)
            .FirstOrDefaultAsync(o => o.Id == id);

        if (order == null)
            return NotFound();

        return View(order);
    }

    /// <summary>
    /// Displays the cocktail order queue for the bartender.
    /// </summary>
    /// <returns>The queue view with all orders, oldest unfinished orders first</returns>
    [HttpGet]
    public async Task<IActionResult> Queue()
    {
        var orders = await _context.Order
            .Include(o => o.Drink)
            .Include(o => o.AssignedBartender)
            .OrderBy(o => o.OrderStatus == (int)Models.OrderStatus.Finished)
            .ThenBy(o => o.CreatedAt)
            .ToListAsync();

        return View(orders);
    }

    /// <summary>
    /// Moves an order to the next status. Ordered -> Started -> Finished.
    /// A finished order is ready for pick up by the server.
    /// </summary>
    /// <param name="id">The ID of the order to update</param>
    /// <returns>Redirects back to the order queue</returns>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Advance(int id)
    {
        var order = await _context.Order.FindAsync(id);

        if (order == null)
            return NotFound();

        switch (order.GetOrderStatus())
        {
            case Models.OrderStatus.Ordered:
                order.OrderStatus = (int)Models.OrderStatus.Started;
                break;
            case Models.OrderStatus.Started:
                order.OrderStatus = (int)Models.OrderStatus.Finished;
                order.FinishedAt = DateTime.Now;
                break;
        }

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Queue));
    }
}
