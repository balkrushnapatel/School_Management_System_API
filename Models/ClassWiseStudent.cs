using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class ClassWiseStudent
{
    public int ClassWiseStudentId { get; set; }

    public int? ClassId { get; set; }

    public int? StudentId { get; set; }

    public virtual Class? Class { get; set; }

    public virtual Student? Student { get; set; }
}
