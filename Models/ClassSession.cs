using System.ComponentModel.DataAnnotations;

namespace PilatesStudio.Models;
public class ClassSession
{
    public int Id { get; set; }
    [Required]
    public ClassType Name { get; set; }
    public string Instructor { get; set; } = "";
    public DateTime StartTime { get; set; }
    public int Capacity { get; set; }
    public int EnrolledCount { get; set; }
    public bool IsFull => EnrolledCount >= Capacity;
    public bool IsCompleted => StartTime < DateTime.Now;
}

public enum ClassType
{
    Classic,
    Reformer,
    ExpressAbs
}