using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string? SubjectName { get; set; }

    public virtual ICollection<ClassSubject> ClassSubjects { get; set; } = new List<ClassSubject>();

    public virtual ICollection<FacultySubject> FacultySubjects { get; set; } = new List<FacultySubject>();

    public virtual ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
}
