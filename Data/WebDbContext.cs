using Microsoft.EntityFrameworkCore;

namespace WebAsp.Data
{
    public class WebDbContext: DbContext
    {
        public WebDbContext(DbContextOptions<WebDbContext> options) : base(options)
        {
        }
    }
}
