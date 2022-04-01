using Microsoft.EntityFrameworkCore;
using RESTful_With_Azure_and_REACTJS.Model.Context;
using RESTful_With_Azure_and_REACTJS.Services.Implementations;
using System.Configuration;

namespace RESTful_With_Azure_and_REACTJS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var connection = Configuration["MySQLConnection: MySQLConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, null));
            // Injeção de Dependêcia
            services.AddScoped<IPersonService, PersonServiceImplementation>();
        }
    }
}
