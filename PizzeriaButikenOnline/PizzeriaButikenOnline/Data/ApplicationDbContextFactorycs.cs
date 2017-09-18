using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PizzeriaButikenOnline.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-PizzeriaButikenOnline-11961974-FB84-4488-917C-7539E14098ED;Trusted_Connection=True;MultipleActiveResultSets=true");
            var db = new ApplicationDbContext(builder.Options);
            return db;
        }
    }
}
