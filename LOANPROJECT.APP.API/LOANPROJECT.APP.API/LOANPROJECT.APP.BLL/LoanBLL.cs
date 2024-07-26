using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOANPROJECT.APP.DAL;
using LOANPROJECT.APP.MODEL;

namespace LOANPROJECT.APP.BLL
{
    public class LoanBLL
    {
        public readonly LoanDAL LoanDAL;

        public LoanBLL()
        {
            LoanDAL = new LoanDAL();
        }
        public IEnumerable<Loan> GetCustomer()
        {
            return LoanDAL.GetCustomer();
        }
        public bool AddCustomer(Loan loan)
        {
            return LoanDAL.AddCustomer(loan);
        }

        public bool EditCustomer(Loan loan)
        {
            return LoanDAL.EditCustomer(loan);
        }
        public bool DeleteCustomer(int cust_id)
        {
            return LoanDAL.DeleteCustomer(cust_id);
        }
    }
}
