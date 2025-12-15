using Microsoft.AspNetCore.Mvc.RazorPages;
using PilatesStudio.Data;
using PilatesStudio.Models;

namespace PilatesStudio.Pages;

public class ClassScheduleModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public ClassScheduleModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<ClassSession> Classes { get; set; } = [];

    public void OnGet()
    {
        Classes = _context.ClassSessions.ToList();
    }
}
