using System.ComponentModel.DataAnnotations;

namespace PilatesStudio.Models;
public class Instructor
{
    public int Id { get; set; }
    [Required]
    public ClassType Name { get; set; }
    public List<ClassSession> ClassSessions { get; set; } = new List<ClassSession>();
}
