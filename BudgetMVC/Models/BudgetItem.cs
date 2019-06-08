using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApplication.Models
{
    [Table("BudgetItem")]
    public class BudgetItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Currency)]
        public double BudgettedAmount { get; set; }

        [DataType(DataType.Currency)]
        public double AvailableAmount {
            get
            {
                return BudgettedAmount;
            }
        }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
