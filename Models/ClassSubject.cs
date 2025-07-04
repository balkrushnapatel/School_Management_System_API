using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class ClassSubject
{
    public int ClassSubjectId { get; set; }

    public int ClassId { get; set; }

    public int SubjectId { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual Subject Subject { get; set; } = null!;
}
