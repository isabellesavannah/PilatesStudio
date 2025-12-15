using System.ComponentModel.DataAnnotations;

namespace PilatesStudio.Models;
public class Instructor
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public DateTime HireDate { get; set; }
    public DateTime BirthDate { get; set; }
    public decimal HourlyRate { get; set; }
    public List<ClassSession> ClassSessions { get; set; } = new List<ClassSession>();
    public List<ClientEnrollmentForm> Referrals { get; set; } = new List<ClientEnrollmentForm>();
}
