using Microsoft.EntityFrameworkCore;
using RESTful_With_Azure_and_REACTJS.Model.Context;
using System.Configuration;
using RESTful_With_Azure_and_REACTJS.Repository;
using RESTful_With_Azure_and_REACTJS.Repository.Implementations;

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
            services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();
        }
    }
}
