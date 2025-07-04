using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public DateOnly? Dob { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public int? ClassId { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual Class? Class { get; set; }

    public virtual ICollection<ClassWiseStudent> ClassWiseStudents { get; set; } = new List<ClassWiseStudent>();
}
