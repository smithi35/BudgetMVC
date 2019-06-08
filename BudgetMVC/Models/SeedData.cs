using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApplication.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BudgetApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BudgetApplicationContext>>()))
            {
                if (!context.BudgetItem.Any())
                {
                    context.BudgetItem.AddRange(
                        new BudgetItem
                        {
                            Title = "Books",
                            BudgettedAmount = 10
                        }
                    );
                }

                if (!context.Transaction.Any())
                {
                    context.Transaction.AddRange(
                        new Transaction
                        {
                            Memo = "Something",
                            Cost = 3.00,
                            BudgetItem = context.BudgetItem.First()
                        }
                    );
                }

                context.SaveChanges();
            }
        }
    }
}
