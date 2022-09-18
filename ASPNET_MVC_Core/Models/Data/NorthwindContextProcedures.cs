﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using ASPNET_MVC_Core.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ASPNET_MVC_Core.Models.Data
{
    public partial class NorthwindContext
    {
        private INorthwindContextProcedures _procedures;

        public virtual INorthwindContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new NorthwindContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public INorthwindContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TenMostExpensiveProductsResult>().HasNoKey().ToView(null);
        }
    }

    public partial class NorthwindContextProcedures : INorthwindContextProcedures
    {
        private readonly NorthwindContext _context;

        public NorthwindContextProcedures(NorthwindContext context)
        {
            _context = context;
        }

        public virtual async Task<List<TenMostExpensiveProductsResult>> TenMostExpensiveProductsAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<TenMostExpensiveProductsResult>("EXEC @returnValue = [dbo].[Ten Most Expensive Products]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
