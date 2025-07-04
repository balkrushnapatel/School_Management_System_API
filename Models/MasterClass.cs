using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class MasterClass
{
    public int MasterClassId { get; set; }

    public string ClassName { get; set; } = null!;

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
