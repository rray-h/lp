using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    public class StartUp
    {
        public void ConfigureServices(IServiceCollection services)
        {
            void ConfigureServices(IServiceCollection services)
            => services.AddDbContext<ApplicationDBContext>();
        }
    }
}
