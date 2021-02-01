using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLibrary_Website
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals(""))
                {
                    userLoginBtn.Visible = true; // user login link button
                    signupBtn.Visible = true; // sign up link button

                    logoutBtn.Visible = false; // logout link button
                    LinkButton7.Visible = false; // hello user link button


                    adminLoginBtn.Visible = true; // admin login link button
                    authorMangBtn.Visible = false; // author management link button
                    pubMangBtn.Visible = false; // publisher management link button
                    bookInvBtn.Visible = false; // book inventory link button
                    bookIssueBtn.Visible = false; // book issuing link button
                    memberMangBtn.Visible = false; // member management link button

                }
                else if (Session["role"].Equals("user"))
                {
                    userLoginBtn.Visible = false; // user login link button
                    signupBtn.Visible = false; // sign up link button

                    logoutBtn.Visible = true; // logout link button
                    LinkButton7.Visible = true; // hello user link button
                    LinkButton7.Text = "Hello " + Session["username"].ToString();


                    adminLoginBtn.Visible = true; // admin login link button
                    authorMangBtn.Visible = false; // author management link button
                    pubMangBtn.Visible = false; // publisher management link button
                    bookInvBtn.Visible = false; // book inventory link button
                    bookIssueBtn.Visible = false; // book issuing link button
                    memberMangBtn.Visible = false; // member management link button
                }
                else if (Session["role"].Equals("admin"))
                {
                    userLoginBtn.Visible = false; // user login link button
                    signupBtn.Visible = false; // sign up link button

                    logoutBtn.Visible = true; // logout link button
                    LinkButton7.Visible = true; // hello user link button
                    LinkButton7.Text = "Hello Admin";


                    adminLoginBtn.Visible = false; // admin login link button
                    authorMangBtn.Visible = true; // author management link button
                    pubMangBtn.Visible = true; // publisher management link button
                    bookInvBtn.Visible = true; // book inventory link button
                    bookIssueBtn.Visible = true; // book issuing link button
                    memberMangBtn.Visible = true; // member management link button
                }
            }
            catch (Exception ex)
            {

            }
        }

       
        protected void viewBooksBtn_Click(object sender, EventArgs e)
        {
                Response.Redirect("viewBooks.aspx");
        }

        protected void userLoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("userLogin.aspx");
        }

        protected void signupBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("userSignup.aspx");
        }

        protected void adminLoginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminLogin.aspx");
        }


        protected void authorMangBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("authorManagement.aspx");
        }

        protected void pubMangBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("publisherManagement.aspx");
        }

        protected void bookInvBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("bookManagement.aspx");
        }

        protected void bookIssueBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("issueBook.aspx");
        }

        protected void memberMangBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("memberManagement.aspx");
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";

            userLoginBtn.Visible = true; // user login link button
            signupBtn.Visible = true; // sign up link button

            logoutBtn.Visible = false; // logout link button
            LinkButton7.Visible = false; // hello user link button


            adminLoginBtn.Visible = true; // admin login link button
            authorMangBtn.Visible = false; // author management link button
            pubMangBtn.Visible = false; // publisher management link button
            bookInvBtn.Visible = false; // book inventory link button
            bookIssueBtn.Visible = false; // book issuing link button
            memberMangBtn.Visible = false; // member management link button

            Response.Redirect("homepage.aspx");
        }
    }
}