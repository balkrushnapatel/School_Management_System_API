using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Designation { get; set; }

    public DateOnly? Doj { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<FacultySubject> FacultySubjects { get; set; } = new List<FacultySubject>();

    public virtual ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
}
