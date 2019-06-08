using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BudgetApplication.Models
{
    public class BudgetApplicationContext : DbContext
    {
        public BudgetApplicationContext (DbContextOptions<BudgetApplicationContext> options)
            : base(options)
        {

        }

        public DbSet<BudgetApplication.Models.BudgetItem> BudgetItem { get; set; }
        public DbSet<BudgetApplication.Models.Transaction> Transaction { get; set; }
    }
}
