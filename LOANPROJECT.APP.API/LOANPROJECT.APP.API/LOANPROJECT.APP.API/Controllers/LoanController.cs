using Microsoft.AspNetCore.Mvc;
using LOANPROJECT.APP.MODEL;
using LOANPROJECT.APP.DAL;
using LOANPROJECT.APP.BLL;

namespace LOANPROJECT.APP.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LoanController : Controller
    {

        private readonly LoanBLL loanBLL;

        public LoanController()
        {
            loanBLL = new LoanBLL();

        }
        [HttpGet("GetAllCustomer")]
        public ActionResult<Loan> getAllCustomer()
        {
            IEnumerable<Loan> customers = loanBLL.GetCustomer();
            if (customers != null && customers.Any())
            {
                return Ok(customers);
            }

            else
            {
                return NotFound("No customers Found");
            }
        }

        [HttpPost("CUSTOMER-Registration")]
        public IActionResult AddCustomer(Loan loan)
        {
            bool added = loanBLL.AddCustomer(loan);
            if (added)
            {
                return Ok("user added");
            }
            else
            {
                return NotFound("Invalid");
            }
        }

        [HttpPut("EditCustomer/{cust_id}")]
        public IActionResult EditCustomer(int cust_id, Loan loan)
        {

            loan.cust_id = cust_id;
            //if( id != student.Id)
            //{
            //    return BadRequest("Student doesnt exists");
            //}
            bool upadted = loanBLL.EditCustomer(loan);
            if (upadted)
            {
                return (Ok("Student updated"));
            }
            else
            {
                return NotFound("Student not founded");
            }
        }
        [HttpDelete("DeleteStudent/{cust_id}")]
        public IActionResult DeleteStudent(int cust_id)
        {

            bool deleted = loanBLL.DeleteCustomer(cust_id);
            if (deleted)
            {
                return (Ok("Student deleted"));
            }
            else
            {
                return NotFound("Student not founded");
            }

        }
    }
}