using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class Timetable
{
    public int TimetableId { get; set; }

    public int? ClassId { get; set; }

    public int? SubjectId { get; set; }

    public int? StaffId { get; set; }

    public string? DayOfWeek { get; set; }

    public string? Period { get; set; }

    public virtual Class? Class { get; set; }

    public virtual Staff? Staff { get; set; }

    public virtual Subject? Subject { get; set; }
}
