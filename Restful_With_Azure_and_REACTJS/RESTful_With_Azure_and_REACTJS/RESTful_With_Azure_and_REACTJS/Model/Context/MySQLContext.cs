using Microsoft.EntityFrameworkCore;

namespace RESTful_With_Azure_and_REACTJS.Model.Context
{
    public class MySQLContext: DbContext
    {

        public MySQLContext()
        {

        }
        public MySQLContext(DbContextOptions<MySQLContext> options): base(options) { }

        public DbSet<Person> Persons { get; set; }
    
    }
}
