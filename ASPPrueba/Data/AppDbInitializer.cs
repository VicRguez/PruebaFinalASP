using ASPPrueba.Models;

namespace ASPPrueba.Data
{
    public class AppDbInitializer
    {


        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDBContext>();

                context.Database.EnsureCreated();
                if (!context.owners.Any())
                {
                    context.owners.Add(new Owner() { DriverLicense = "dsgf", FirstName = "dfhjf", LastName = "hcfdg" });
                }
               

                   

                
                context.SaveChanges();

            }

        }

    }
}