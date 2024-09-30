﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RepositoryLearn.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace RepositoryLearn.Models
{
    public partial interface IContosoUniversityContextProcedures
    {
        Task<int> Department_DeleteAsync(int? DepartmentID, byte[] RowVersion_Original, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<Department_InsertResult>> Department_InsertAsync(string Name, decimal? Budget, DateTime? StartDate, int? InstructorID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<Department_UpdateResult>> Department_UpdateAsync(int? DepartmentID, string Name, decimal? Budget, DateTime? StartDate, int? InstructorID, byte[] RowVersion_Original, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
