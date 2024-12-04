namespace Arhitekt.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
public class Project
{
    public int ProjectID { get; set; } // Primary key
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateTime? DateCreated { get; set; }
    public List<String> images { get; set; }
    public int ArchitectID { get; set; } // Foreign key
    public Architect Architect { get; set; }
}