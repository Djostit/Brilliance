namespace Brilliance.API.Services
{
    public class SeedDataService
    {
        private readonly BrillianceContext _context;
        private readonly IPasswordHasher _passwordHasher;
        public SeedDataService(BrillianceContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public async Task InitializeData()
        {
            if (!_context.Roles.Any())
            {
                await _context.Roles.AddRangeAsync(new Role[]
                {
                    new()
                    {
                        Name = "User",
                    },new()
                    {
                        Name = "Moderator",
                    }
                });
                await _context.SaveChangesAsync();
            }
            if (!_context.Users.Any())
            {
                await _context.Users.AddRangeAsync(new User[]
                {
                    new()
                    {
                        Username = "Bob",
                        Password = _passwordHasher.HashPassword("Bob")
                    },new()
                    {
                        IdRole = 2,
                        Username = "Tom",
                        Password = _passwordHasher.HashPassword("Tom")
                    },new()
                    {
                        Username = "Bet",
                        Password = _passwordHasher.HashPassword("Bet")
                    },new()
                    {
                        Username = "Rick",
                        Password = _passwordHasher.HashPassword("Rick")
                    },new()
                    {
                        Username = "Morty",
                        Password = _passwordHasher.HashPassword("Morty")
                    },
                });
                await _context.SaveChangesAsync();
            }
            if (!_context.Categories.Any())
            {
                await _context.Categories.AddRangeAsync(new Category[]
                {
                    new()
                    {
                        Name = "Blazor",
                    },new()
                    {
                        Name = "WPF",
                    },new()
                    {
                        Name = "UWP",
                    },new()
                    {
                        Name = "ASP.NET",
                    },new()
                    {
                        Name = "Entity Framework",
                    },new()
                    {
                        Name = "Xamarin",
                    },new()
                    {
                        Name = "Unity",
                    },new()
                    {
                        Name = "Azure",
                    },new()
                    {
                        Name = "Docker",
                    },new()
                    {
                        Name = "Тестирование (NUnit, xUnit, MSTest и др.)",
                    },new()
                    {
                        Name = "Разработка игр",
                    },new()
                    {
                        Name = "Security",
                    },new()
                    {
                        Name = "DevOps",
                    },new()
                    {
                        Name = "WinForms",
                    },new()
                    {
                        Name = "LINQ",
                    },new()
                    {
                        Name = "WinForms",
                    },new()
                    {
                        Name = "Code Reviews",
                    },new()
                    {
                        Name = "Design Patterns",
                    },new()
                    {
                        Name = "SOLID Principles",
                    },new()
                    {
                        Name = "Dependency Injection",
                    },new()
                    {
                        Name = "Reactive Programming",
                    },new()
                    {
                        Name = "Mobile Development",
                    },new()
                    {
                        Name = "Cloud Computing",
                    },new()
                    {
                        Name = "Microservices",
                    },new()
                    {
                        Name = "Machine Learning (ML.NET)",
                    },new()
                    {
                        Name = "SignalR",
                    }
                });
                await _context.SaveChangesAsync();
            }
            if (!_context.Posts.Any())
            {
                await _context.Posts.AddRangeAsync(new Post[]
                {
                    new()
                    {
                        IdUser = 1,
                        IdCategory = 1,
                        Title = "Crafting Interactive Web Experiences with C#",
                        Description = "Discover the magic of Blazor as we delve into its architecture and demonstrate how to build dynamic and responsive web applications using C#."
                    },

                    new()
                    {
                        IdUser = 3,
                        IdCategory = 2,
                        Title = "Elevating User Interfaces with C#",
                        Description = "Unlock the full potential of Windows Presentation Foundation (WPF) by exploring advanced techniques, design principles, and best practices."
                    },

                    new()
                    {
                        IdUser = 3,
                        IdCategory = 3,
                        Title = "Building Universal Windows Apps with C#",
                        Description = "Get a comprehensive guide to Universal Windows Platform (UWP) development, covering everything from design principles to deployment strategies."
                    },
                    new()
                    {
                        IdUser = 4,
                        IdCategory = 4,
                        Title = "Exploring the Core of Web Development",
                        Description = "Delve into the world of ASP.NET and uncover the powerful tools and techniques that make it a cornerstone for web application development."
                    },

                    new()
                    {
                        IdUser = 5,
                        IdCategory = 5,
                        Title = "Taming Data with C#",
                        Description = "Navigate the realms of Entity Framework and learn how to seamlessly interact with databases, leveraging the capabilities of C#."
                    },

                    new()
                    {
                        IdUser = 4,
                        IdCategory = 6,
                        Title = "Crafting Cross-Platform Mobile Apps with C#",
                        Description = "Embark on a journey through Xamarin, exploring how it empowers developers to build stunning cross-platform mobile applications using C#."
                    },

                    new()
                    {
                        IdUser = 5,
                        IdCategory = 7,
                        Title = "Creating Games with the Power of C#",
                        Description = "Dive into the Unity game development environment and harness the capabilities of C# to create immersive and engaging gaming experiences."
                    },

                    new()
                    {
                        IdUser = 1,
                        IdCategory = 8,
                        Title = "Transforming Ideas into Cloud Solutions with C#",
                        Description = "Discover the enchanting world of Microsoft Azure and learn how C# can be wielded to build scalable, secure, and efficient cloud solutions."
                    },

                    new()
                    {
                        IdUser = 1,
                        IdCategory = 9,
                        Title = "Containerization Unveiled with C#",
                        Description = "Unravel the mysteries of Docker and understand how C# can be seamlessly integrated to containerize applications for enhanced deployment and scalability."
                    },

                    new()
                    {
                        IdUser = 1,
                        IdCategory = 10,
                        Title = "Navigating the C# Testing Landscape",
                        Description = "Embark on a journey through the various testing frameworks in the C# ecosystem, exploring how they ensure the robustness of your code."
                    },

                    new()
                    {
                        IdUser = 1,
                        IdCategory = 11,
                        Title = "Exploring C# in Game Development",
                        Description = "Journey through the diverse landscape of game development in C#, covering engines, graphics, sound, and the overall magic that brings games to life."
                    },

                    new()
                    {
                        IdUser = 1,
                        IdCategory = 12,
                        Title = "Safeguarding C# Applications",
                        Description = "Embark on a quest to fortify your C# applications as we explore security best practices, common vulnerabilities, and protective measures."
                    },

                    new()
                    {
                        IdUser = 1,
                        IdCategory = 13,
                        Title = "Automation and CI/CD in C#",
                        Description = "Join the battle in the DevOps arena, discovering how C# can be the cornerstone for automating processes and ensuring smooth CI/CD pipelines."
                    },
                    new()
                    {
                        IdUser = 1,
                        IdCategory = 14,
                        Title = "Building Desktop Apps with C#",
                        Description = "Unlock the secrets of Windows Forms (WinForms) as we guide you through the creation of powerful and intuitive desktop applications using C#."
                    },

                    new()
                    {
                        IdUser = 1,
                        IdCategory = 15,
                        Title = "Mastering Querying in C#",
                        Description = "Dive into the world of Language-Integrated Query (LINQ) and learn how to wield its power to simplify and optimize data querying in C# applications."
                    },

                    new()
                    {
                        IdUser = 1,
                        IdCategory = 16,
                        Title = "C# Language Features Demystified",
                        Description = "Embark on a journey through the various language features of C#, exploring how each one contributes to making your code more expressive and powerful."
                    },

                    new()
                    {
                        IdUser = 1,
                        IdCategory = 17,
                        Title = "Nurturing Quality in C# Projects",
                        Description = "Explore the art of code reviews in C# development, delving into best practices, tools, and strategies to ensure the quality of your codebase."
                    },

                    new()
                    {
                        IdUser = 1,
                        IdCategory = 18,
                        Title = "Architecting for Success",
                        Description = "Embark on a journey through common design patterns in C#, understanding how they can be applied to solve recurring design problems and create scalable solutions."
                    },

                    new()
                    {
                        IdUser = 1,
                        IdCategory = 19,
                        Title = "Building Robust C# Applications",
                        Description = "Delve into the SOLID principles of object-oriented design, understanding how they form the foundation for creating maintainable and scalable C# applications."
                    },

                    new()
                    {
                        IdUser = 1,
                        IdCategory = 20,
                        Title = "Empowering C# Applications",
                        Description = "Navigate the intricacies of dependency injection in C#, exploring its benefits and learning how to implement this powerful pattern to enhance code flexibility."
                    },

                    new()
                    {
                        IdUser = 1,
                        IdCategory = 21,
                        Title = "C# in Motion",
                        Description = "Dive into the world of reactive programming in C#, discovering how it enables the creation of responsive and interactive applications through asynchronous data streams."
                    },

                    new()
                    {
                        IdUser = 1,
                        IdCategory = 22,
                        Title = "C# in Cross-Platform Mobile Development",
                        Description = "Embark on a journey through cross-platform mobile development with C#, exploring frameworks, tools, and best practices for creating stunning mobile applications."
                    },
                    new()
                    {
                        IdUser = 1,
                        IdCategory = 23,
                        Title = "C# in the Azure Sky",
                        Description = "Embark on a cloud computing adventure with C# as your guide, exploring the vast possibilities and services offered by the Microsoft Azure platform."
                    },

                    new()
                    {
                        IdUser = 1,
                        IdCategory = 24,
                        Title = "Crafting Scalable Solutions with C#",
                        Description = "Uncover the secrets of microservices architecture and learn how C# can be wielded to build scalable, modular, and maintainable distributed systems."
                    },

                    new()
                    {
                        IdUser = 1,
                        IdCategory = 25,
                        Title = "ML.NET and C#",
                        Description = "Explore the intersection of C# and machine learning with ML.NET, learning how to integrate machine learning capabilities into your C# applications."
                    },

                    new()
                    {
                        IdUser = 1,
                        IdCategory = 26,
                        Title = "Real-Time Communication with C#",
                        Description = "Dive into the world of real-time communication with SignalR, discovering how C# can be used to build interactive and responsive web applications."
                    }
                });
                await _context.SaveChangesAsync();
            }
            if (!_context.Comments.Any())
            {
                await _context.AddRangeAsync(new Comment[]
                {
                    new Comment
                    {
                        IdPost = 3,
                        IdUser = 1,
                        Name = "Blazor is truly magical!"
                    },
                    new Comment
                    {
                        IdPost = 4,
                        IdUser = 1,
                        Name = "WPF has been a staple for desktop development."
                    },
                    new Comment
                    {
                        IdPost = 5,
                        IdUser = 1,
                        Name = "UWP is versatile! What devices have you targeted with your UWP applications?"
                    },
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
