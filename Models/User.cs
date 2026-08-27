namespace cis_proj.Models;


public class User
{
    /// <summary>
    /// The user's ID
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The user's name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The user's email address
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// The user's password
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// The role of the user (e.g. Bartender, Manager, etc.)
    /// </summary>
    public string Role { get; set; }
}
