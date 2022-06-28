using Microsoft.EntityFrameworkCore;

namespace OOauthApi.Models
{
    public class Housemodelcontext : DbContext
    {
        //this refers to the database declared in the appsettings.json
        public Housemodelcontext(DbContextOptions<Housemodelcontext> options) : base(options)
        {

        }
        public DbSet<Housemodel> Houses { get; set; }
    }
}
