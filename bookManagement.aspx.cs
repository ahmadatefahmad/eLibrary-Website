using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLibrary_Website
{
    public partial class bookManagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
               fillAuthorPublisherValues();
           
            
            GridView1.DataBind();
        }
        //add button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                Response.Write("<script>alert('Book Already Exists');</script>");
            }
            else
            {
                addNewBook();
            }
        }
        //delete button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                deleteBook();
            }
            else
            {
                Response.Write("<script>alert('Book doesn't exist');</script>");
            }
        }
        
        void addNewBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_table" +
                    "(book_name,genre,author_name,publisher_name,publish_date,language,edition,book_cost,pages_num,book_description,stock,available) values" +
                    "(@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock)", con);

                cmd.Parameters.AddWithValue("@book_name", book_name.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genre.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", publish_date.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", edition.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", book_cost.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", no_of_pages.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", book_description.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", stock.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", stock.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book added successfully.');</script>");
                clearFields();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void deleteBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from book_table WHERE book_name='" + book_name.Text.Trim() + "' AND edition='" + edition.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('book Deleted Successfully');</script>");
                clearFields();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void fillAuthorPublisherValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT name from author_table;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "name";
                DropDownList3.DataBind();

                cmd = new SqlCommand("SELECT name from publisher_table;", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();   
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "name";
                DropDownList2.DataBind();

            }
            catch (Exception ex)
            {

            }
        }

        bool checkIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from book_table where book_name='" + book_name.Text.Trim() + "' AND edition='" + edition.Text.Trim() + "'", con);
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

        void clearFields()
        {
            book_name.Text = "";
            publish_date.Text = "";
            edition.Text = "";
            book_cost.Text = "";
            no_of_pages.Text = "";
            stock.Text = "";
            book_description.Text = "";
        }
    }
}