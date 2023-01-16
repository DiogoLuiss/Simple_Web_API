using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ExatoApi.Models
{
    public class Context: DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)  
        
        {
       
        }

        public DbSet<Products> Products { get; set; }   
        
    

    }
}
