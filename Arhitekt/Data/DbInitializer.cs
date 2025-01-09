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
    new Architect{UserintID=users.Single(u => u.Email == "alexander.carlson").UserintID, Projects = new List<Project> { new Project { Name = "Chau", Description = "The House in Chau Doc by Alexander Carlson is a terraced, open-air residence in Vietnam that seamlessly integrates greenery and natural ventilation.", DateCreated = DateTime.Now, Image = "images/chau.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "arturo.anand@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Meztitla", Description = "Casa Meztitla by Arturo Anand is a rustic retreat in Mexico that harmonizes with its natural surroundings through raw materials and open, minimalist design.", DateCreated = DateTime.Now, Image = "images/meztitla.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "gytis.barzdukas@gmail.com").UserintID},
    new Architect{UserintID=users.Single(u => u.Email == "yan.li@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Rural", Description = "The Rural House by Yan Li is a secluded residence in Spain that blends seamlessly into its natural landscape with a minimalist and earthy design.", DateCreated = DateTime.Now, Image = "images/rural.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "peggy.justice@gmail.com").UserintID},
    new Architect{UserintID=users.Single(u => u.Email == "laurna.norman@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "West", Description = "Description 4", DateCreated = DateTime.Now, Image = "images/west.jpg" } } },
    

};

foreach (Architect c in arhitekti)
{
    context.Architects.Add(c);
}
context.SaveChanges();
    }
}
}
