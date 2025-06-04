using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entitties;
using OnlineShop.Domain.Entitties.Identity;
using OnlineShop.Domain.Entitties.User;

namespace OnlineShop.Data.AppDbContext;

public class OnlineShopDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
{
    #region ctor  
    public OnlineShopDBContext(DbContextOptions<OnlineShopDBContext> options) : base(options)
    {

    }
    #endregion

    #region DbSets  

    #region UserDbSet  
    public DbSet<User> Users { get; set; }

    #endregion

    #endregion

    #region Model Creating  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (var fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationRole>().HasData(
            new ApplicationRole { Id = 1, Name = "Admin", NormalizedName = "ADMIN", description = "مدیر سیستم" },
            new ApplicationRole { Id = 2, Name = "User", NormalizedName = "USER", description = " کاربر عادی " },
            new ApplicationRole { Id = 3, Name = "Editor", NormalizedName = "EDITOR", description = "ویرایشگر محتوا" }
            );
    }

    #endregion
}
