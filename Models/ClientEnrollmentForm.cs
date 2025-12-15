using System.ComponentModel.DataAnnotations;

namespace PilatesStudio.Models;
public class ClientEnrollmentForm
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; } = "";
    [Required]
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public DateTime DateOfBirth { get; set; }
    public DateTime EnrollmentDate { get; set; } = DateTime.Now;
    public bool FoundersMembership { get; set; } = false;
}
