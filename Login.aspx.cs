using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection myConnection = new SqlConnection("Data Source=(local);Initial Catalog=SCOEL2;User ID=sa;Password=admin@spring2020");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            string query = "select * from usertbl where email = @em and password = @password";
            SqlCommand insertCommand = new SqlCommand(query, myConnection);
            insertCommand.Parameters.AddWithValue("@em", TextBox1.Text);
            insertCommand.Parameters.AddWithValue("@password", TextBox2.Text);
            SqlDataReader reader = insertCommand.ExecuteReader();
            if(reader.HasRows)
            {
                Response.Redirect("Product.aspx");
            }
            else
            {
                Label3.Text = "Wrong email or password";
            }
            myConnection.Close();
        }
    }
}