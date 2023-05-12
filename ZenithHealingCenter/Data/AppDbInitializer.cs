using Microsoft.AspNetCore.Identity;
using ZenithHealingCenter.Data.Static;
using ZenithHealingCenter.Models;

namespace ZenithHealingCenter.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                // Doctors
                if(!context.Doctors.Any())
                {
                    context.Doctors.AddRange(new List<Doctor>()
                    {
                        new Doctor()
                        {
                            FullName = "Naicu Tudor",
                            SpecializareDoctor = Enums.Specializare.Oftalmologie,
                            ImageURL = "https://t4.ftcdn.net/jpg/03/05/41/27/360_F_305412791_XRNiWaFCREjLLpSQfj0e736foBoYXXYv.jpg"
                        },

                         new Doctor()
                        {
                            FullName = "Voina Sebastian",
                            SpecializareDoctor = Enums.Specializare.Ginecologie,
                            ImageURL = "https://t4.ftcdn.net/jpg/03/05/41/27/360_F_305412791_XRNiWaFCREjLLpSQfj0e736foBoYXXYv.jpg"
                        },

                         new Doctor()
                        {
                            FullName = "Popa Ioana",
                            SpecializareDoctor = Enums.Specializare.Cardiologie,
                            ImageURL = "https://img.freepik.com/free-photo/beautiful-young-female-doctor-looking-camera-office_1301-7807.jpg?w=2000"
                        },
                         new Doctor()
                        {
                            FullName = "Rizel Catalina",
                            SpecializareDoctor = Enums.Specializare.Dermatologie,
                            ImageURL = "https://img.freepik.com/free-photo/beautiful-young-female-doctor-looking-camera-office_1301-7807.jpg?w=2000"
                        },
                         new Doctor()
                         {
                             FullName = "Dr. Haus",
                             SpecializareDoctor = Enums.Specializare.Diabetologie,
                             ImageURL = "https://cdn.wallpapersafari.com/63/37/vqmB61.jpg"
                         }

                    });
                    context.SaveChanges();
                }

                // Cabinete
                if (!context.Cabinets.Any())
                {
                    context.Cabinets.AddRange(new List<Cabinet>()
                    {
                        new Cabinet()
                        {
                            Name = "Cabinet Ginecologie",
                            Description = "Sala 304",

                        },

                        new Cabinet()
                        {
                            Name = "Cabinet Dermatologie",
                            Description = "Sala 303",

                        },
                        new Cabinet()
                        {
                            Name = "Cabinet Cardiologie",
                            Description = "Sala 302",

                        },
                        new Cabinet()
                        {
                            Name = "Cabinet Diabetologie",
                            Description = "Sala 301",

                        },

                        new Cabinet()
                        {
                            Name = "Cabinet Oftalmologie",
                            Description = "Sala 305",

                        }
                    });
                    context.SaveChanges();
                }

                // Pachet
                if (!context.MedicalPackages.Any())
                {
                    context.MedicalPackages.AddRange(new List<MedicalPackage>()
                    {
                        new MedicalPackage()
                        {
                            Name = "Pachet sreening diabet",
                            Description = "Consult medicina generala/interna" +
                            "Glucoza serica(glicemie)",
                            Price = 280,
                            ImageFile = "https://smartliving.ro/wp-content/uploads/2020/01/glicemia-mare-cauze-manifestari-tratament-scaled.jpg",
                            SpecializarePachet = Enums.Specializare.Diabetologie,
                            CabinetId = 4,
                            DoctorId = 5
                        },

                        new MedicalPackage()
                        {
                            Name = "Pachet sreening cardiovascular",
                            Description = "Consult medicina generala/interna " +
                            "Profil lipidic(LDC colesterol, HDL colesterol, colesterol total, trigliceride)",
                            Price = 360,
                            ImageFile = "https://img.freepik.com/free-vector/cardiology-clinic-hospital-department-healthy-heart-cardiovascular-prevention-healthcare-industry-idea-design-element-electrocardiogram-ekg-vector-isolated-concept-metaphor-illustration_335657-1516.jpg?w=2000",
                            SpecializarePachet = Enums.Specializare.Cardiologie,
                            CabinetId = 3,
                            DoctorId = 3
                        },

                        new MedicalPackage()
                        {
                            Name = "Pachet sreening cancer de piele",
                            Description = "Consult dermatologie" +
                            "Dermatoscopie (fara inregitrare date)",
                            Price = 200,
                            ImageFile = "https://img.freepik.com/free-vector/tiny-dermatologist-examining-dry-face-skin-flat-vector-illustration-abstract-epidermis-disease-diagnostics-treatment-dermatology-health-medical-protection-cosmetology-concept_74855-10167.jpg",
                            SpecializarePachet = Enums.Specializare.Dermatologie,
                            CabinetId = 2,
                            DoctorId = 4
                        },

                        new MedicalPackage()
                        {
                            Name = "Pachet consult oftalmologic",
                            Description = "Consult oftalmologic: Autorefractometrie, Determinarea acuitatii vizuale, Masurarea tensiniunii intraoculare, Biomicroscopia, Examinarea fundului de ochi",
                            Price = 410,
                            ImageFile = "https://thumbs.dreamstime.com/b/ophthalmology-web-banner-page-tiny-cartoon-people-ophthalmology-medicine-optical-eyesight-examination-flat-vector-158504291.jpg",
                            SpecializarePachet = Enums.Specializare.Oftalmologie,
                            CabinetId = 5,
                            DoctorId = 1
                        },
                    }) ;
                    context.SaveChanges();
                }
            }
        }

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

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@zhc.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "adminuser",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "zenithAdmin@1234!");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "naicutudor@zenith.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Naicu Tudor Andrei",
                        UserName = "naicutudor09",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "tudorZenith@1234!");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
