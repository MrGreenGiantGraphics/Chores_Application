namespace ProjectChore_Application
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProjectChoresDBEntities : DbContext
    {
        public ProjectChoresDBEntities()
            : base("name=ProjectChoresDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Chore> Chores { get; set; }
        public virtual DbSet<ChoreLookUp> ChoreLookUps { get; set; }
        public virtual DbSet<Kid> Kids { get; set; }
    }
}
