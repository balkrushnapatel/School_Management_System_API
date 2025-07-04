using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class FacultySubject
{
    public int FacultySubjectId { get; set; }

    public int? StaffId { get; set; }

    public int? SubjectId { get; set; }

    public virtual Staff? Staff { get; set; }

    public virtual Subject? Subject { get; set; }
}
