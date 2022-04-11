using Manager.Domain.Entities;
using Manager.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Context
{
    public class ManagerContext : DbContext
    {
        public ManagerContext() {}
        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options) {}

        public virtual DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }

        #region security flaw
        // Isto é uma falha de segurança, não se deve deixar visivel a string de conexão.
        // Security flaw, you must not make the 'connection string' visible.

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .UseSqlServer(@"Server = localhost,1433; Database=managerAPI; User ID=sa; password=!@#$%12345;TrustServerCertificate=True");
        //}
        #endregion
    }
}
