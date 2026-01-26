namespace Circulars.Infrastructure.Context
{
    public class DBContext : DbContext
    {

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<Circular>().Property(n => n.ApprovalId).IsRequired(false);
            modelBuilder.Entity<Circular>().Property(n => n.IssuerId).IsRequired(false);
            modelBuilder.Entity<Circular>().Property(n => n.EnforcementId).IsRequired(false);
        }
        public DbSet<Circular> Circular { get; set; }
        public DbSet<OrgConcerned> OrgsConcerned { get; set; }
        public DbSet<RelatedDocuments> RelatedDocuments { get; set; }
        public DbSet<CircularOrg> CircularOrgs { get; set; }
        public DbSet<CircularUsers> CircularUsers { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<LK_Approval> Approvals { get; set; }
        public DbSet<LK_Message> Messages { get; set; }

        public DbSet<LK_Enforcement> Enforcements { get; set; }
        public DbSet<LK_Issuer> Issuers { get; set; }
        public bool AllMigrationsApplied()
        {
            var applied = this.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = this.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        public void Migrate()
        {
            this.Database.Migrate();
        }
    }
}