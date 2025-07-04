using System;
using System.Collections.Generic;

namespace SchoolManagement.Models;

public partial class Trust
{
    public int TrustId { get; set; }

    public string TrustName { get; set; } = null!;

    public string TrusteeName { get; set; } = null!;
}
