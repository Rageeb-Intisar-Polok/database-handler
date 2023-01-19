using AdminDBHandler.Models.Dept_Level_Term;
using AdminDBHandler.Models.User;
using AdminDBHandler.Models.User.User_Types;
using DatabaseHandler.Models.Generated;
using DatabaseHandler.Models_and_repositories.Role;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Hosting;

namespace DatabaseHandler.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Department> departments { get; set; }
        public DbSet<Level_Term> levelTerm { get; set; }
        public DbSet<Connection> connections { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<Officials> officials { get; set; }
        public DbSet<Students> students { get; set; }
        public DbSet<Teachers> teachers { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Role> roles { get; set; }

    }
}
