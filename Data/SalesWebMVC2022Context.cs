using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC2022.Models;

namespace SalesWebMVC2022.Data
{
    public class SalesWebMVC2022Context : DbContext
    {
        public SalesWebMVC2022Context (DbContextOptions<SalesWebMVC2022Context> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; } = default!;
    }
}
