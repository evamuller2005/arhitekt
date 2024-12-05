namespace Arhitekt.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
public class User
{
    public int UserID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }

}

public enum UserRole
{
    User,
    Architect
}