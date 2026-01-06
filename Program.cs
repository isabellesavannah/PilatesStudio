using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PilatesStudio.Data;
using PilatesStudio.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using PilatesStudio.Services;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------
// Configure Services
// ---------------------------

// SQL Server connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

// Razor Pages with runtime compilation (helps with UI changes)
builder.Services.AddRazorPages();

// Email service (SendGrid)
builder.Services.AddTransient<IEmailSender, SendGridEmailSender>();

// Developer exception page / DB exceptions
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// ---------------------------
// Configure Middleware Pipeline
// ---------------------------

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Important middleware order
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    if (!db.ClassSessions.Any())
    {
        db.ClassSessions.Add(new ClassSession
        {
            Name = ClassType.Classic,
            Instructor = "Isabelle",
            StartTime = DateTime.Now.AddDays(1),
            Capacity = 10,
            EnrolledCount = 8,

        });

        db.SaveChanges();
    }
}

app.Run();
