using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LeaveCalculation
{
    public partial class CalculateLeave : Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBconn"].ConnectionString;
            conn = new SqlConnection(connectionString);
            conn.Open();

            if (!IsPostBack)
            {
                Label2.Text = Session["EmployeeName"].ToString();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string empEmail = Session["EmployeeEmail"].ToString();
            string reason = TextBox5.Text; 
    
           // DateTime joiningDate = DateTime.ParseExact(TextBox2.Text, "yyyy-MM-dd", null);
           DateTime joiningDate = DateTime.ParseExact(Session["DateOfJoining"].ToString(), "yyyy-MM-dd", null);
            DateTime fromDate = DateTime.ParseExact(TextBox3.Text, "yyyy-MM-dd", null);
            DateTime toDate = DateTime.ParseExact(TextBox4.Text, "yyyy-MM-dd", null);
            decimal monthlySalary = decimal.Parse(TextBox1.Text);

            // Constants
            int maxLeavesPerMonth = 2;
            decimal dailySalary = monthlySalary / 22; // Assuming 22 working days in a month

            // Calculate number of weekdays between FROM and TO dates
            int weekdaysCount = CountWeekdays(fromDate, toDate);

            // Calculate total leaves available from joining date
            DateTime today = DateTime.Today;
            int monthsWorked = ((today.Year - joiningDate.Year) * 12) + today.Month - joiningDate.Month;
            int totalLeavesAvailable = monthsWorked * maxLeavesPerMonth;

            // Calculate the number of months in the given date range
            int monthsInRange = ((toDate.Year - fromDate.Year) * 12) + toDate.Month - fromDate.Month + 1;

            // Leave calculations for this period
            int allowedLeavesThisPeriod = monthsInRange * maxLeavesPerMonth;
            int extraLeaves = weekdaysCount > allowedLeavesThisPeriod ? weekdaysCount - allowedLeavesThisPeriod : 0;
            decimal salaryDeduction = extraLeaves * dailySalary;
            decimal finalSalary = monthlySalary - salaryDeduction;


            Label1.Text = $"Total Leaves Available: {totalLeavesAvailable} Final Salary: {finalSalary:N2}  Deducted Salary: {salaryDeduction:N2}  allowed Leaves: {allowedLeavesThisPeriod} Extra Leaves {extraLeaves}";


            // add Code to insert Reason and extraLeaves leaves 
            int additionalLeaves = extraLeaves; 
            string sql = "UPDATE emp SET reason = @reason, AdditionalLeaves = @additionalLeaves WHERE email = @empEmail";
            // Create a SqlCommand object
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                // Add parameters to the SqlCommand
                cmd.Parameters.AddWithValue("@reason", reason);
                cmd.Parameters.AddWithValue("@additionalLeaves", additionalLeaves);
                cmd.Parameters.AddWithValue("@empEmail", empEmail);

                // Execute the command
                int rowsAffected = cmd.ExecuteNonQuery();

                // Check if the update was successful
                if (rowsAffected > 0)
                {
                    Response.Write("<script>alert('Reason and additional leaves updated successfully');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Failed to update reason and additional leaves');</script>");
                }
            }





        }

        static int CountWeekdays(DateTime from, DateTime to)
        {
            int count = 0;
            for (DateTime date = from; date <= to; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
