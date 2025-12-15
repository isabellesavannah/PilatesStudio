using System.ComponentModel.DataAnnotations;

namespace PilatesStudio.Models;

public class Client
{
    public int Id { get; set; }
    [Required]
    public bool MembershipIsActive { get; set; }
    public BillingDateOption BillingDate { get; set; }
    public int ClassesAvailable { get; set; }
    public int TotalSessionsAttended { get; set; }
    public List<ClassSession> EnrolledClasses { get; set; } = new List<ClassSession>();
    public ClientEnrollmentForm ClientInfo { get; set; } = new ClientEnrollmentForm();
    
    public enum BillingDateOption
    {
        FirstOfMonth,
        MidMonth
    }
}
