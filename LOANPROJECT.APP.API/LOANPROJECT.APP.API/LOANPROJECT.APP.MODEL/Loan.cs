using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOANPROJECT.APP.MODEL
{
    public class Loan
    {
        public int cust_id { get; set; }

        [Required(ErrorMessage = "Name Required")]
        public string cust_name { get; set; }

        [Required(ErrorMessage = "Email Required")]
        public string cust_email { get; set; }


        [Required(ErrorMessage = "Passwod Required")]
        public string password { get; set; }

    }
}
