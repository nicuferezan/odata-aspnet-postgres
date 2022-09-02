using Microsoft.EntityFrameworkCore;
using ODataAPI.Entities;

namespace ODataAPI.EntityFramework
{

    public class ActivityAppContext : DbContext
    {
        //here is the view/table name
        public DbSet<Activity> activity { get; set; }

        public ActivityAppContext(DbContextOptions<ActivityAppContext> options) : base(options)
        {

        }
    }
}
