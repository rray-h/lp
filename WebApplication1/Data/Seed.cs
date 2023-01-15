using Microsoft.AspNetCore.Identity;
using WebApplication1.Models;


namespace WebApplication1.Data
{
    public class Seed
    {
        //Data
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDBContext>();

                context.Database.EnsureCreated();
                //Query

                if (!context.query.Any())
                {
                    context.query.AddRange(new List<Query>()
                            {
                                new Query()
                                {
                                    Name = "My problem",
                                    Description = "dsadasd",
                                    Model="dsasaas",
                                    PhoneNumber = "88005553535",
                                    Problem = "dssaas",
                                    IsItQuick = true,
                                    CanBeRedacted = true
                                },
                                new Query()
                                    {
                                        Name = "Роутер",
                                        Description = "Приходит как-то улитка в бар и просит виски с колой,а бармен ей говорит: ",
                                        Model="BaikanurBased7921",
                                        PhoneNumber = "88005553535",
                                        Problem = "Перестал работать",
                                        IsItQuick = false,
                                        CanBeRedacted = true

                                    },
                                    new Query()
                                    {
                                        Name = "Телефон от компании славный возврат",
                                        Description = "Приходит как-то улитка в бар и просит виски с колой,а бармен ей говорит: ",
                                        Model="YaDoljenJit",
                                        PhoneNumber = "88005553535",
                                        IsItQuick = false,
                                        Problem = "Сдох",
                                        CanBeRedacted = true
                                }
                           });
                    context.SaveChanges();
                }
            }
        }
        //IdentityFramework
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                if (!await roleManager.RoleExistsAsync(UserRoles.Freelancer))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Freelancer));

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

                //Admin
                string adminUserEmail = "daniltim@gmail.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "Danilka",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }
                //User
                string appUserEmail = "user@etickets.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
                //Freelancer
                string FreelancerEmail = "Freelancer@etickets.com";
                var Freelancer = await userManager.FindByEmailAsync(FreelancerEmail);
                if (Freelancer == null)
                {
                    var newAppUser = new AppUser()
                    {
                        UserName = "Freelancer",
                        Email = FreelancerEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}