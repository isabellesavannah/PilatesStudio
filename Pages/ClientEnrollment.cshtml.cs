using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PilatesStudio.Data;
using PilatesStudio.Models;

namespace PilatesStudio.Pages
{
    public class ClientEnrollmentModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ClientEnrollmentModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ClientEnrollmentForm ClientForm { get; set; } = new();

        public void OnGet(string email)
        {
            // Pre-fill the email from registration
            ClientForm.Email = email;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Save to database
            _context.ClientEnrollmentForms.Add(ClientForm);
            _context.SaveChanges();

            // Redirect to thank you page or dashboard
            return RedirectToPage("/Index");
        }
    }
}
