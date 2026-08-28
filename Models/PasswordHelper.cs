using System.Security.Cryptography;
using System.Text;

namespace cis_proj.Models;

/// <summary>
/// Hashes and verifies user passwords. Passwords are stored as SHA-256 hex
/// strings so plain text never sits in the database.
/// </summary>
public static class PasswordHelper
{
    /// <summary>
    /// Hashes a plain text password into a SHA-256 hex string.
    /// </summary>
    /// <param name="password">The plain text password</param>
    /// <returns>The hashed password as a lowercase hex string</returns>
    public static string Hash(string password)
    {
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToHexString(bytes).ToLowerInvariant();
    }

    /// <summary>
    /// Checks a plain text password against a stored hash.
    /// </summary>
    /// <param name="password">The plain text password to check</param>
    /// <param name="storedHash">The hash stored in the database</param>
    /// <returns>True if the password matches</returns>
    public static bool Verify(string password, string storedHash)
    {
        return Hash(password) == storedHash;
    }
}
