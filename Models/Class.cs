using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public int MasterClassId { get; set; }

    public string? Section { get; set; }

    public virtual ICollection<ClassSubject> ClassSubjects { get; set; } = new List<ClassSubject>();

    public virtual ICollection<ClassWiseStudent> ClassWiseStudents { get; set; } = new List<ClassWiseStudent>();

    public virtual MasterClass MasterClass { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Timetable> Timetables { get; set; } = new List<Timetable>();
}
