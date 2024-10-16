using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Whatchly.Series;
using Watchly.Series;

namespace Watchly.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]

//DbContext es como abstraccion de la base de datos- Vincula con BD
public class WatchlyDbContext :
    AbpDbContext<WatchlyDbContext>,
    ITenantManagementDbContext,
    IIdentityDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Serie> Series { get; set; }

    //Temporada
    public DbSet<Season> Seasons { get; set; }

    //Episodio
    public DbSet<Episode> Episodes { get; set; }

    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext 
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext .
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public WatchlyDbContext(DbContextOptions<WatchlyDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder) //Este metodo se ejecuta cuando se inicia la aplicacion
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */
        builder.Entity<Serie>(b =>
        {
            b.ToTable(WatchlyConsts.DbTablePrefix + "Series",
              WatchlyConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Gender).IsRequired().HasMaxLength(128);
            b.Property(x => x.Actors).IsRequired().HasMaxLength(128);
            b.Property(x => x.Duration).IsRequired().HasMaxLength(128);
            b.Property(x => x.Synopsis).IsRequired().HasMaxLength(128);
            b.Property(x => x.ReleaseDate).IsRequired().HasMaxLength(128);
            b.Property(x => x.Poster).IsRequired().HasMaxLength(128);
            b.Property(x => x.Country).IsRequired().HasMaxLength(128);
            b.Property(x => x.Director).IsRequired().HasMaxLength(128);
            b.Property(x => x.Ratings).IsRequired().HasMaxLength(128);
            b.Property(x => x.TotalSeasons).IsRequired(); // No usa HasMaxLength xq es un int
            // Relación con Temporadas
            b.HasMany(s => s.Seasons)
             .WithOne(t => t.Serie)
             .HasForeignKey(t => t.SerieID)
             .OnDelete(DeleteBehavior.Cascade)
             .IsRequired();
            });
        //Temporada
        builder.Entity<Season>(b =>
        {
            b.ToTable(WatchlyConsts.DbTablePrefix + "Seasons",
               WatchlyConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Title).IsRequired().HasMaxLength(128);
            b.Property(x => x.ReleaseDate).IsRequired().HasMaxLength(128);
            b.Property(x => x.NumberSeason).IsRequired();

            // Relacion con Serie
            b.HasOne(t => t.Serie)
             .WithMany(s => s.Seasons)
             .HasForeignKey(t => t.SerieID)
             .OnDelete(DeleteBehavior.Cascade)
             .IsRequired();
            // Relacion con Episodios
            b.HasMany(t => t.Episodes)
             .WithOne(e => e.Season)
             .HasForeignKey(e => e.SeasonID)
             .OnDelete(DeleteBehavior.Cascade)
             .IsRequired();
        });

        //Episodio
        builder.Entity<Episode>(b =>
        {
            b.ToTable(WatchlyConsts.DbTablePrefix + "Episodes",
                WatchlyConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Title).IsRequired().HasMaxLength(128);
            b.Property(x => x.Director).IsRequired().HasMaxLength(128);
            b.Property(x => x.Writer).IsRequired().HasMaxLength(128);
            b.Property(x => x.Synopsis).IsRequired().HasMaxLength(128);
            b.Property(x => x.Duration).IsRequired().HasMaxLength(128);
            b.Property(x => x.ReleaseDate).IsRequired();
            b.Property(x => x.NumberEpisode).IsRequired();
            b.HasOne(e => e.Season)
             .WithMany(t => t.Episodes)
             .HasForeignKey(e => e.SeasonID)
             .OnDelete(DeleteBehavior.Cascade);
        });


        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureFeatureManagement();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureTenantManagement();
        builder.ConfigureBlobStoring();
        
        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(WatchlyConsts.DbTablePrefix + "YourEntities", WatchlyConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
