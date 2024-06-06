using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace LeaveCalculation
{
    public partial class Employee : Page
    {
        SqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBconn"].ConnectionString;
            conn = new SqlConnection(connectionString);
            conn.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string employeeName = TextBox1.Text;
            string employeeEmail = TextBox2.Text;
            string employeeContact = TextBox3.Text;
            string dateOfJoining = DateTime.Parse(TextBox4.Text).ToString("yyyy-MM-dd");

            // Prepare the SQL INSERT command
            string sql = "INSERT INTO emp ( email, contact, doj) VALUES (@email, @contact, @doj)";
            Session["EmployeeName"] = employeeName;
            Session["EmployeeEmail"] = employeeEmail;
            Session["EmployeeContact"] = employeeContact;
            Session["DateOfJoining"] = dateOfJoining;
            // Create a SqlCommand object
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                // Add parameters to the SqlCommand
             
                cmd.Parameters.AddWithValue("@email", employeeEmail);
                cmd.Parameters.AddWithValue("@contact", employeeContact);
                cmd.Parameters.AddWithValue("@doj", dateOfJoining);

                // Execute the command
                int rowsAffected = cmd.ExecuteNonQuery();

                // Check if the insertion was successful
                if (rowsAffected > 0)
                {
                  //  Response.Write($"Employee {employeeName} added successfully with Email: {employeeEmail}, Contact: {employeeContact}, and Date of Joining: {dateOfJoining:yyyy-MM-dd}");
                    // Redirect to another page after successful insertion
                    Response.Redirect("CalculateLeave.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Failed to insert employee details');</script>");
                }
            }
        }
    }
}
