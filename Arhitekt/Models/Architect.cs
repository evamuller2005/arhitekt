namespace Arhitekt.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
public class Architect
{
    public int ArchitectID { get; set; } // Primary key
    public int UserID { get; set; } // Foreign key
    public List<Project> Projects { get; set; }

    public User User { get; set; }
}
