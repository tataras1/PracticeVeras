namespace aspfirst
{
    using Microsoft.EntityFrameworkCore;
    public class ApplicationContext : DbContext
    {
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Рельсы;Trusted_Connection=True;");
        }
    }
}
