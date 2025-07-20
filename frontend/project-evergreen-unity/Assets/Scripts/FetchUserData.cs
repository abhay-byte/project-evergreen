using System;
using UnityEngine;
using Evergreen.Models;
public class FetchUserData : MonoBehaviour
{
    private User userData { get; set; }

    void Start()
    {
        var user = new User
        {
            Id = 1,
            Email = "jane.doe@example.com",
            PasswordHash = "$2a$12$saltsaltsalt...", // Assume hashed with bcrypt
            FullName = "Jane Doe",
            Role = UserRole.Shopper,
            CumulativeGreenScore = 120,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    
        userData = user;

    }
    
}
