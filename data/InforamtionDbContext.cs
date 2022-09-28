using Microsoft.EntityFrameworkCore;
using WebApiCrudOp.model;

namespace WebApiCrudOp.data
{
    public class InforamtionDbContext:DbContext
    {
        public InforamtionDbContext(DbContextOptions<InforamtionDbContext> options) : base(options)
        {

        }
        public DbSet<Information> Informations { get; set; }
    }
}
