using Microsoft.EntityFrameworkCore;

namespace CarRentalPlatform.Infrastructure.Persistence
{
    internal class CarRentalDbInitializer : IInitializer
    {
        private readonly CarRentalDbContext db;

        public CarRentalDbInitializer(CarRentalDbContext db)
        {
            this.db = db;
        }

        public void Initialize()
        {
            this.db.Database.Migrate();
        }
    }
}
