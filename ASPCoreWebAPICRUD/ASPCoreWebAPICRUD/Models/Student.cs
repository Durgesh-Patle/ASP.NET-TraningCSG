using System;
using System.Collections.Generic;

namespace ASPCoreWebAPICRUD.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Gender { get; set; }

    public string? PhoneNumber { get; set; }
}
