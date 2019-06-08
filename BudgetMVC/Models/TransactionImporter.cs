using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApplication.Models
{
    public class TransactionImporter
    {
        private string filename;
        private readonly BudgetApplicationContext _context;

        public TransactionImporter(string filename)
        {
            this.filename = filename;
        }

        public void ImportTransactions()
        {
            string [] lines = System.IO.File.ReadAllLines(this.filename);

            foreach (string line in lines)
            {
                bool isValid = isValidTransaction();

                if (isValid)
                {
                    Transaction currentTransaction = new Transaction
                    {
                        Memo = "",
                        Cost = 0.0
                    };

                    _context.Add(currentTransaction);
                }
            }
        }

        private bool isValidTransaction()
        {
            return false;
        }
    }
}
