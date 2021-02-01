using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLibrary_Website
{
    public partial class userSignup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            /* 
             string connetionString;
             SqlConnection cnn;

             connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=eLibraryDB;Integrated Security=true";

             cnn = new SqlConnection(connetionString);

             cnn.Open();

             Response.Write("Connection MAde");
             cnn.Close();
             */
        }

        // sign up button click event
        protected void signupBtn_Click1(object sender, EventArgs e)
        {

                if (checkMemberExists())
                {

                    Response.Write("<script>alert('Member Already Exist with this Member ID, try other ID');</script>");
                }
                else
                {
                    signUpNewMember();
                }
        }
        // user defined method
        bool checkMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from member_table where username='" + username.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        void signUpNewMember()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                    SqlCommand cmd = new SqlCommand("INSERT INTO member_table(name,birthdate,phoneNum,email,username,password,passwordConf,state,city,address) values(@full_name,@dob,@contact_no,@email,@username,@pw,@pwConf,@state,@city,@address)", con);
                    cmd.Parameters.AddWithValue("@full_name", fullName.Text);
                    cmd.Parameters.AddWithValue("@dob", birthdate.Text);
                    cmd.Parameters.AddWithValue("@contact_no", phoneNum.Text);
                    cmd.Parameters.AddWithValue("@email", email.Text);
                    cmd.Parameters.AddWithValue("@state", state.Text.Trim());
                    cmd.Parameters.AddWithValue("@city", city.Text.Trim());
                    cmd.Parameters.AddWithValue("@username", username.Text.Trim());
                    cmd.Parameters.AddWithValue("@address", address.Text.Trim());
                    cmd.Parameters.AddWithValue("@pw", password.Text.Trim());
                    cmd.Parameters.AddWithValue("@pwConf", passwordConf.Text.Trim());
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch(SqlException ex)
                    {
                        address.Text = ex.Message;
                    }
                    con.Close();
                    Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Please, Fill in your information');</script>");

            }
        }
    }
}