using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entitties.User;

namespace OnlineShop.Data.AppDbContext;

public class OnlineShopDBContext : DbContext
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
    }

    #endregion

}
