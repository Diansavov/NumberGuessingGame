using Number_Guessing.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Number_Guessing.Data

{
    public class MyWorldDbContext : DbContext
    {
        public MyWorldDbContext()
        {


        }

        public MyWorldDbContext(DbContextOptions<MyWorldDbContext> options) : base(options)
        {

        }
        public DbSet<TableData> TableData { get; set; }
    }
}
