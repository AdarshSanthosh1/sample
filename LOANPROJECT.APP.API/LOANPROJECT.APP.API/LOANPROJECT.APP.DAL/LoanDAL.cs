using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOANPROJECT.APP.MODEL;

namespace LOANPROJECT.APP.DAL
{
    public class LoanDAL
    {
        string ConnectionString = "Server=(localdb)\\Adarsh;Database=Loan;Trusted_Connection=True";

        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(ConnectionString);
        }


        public IEnumerable<Loan> GetCustomer()
        {
            List<Loan> customers = new List<Loan>();
            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ReadCustomer";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Loan Loan = new Loan();
                    Loan.cust_id = Convert.ToInt32(reader["cust_id"]);
                    Loan.cust_name = reader["cust_name"] as string;
                    Loan.cust_email = reader["cust_email"] as string;
                    Loan.password = reader["password"] as string;


                    customers.Add(Loan);
                }
                reader.Close();
            }
            return customers;
        }
        public bool AddCustomer(Loan loan)
        {
            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PostCustomer";
                cmd.Connection = sqlConnection;

                cmd.Parameters.Add(new SqlParameter("@cust_name", SqlDbType.VarChar, 100) { Value = loan.cust_name });
                cmd.Parameters.Add(new SqlParameter("@cust_email", SqlDbType.VarChar, 100) { Value = loan.cust_email });
                cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 100) { Value = loan.password });


                sqlConnection.Open();
                int AffectedRows = cmd.ExecuteNonQuery();
                sqlConnection.Close();

                return AffectedRows > 0;
            }
        }


        public bool EditCustomer(Loan loan)
        {
            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UpdateCustomer";
                command.Connection = sqlConnection;

                command.Parameters.Add(new SqlParameter("@cust_id", SqlDbType.Int) { Value = loan.cust_id });
                command.Parameters.Add(new SqlParameter("@cust_name", SqlDbType.VarChar, 100) { Value = loan.cust_name });
                command.Parameters.Add(new SqlParameter("@cust_email", SqlDbType.VarChar, 100) { Value = loan.cust_email });
                command.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 100) { Value = loan.password });


                sqlConnection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                sqlConnection.Close();

                return rowsAffected > 0;
            }
        }

        public bool DeleteCustomer(int cust_id)
        {
            using (SqlConnection sqlConnection = GetSqlConnection())
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeleteCustomer";
                command.Connection = sqlConnection;

                command.Parameters.Add(new SqlParameter("@cust_id", SqlDbType.Int) { Value = cust_id });

                sqlConnection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                sqlConnection.Close();

                return rowsAffected > 0;
            }
        }


    }
}
