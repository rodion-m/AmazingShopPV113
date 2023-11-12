using Microsoft.EntityFrameworkCore;

namespace AmazingShopPV113.Backend.Data
{
    public class AppDbContext : DbContext
    {
        //Список таблиц:
        public DbSet<Product> Products => Set<Product>();

        public AppDbContext(
            DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }

}
