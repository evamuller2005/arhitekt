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
            new User{FirstName="Carson",LastName="Alexander",Email="alexander.carlson@gmail.com",Password="password",Role=UserRole.Architect},
            new User{FirstName="Arturo",LastName="Anand",Email="arturo.anand@gmail.com",Password="password",Role=UserRole.Architect},
            new User{FirstName="Gytis",LastName="Barzdukas",Email="gytis.barzdukas@gmail.com",Password="password",Role=UserRole.Architect},
            new User{FirstName="Yan",LastName="Li",Email="yan.li@gmail.com",Password="password",Role=UserRole.Architect},
            new User{FirstName="Peggy",LastName="Justice",Email="peggy.justice@gmail.com",Password="password",Role=UserRole.Architect},
            new User{FirstName="Laura",LastName="Norman",Email="laurna.norman@gmail.com",Password="password",Role=UserRole.Architect},
            new User{FirstName="Logan",LastName="Harris",Email="logan.harris@gmail.com",Password="password",Role=UserRole.Architect},
            new User{FirstName="Noah",LastName="Jackson",Email="noah.jackson@gmail.com",Password="password",Role=UserRole.Architect},
            new User{FirstName="Olivia",LastName="Clark",Email="olivia.clark@gmail.com",Password="password",Role=UserRole.Architect},
            new User{FirstName="Henry",LastName="Carter",Email="henry.carter@gmail.com",Password="password",Role=UserRole.Architect},
            new User{FirstName="Lucy",LastName="Collins",Email="lucy.collins@gmail.com",Password="password",Role=UserRole.Architect},
            new User{FirstName="Nathan",LastName="Morris",Email="nathan.morris@gmail.com",Password="password",Role=UserRole.Architect},
            new User{FirstName="Amelia",LastName="Turner",Email="amelia.turner@gmail.com",Password="password",Role=UserRole.Architect},
            new User{FirstName="Ethan", LastName="Baker", Email="ethan.baker@gmail.com", Password="password", Role=UserRole.Architect},
            new User{FirstName="Ava", LastName="Mitchell", Email="ava.mitchell@gmail.com", Password="password", Role=UserRole.Architect},
            new User{FirstName="Liam", LastName="Davis", Email="liam.davis@gmail.com", Password="password", Role=UserRole.Architect},
            new User{FirstName="Ella", LastName="Morgan", Email="ella.morgan@gmail.com", Password="password", Role=UserRole.Architect},
            new User{FirstName="Jackson", LastName="Green", Email="jackson.green@gmail.com", Password="password", Role=UserRole.Architect},
            new User{FirstName="Mia", LastName="Martinez", Email="mia.martinez@gmail.com", Password="password", Role=UserRole.Architect},
            new User{FirstName="Logan", LastName="Hall", Email="logan.hall@gmail.com", Password="password", Role=UserRole.Architect},
            new User{FirstName="Ethan", LastName="Taller", Email="ethan.taller@gmail.com", Password="password", Role=UserRole.Architect},
                    
            new User { FirstName = "John", LastName = "Doe", Email = "john.doe@gmail.com", Password = "password", Role = UserRole.Architect },
            new User { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@gmail.com", Password = "password", Role = UserRole.Architect },
            new User { FirstName = "Alice", LastName = "Johnson", Email = "alice.johnson@gmail.com", Password = "password", Role = UserRole.Architect },
            new User { FirstName = "Bob", LastName = "Brown", Email = "bob.brown@gmail.com", Password = "password", Role = UserRole.Architect },
            new User { FirstName = "Charlie", LastName = "Davis", Email = "charlie.davis@gmail.com", Password = "password", Role = UserRole.Architect },
            new User { FirstName = "Diana", LastName = "Evans", Email = "diana.evans@gmail.com", Password = "password", Role = UserRole.Architect },
            new User { FirstName = "Frank", LastName = "Garcia", Email = "frank.garcia@gmail.com", Password = "password", Role = UserRole.Architect },
            new User { FirstName = "Grace", LastName = "Harris", Email = "grace.harris@gmail.com", Password = "password", Role = UserRole.Architect },
            new User { FirstName = "Henry", LastName = "Lee", Email = "henry.lee@gmail.com", Password = "password", Role = UserRole.Architect }


        };

        foreach (User s in users)
        {
            context.Users.Add(s);
        }
        context.SaveChanges();

        var arhitekti = new Architect[]
{
    new Architect{UserintID=users.Single(u => u.Email == "alexander.carlson@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Chau", Description = "The House in Chau Doc by Alexander Carlson is a terraced, open-air residence in Vietnam that seamlessly integrates greenery and natural ventilation.", DateCreated = DateTime.Now, Image = "images/chau.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "arturo.anand@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Meztitla", Description = "Casa Meztitla by Arturo Anand is a rustic retreat in Mexico that harmonizes with its natural surroundings through raw materials and open, minimalist design.", DateCreated = DateTime.Now, Image = "images/meztitla.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "yan.li@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Rural", Description = "The Rural House by Yan Li is a secluded residence in Spain that blends seamlessly into its natural landscape with a minimalist and earthy design.", DateCreated = DateTime.Now, Image = "images/rural.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "laurna.norman@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "West", Description = "Description 4", DateCreated = DateTime.Now, Image = "images/west.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "peggy.justice@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "KODA", Description = "A prefabricated, movable tiny home that offers a sustainable and flexible living solution.", DateCreated = DateTime.Now, Image = "images/koda.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "gytis.barzdukas@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Chameleon Villa", Description = "A tropical villa in Bali that blends modern architecture with traditional Indonesian elements, creating a harmonious retreat.", DateCreated = DateTime.Now, Image = "images/chameleon.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "logan.harris@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Peter's House", Description = "A minimalist residence that combines Scandinavian design principles with functional living spaces.", DateCreated = DateTime.Now, Image = "images/peter.jpg" }, new Project { Name = "Casa N", Description = "A contemporary home that emphasizes open-plan living and a strong connection to the outdoors.", DateCreated = DateTime.Now, Image = "images/casan.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "noah.jackson@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Napoli Afragola Station", Description = "A high-speed train station in Naples, Italy, featuring a dynamic and futuristic design that serves as a gateway to the city.", DateCreated = DateTime.Now, Image = "images/napoli.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "henry.carter@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Antwerp Port House", Description = "A striking design that merges a modern glass structure with a historic building, symbolizing innovation and tradition.", DateCreated = DateTime.Now, Image = "images/antwerp.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "lucy.collins@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Back Country House", Description = "A sustainable retreat designed for family living, blending indoor and outdoor spaces seamlessly.", DateCreated = DateTime.Now, Image = "images/back.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "nathan.morris@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Bigwood", Description = "A mountain home that combines modern living with rustic charm, set in the natural beauty of Idaho.", DateCreated = DateTime.Now, Image = "images/bigwood.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "amelia.turner@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Carmel Valley Residence", Description = "A contemporary residence that emphasizes harmony with the landscape, featuring expansive views and natural materials.", DateCreated = DateTime.Now, Image = "images/carmel.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "ethan.baker@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "It is a Garden", Description = "An architectural exploration blending nature and living spaces into one cohesive form.", DateCreated = DateTime.Now, Image = "images/garden.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "ava.mitchell@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "SS3 House", Description = "A contemporary residence with minimalist design and functional elegance.", DateCreated = DateTime.Now, Image = "images/ss3.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "liam.davis@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Four Leaves Villa", Description = "A unique architectural design inspired by the organic shape of leaves.", DateCreated = DateTime.Now, Image = "images/four.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "ella.morgan@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "The House with the Gabion", Description = "An innovative house design incorporating gabions for a unique aesthetic.", DateCreated = DateTime.Now, Image = "images/gabion.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "jackson.green@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "The House of Secret Gardens", Description = "A serene residence blending indoor and outdoor spaces with lush greenery.", DateCreated = DateTime.Now, Image = "images/secret.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "mia.martinez@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "H3 House", Description = "A minimalist concrete house that balances privacy and openness.", DateCreated = DateTime.Now, Image = "images/h3.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "logan.hall@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Hikari House", Description = "A light-filled residence that embraces simplicity and harmony.", DateCreated = DateTime.Now, Image = "images/hikari.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "olivia.clark@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Hopper House", Description = "An innovative design maximizing natural light and spatial efficiency.", DateCreated = DateTime.Now, Image = "images/hopper.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "ethan.taller@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Naked House", Description = "A minimalistic and modern house by Taller Estilo Arquitectura, emphasizing simplicity and light.", DateCreated = DateTime.Now, Image = "images/naked.jpg" } } },
    
    
    new Architect{UserintID=users.Single(u => u.Email == "john.doe@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Ownerless House No. 01", Description = "A creative and adaptable house concept designed to challenge traditional ownership and use.", DateCreated = DateTime.Now, Image = "images/ownerless.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "jane.smith@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Piano House", Description = "A unique house with an elegant and refined piano-inspired design by Line Architects.", DateCreated = DateTime.Now, Image = "images/piano.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "alice.johnson@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "The Quest", Description = "A sleek and modern home set against a stunning natural backdrop, designed by Strom Architects.", DateCreated = DateTime.Now, Image = "images/quest.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "bob.brown@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "911 Villa", Description = "A contemporary villa with clean lines and luxurious living spaces, designed by Vaco Design.", DateCreated = DateTime.Now, Image = "images/911.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "charlie.davis@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Collage House", Description = "A residence blending reclaimed materials and modern design by S+PS Architects.", DateCreated = DateTime.Now, Image = "images/collage.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "diana.evans@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "The Courtyard House", Description = "A house built around a serene courtyard, emphasizing indoor-outdoor living by Auhaus Architecture.", DateCreated = DateTime.Now, Image = "images/courtyard.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "frank.garcia@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Crystal Houses", Description = "A striking facade of glass bricks creating a transparent yet strong structure by MVRDV.", DateCreated = DateTime.Now, Image = "images/crystal.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "grace.harris@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Diya", Description = "A minimalist and serene residence in India, blending modern design with traditional materials by Spasm Design Architects.", DateCreated = DateTime.Now, Image = "images/diya.jpg" } } },
    new Architect{UserintID=users.Single(u => u.Email == "henry.lee@gmail.com").UserintID, Projects = new List<Project> { new Project { Name = "Escobar Renovation", Description = "A thoughtful renovation merging modern aesthetics with original charm by Chen+Suchart Studio.", DateCreated = DateTime.Now, Image = "images/escobar.jpg" } } }
};

foreach (Architect c in arhitekti)
{
    context.Architects.Add(c);
}
context.SaveChanges();
    }
}
}
