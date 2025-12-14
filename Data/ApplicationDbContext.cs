using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PilatesStudio.Models;

namespace PilatesStudio.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<ClassSession> ClassSessions => Set<ClassSession>();
    public DbSet<Instructor> Instructors => Set<Instructor>();
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
