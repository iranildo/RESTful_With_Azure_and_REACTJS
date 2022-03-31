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
            // Injeção de Dependêcia
            services.AddScoped<IPersonService, PersonServiceImplementation>();
        }
    }
}
