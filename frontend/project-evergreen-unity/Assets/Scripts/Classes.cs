using System;
using System.Collections.Generic;

namespace Evergreen.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int GreenScore { get; set; } // Must be 0-100
        public Dictionary<string, object>? GreenScoreDetails { get; set; } // JSONB mapped to Dictionary
        public string? Model3DUrl { get; set; }
        public string? Category { get; set; }
        public int InventoryQuantity { get; set; } = 0;
        public DateTime? ExpiryDate { get; set; }

        public override string ToString()
        {
            return $"Product: {Name} ({Category}), Price: {Price:C}, In stock: {InventoryQuantity}";
        }
    }
    
    public enum UserRole
    {
        Shopper,
        Admin,
        Seller
    }

    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string? FullName { get; set; }
        public UserRole Role { get; set; } = UserRole.Shopper;
        public int CumulativeGreenScore { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public override string ToString()
        {
            return $"{FullName} ({Email}) - Role: {Role}, Score: {CumulativeGreenScore}";
        }
    }

}