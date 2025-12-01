using Microsoft.EntityFrameworkCore;

namespace Greenhouse.Data
{
    public class DbInitializer
    {
        public static void Initialize(GreenhouseDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
