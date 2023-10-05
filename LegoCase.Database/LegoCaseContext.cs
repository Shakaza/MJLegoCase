using LegoCase.Database.Equipment;
using Microsoft.EntityFrameworkCore;

namespace LegoCase.Database;

public class LegoCaseContext : DbContext
{
    public DbSet<EquipmentItem> EquipmentItems { get; set; } = null!;
    public DbSet<EquipmentTrace> EquipmentTraces {get;set;} = null!;

    private string _dbPath { get; }

    public LegoCaseContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        _dbPath = Path.Join(path, "equipment.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={_dbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EquipmentTrace>()
            .HasOne(trace => trace.EquipmentItem)
            .WithMany(item => item.Traces);
    }
}
