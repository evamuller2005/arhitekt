namespace Arhitekt.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
public class Project
{
    public int ProjectID { get; set; } // Primary key
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? DateCreated { get; set; }
    public string? Image { get; set; }
    public int UserintID { get; set; } // Foreign key
    public User? User { get; set; }
}