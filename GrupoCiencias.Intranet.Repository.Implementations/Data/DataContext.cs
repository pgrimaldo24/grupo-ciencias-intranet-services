using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GrupoCiencias.Intranet.Repository.Implementations.Data
{
    public class DataContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContext;
        public DataContext(DbContextOptions<DataContext> options, IHttpContextAccessor httpContext)
          : base(options)
        {
            _httpContext = httpContext;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
          
        }

    }
}
