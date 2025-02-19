
using Config;
using Microsoft.EntityFrameworkCore;

namespace DbFirst.Models;

public partial class SchoolContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(AppConfig.ConnectionString);
    }
}
