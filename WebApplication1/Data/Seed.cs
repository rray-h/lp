using WebApplication1.Models;


namespace WebApplication1.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDBContext>();

                context.Database.EnsureCreated();
 
                //Users
                if (!context.users.Any())
                {
                    context.users.AddRange(new List<User>()
                    {
                        new User()
                        {
                            Name = "Danil22",
                            Password = "dsasds2aa",
                            UserRole = Enum.UserRoles.Admin,
                            Email = "dads1a@gmail.com",                         
                            PhoneNumber = "880055523535",
                            IsEnabled = false
                        },
                        new User()
                        {
                            Name = "Danil21",
                            Password = "dsasds2aa",
                            UserRole = Enum.UserRoles.StandardUser,
                            Email = "dads1a@gmail.com",
                            PhoneNumber = "880055523535",
                            IsEnabled = false
                        },
                        new User()
                        {
                            Name = "Danil23",
                            Password = "dsasds2aa",
                            UserRole = Enum.UserRoles.Freelancer,
                            Email = "dads1a@gmail.com",
                            PhoneNumber = "880055523535",
                            IsEnabled = false
                        }


                    });
                        //Query

                      if (!context.query.Any())
                        {
                            context.query.AddRange(new List<Query>()
                            {
                                new Query()
                                {
                                    Name = "Моя проблема",
                                    Description = "Приходит как-то улитка в бар и просит виски с колой,а бармен ей говорит: ",
                                    QueryCategory = Enum.QueryCategory.Other,
                                    Problem = "Ты",
                                    Urgency = "13.05.2023",
                                    CanBeRedacted = true,
                                    hasTaken = false
                                },
                                new Query()
                                {
                                    Name = "Роутер 3хххх",
                                    Description = "Приходит как-то улитка в бар и просит виски с колой,а бармен ей говорит: ",
                                     QueryCategory = Enum.QueryCategory.Router,
                                    Problem = "Перестал рабоать",
                                    Urgency = "13.05.2023",
                                    CanBeRedacted = true,
                                    hasTaken = false
                                },
                                new Query()
                                {
                                    Name = "Телефон от компании славный возврат",
                                    Description = "Приходит как-то улитка в бар и просит виски с колой,а бармен ей говорит: ",
                                     QueryCategory = Enum.QueryCategory.Telephone,
                                    Problem = "Сдох",
                                    Urgency = "13.05.2023",
                                    CanBeRedacted = true,
                                    hasTaken = false
                                }



                           });
                    }
                        context.SaveChanges();
                    }
                }
            }
        }
    }

    
/*        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminUserEmail = "teddysmithdeveloper@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "teddysmithdev",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "123 Main St",
                            City = "Charlotte",
                            State = "NC"
                        }
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@etickets.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        Address = new Address()
                        {
                            Street = "123 Main St",
                            City = "Charlotte",
                            State = "NC"
                        }
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}*/