using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Registration : System.Web.UI.Page
    {
        SqlConnection myConnection = new SqlConnection("Data Source=(local);Initial Catalog=SCOEL2;User ID=sa;Password=admin@spring2020");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            myConnection.Open();

            string query = "exec registerUser @email = @em,@pass = @password";

            SqlCommand insertCommand = new SqlCommand(query, myConnection);
            insertCommand.Parameters.AddWithValue("@em", TextBox1.Text);
            insertCommand.Parameters.AddWithValue("@password", TextBox2.Text);
            insertCommand.ExecuteNonQuery();
            
            myConnection.Close();
        }
    }
}