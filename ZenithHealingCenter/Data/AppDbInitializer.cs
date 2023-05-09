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
                            SpecializareDoctor = Enums.Specializare.Ginecologie,
                            ImageURL = "C:\\Users\\naicu\\Pictures\\Poze\\12A-745copy3.jpg"
                        },

                         new Doctor()
                        {
                            FullName = "Voina Sebastian",
                            SpecializareDoctor = Enums.Specializare.Ginecologie,
                            ImageURL = "C:\\Users\\naicu\\Downloads\\WhatsApp Image 2023-05-09 at 19.32.33.jpeg"
                        },

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
                            Name = "Cabinetul Ginecologilor de alaturi",
                            Description = "Sala 305 B",

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
                            Description = "Consult mdeicina generala/interna; Glucoza serica(glicemie)",
                            Price = 280,
                            ImageFile = "C:\\Users\\naicu\\Desktop\\II\\Proiect\\Screenshot 2023-05-09 193550.jpg",
                            SpecializarePachet = Enums.Specializare.Diabetologie

                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
