using Arhitekt.Data;
using Arhitekt.Models;
using System;
using System.Linq;

namespace Arhitekt.Data
{
    public static class DbInitializer
{
    public static void Initialize(ArhitektContext context)
    {
        context.Database.EnsureCreated();

        // Look for any users.
        if (context.Users.Any())
        {
            return;   // DB has been seeded
        }

        var users = new User[]
        {
            new User{FirstName="Carson",LastName="Alexander",Email="alexander.carlson",Password="password",Role=UserRole.Architect},
            new User{FirstName="Meredith",LastName="Alonso",Email="alonso.meredith@gmail.com",Password="password",Role=UserRole.User},
            new User{FirstName="Arturo",LastName="Anand",Email="arturo.anand@gmail.com",Password="password",Role=UserRole.Architect},
            new User{FirstName="Gytis",LastName="Barzdukas",Email="gytis.barzdukas@gmail.com",Password="password",Role=UserRole.Architect},
            new User{FirstName="Yan",LastName="Li",Email="yan.li@gmail.com",Password="password",Role=UserRole.Architect},
            new User{FirstName="Peggy",LastName="Justice",Email="peggy.justice@gmail.com",Password="password",Role=UserRole.Architect},
            new User{FirstName="Laura",LastName="Norman",Email="laurna.norman@gmail.com",Password="password",Role=UserRole.Architect}
        };

        foreach (User s in users)
        {
            context.Users.Add(s);
        }
        context.SaveChanges();

        var arhitekti = new Architect[]
{
    new Architect{UserintID=users.Single(u => u.Email == "alexander.carlson").UserintID, Projects = new List<Project> { new Project { Name = "Project 1", Description = "Description 1", DateCreated = DateTime.Now, images = new List<string> { "Arhitekt/wwwroot/images/napoli.jpg" } } } },
    new Architect{UserintID=users.Single(u => u.Email == "arturo.anand@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Project 2", Description = "Description 2", DateCreated = DateTime.Now, images = new List<string> { "Arhitekt/wwwroot/images/four.jpg" } } } },
    new Architect{UserintID=users.Single(u => u.Email == "gytis.barzdukas@gmail.com").UserintID},
    new Architect{UserintID=users.Single(u => u.Email == "yan.li@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Project 3", Description = "Description 3", DateCreated = DateTime.Now, images = new List<string> { "Arhitekt/wwwroot/images/antwerp.jpg", "Arhitekt/wwwroot/images/back.jpg" } } } },
    new Architect{UserintID=users.Single(u => u.Email == "peggy.justice@gmail.com").UserintID},
    new Architect{UserintID=users.Single(u => u.Email == "laurna.norman@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Project 4", Description = "Description 4", DateCreated = DateTime.Now, images = new List<string> { "Arhitekt/wwwroot/images/west.jpg" } } } }
};

foreach (Architect c in arhitekti)
{
    context.Architects.Add(c);
}
context.SaveChanges();
    }
}
}
