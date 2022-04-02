using Microsoft.EntityFrameworkCore;
using RESTful_With_Azure_and_REACTJS.Model.Context;
using System.Configuration;
using RESTful_With_Azure_and_REACTJS.Repository;
using RESTful_With_Azure_and_REACTJS.Repository.Implementations;
using Serilog;

namespace RESTful_With_Azure_and_REACTJS
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                 .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; } 

        

        public void ConfigureServices(IServiceCollection services)
        {

            
            services.AddControllers();

            var connection = Configuration["MySQLConnection: MySQLConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, null));
            if (Environment.IsDevelopment())
            {
                MigrateDatabse(connection);
            }// Injeção de Dependêcia
            services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();
        }

        private void MigrateDatabse(string connection)
        {
            try
            {
                var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/migrations", "db/dataset" },
                    IsEraseDisabled = true,
                };
                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error("Databse migration falhou", ex);
                throw;
                
            }       
        }
    }
}
