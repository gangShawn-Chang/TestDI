﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace RepositoryLearn.Models;

public partial class OfficeAssignment
{
    public int InstructorId { get; set; }

    public string Location { get; set; }

    public virtual Person Instructor { get; set; }
}