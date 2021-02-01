using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;

namespace eLibrary_Website
{
    public class test
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void homepageTest()
        {
            driver.Url = "https://localhost:44313/homepage.aspx";
            Assert.AreEqual("Homepage", driver.Title);
        }

        [Test]
        public void Wrong_Admin_Credtentials()
        {
            driver.Url = "https://localhost:44313/adminLogin.aspx";
            Assert.AreEqual("Admin Login", driver.Title);

            driver.FindElement(By.Id("ContentPlaceHolder1_TextBox1"))
            .SendKeys("WrongName");

            driver.FindElement(By.Id("ContentPlaceHolder1_TextBox2"))
                .SendKeys("WrongPassword");

            driver.FindElement(By.Id("ContentPlaceHolder1_Button1"))
                .Click();

            IAlert alert = driver.SwitchTo().Alert();
            string errMsg = alert.Text;
            if (errMsg.Equals("Invalid credentials"))
            {
                alert.Dismiss();
            }
        }

        [Test]
        public void Wrong_User_Credtentials()
        {
            driver.Url = "https://localhost:44313/userLogin.aspx";
            Assert.AreEqual("User Login", driver.Title);

            driver.FindElement(By.Id("ContentPlaceHolder1_TextBox1"))
            .SendKeys("WrongName");

            driver.FindElement(By.Id("ContentPlaceHolder1_TextBox2"))
                .SendKeys("WrongPassword");

            driver.FindElement(By.Id("ContentPlaceHolder1_Button1"))
                .Click();

            IAlert alert = driver.SwitchTo().Alert();
            string errMsg = alert.Text;
            if (errMsg.Equals("Invalid credentials"))
            {
                alert.Dismiss();
            }
        }


        [Test]
        public void NonExisting_Author_Delete()
        {
            driver.Url = "https://localhost:44313/authorManagement.aspx";
            Assert.AreEqual("Author Management", driver.Title);

            driver.FindElement(By.Id("ContentPlaceHolder1_TextBox2"))
            .SendKeys("WrongName");

            bool nameExist = false;

            IWebElement tableElement = driver.FindElement(By.Id("ContentPlaceHolder1_GridView1"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
            foreach (IWebElement row in tableRow)
            {
                if (row.Text.Equals("WrongName"))
                {
                    nameExist = true;
                }
            }
            if (!nameExist)
            {
                driver.FindElement(By.Id("ContentPlaceHolder1_Button4")).Click();

                IAlert alert = driver.SwitchTo().Alert();
                string errMsg = alert.Text;
                if (errMsg.Equals("Author does not exist"))
                {
                    alert.Dismiss();
                }
            }
        }

        [Test]
        public void Duplicate_Author_Addition()
        {
            driver.Url = "https://localhost:44313/authorManagement.aspx";
            Assert.AreEqual("Author Management", driver.Title);


            driver.FindElement(By.Id("ContentPlaceHolder1_TextBox2"))
            .SendKeys("WrongName");

            String authorName = null;

            IWebElement tableElement = driver.FindElement(By.Id("ContentPlaceHolder1_GridView1"));
            IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
            
            foreach (IWebElement row in tableRow)
            {
                if (row.Text != null)
                {
                    authorName = row.Text;
                    break;
                }

            }
            if (authorName != null)
            {
                driver.FindElement(By.Id("ContentPlaceHolder1_TextBox2")).SendKeys(authorName);
                driver.FindElement(By.Id("ContentPlaceHolder1_Button2")).Click();
                IAlert alert = driver.SwitchTo().Alert();
                string errMsg = alert.Text;
                if (errMsg.Equals("Author with this Name already Exist."))
                {
                    alert.Dismiss();
                }
            }
           
        }

        [Test]
        public void Duplicate_Book_Addition()
        {
            driver.Url = "https://localhost:44313/bookManagement.aspx";
            Assert.AreEqual("Book Management", driver.Title);

            String bookName = driver.FindElement(By.Id("ContentPlaceHolder1_GridView1_Label1_0")).Text;
            String bookEdition = driver.FindElement(By.Id("ContentPlaceHolder1_GridView1_Label8_0")).Text;

            if(bookName != null && bookEdition != null)
            {
                driver.FindElement(By.Id("ContentPlaceHolder1_book_name"))
                .SendKeys(bookName);
                driver.FindElement(By.Id("ContentPlaceHolder1_edition"))
                .SendKeys(bookEdition);


                driver.FindElement(By.Id("ContentPlaceHolder1_Button1")).Click();
                IAlert alert = driver.SwitchTo().Alert();
                string errMsg = alert.Text;
                if (errMsg.Equals("Book Already Exists"))
                {
                    alert.Dismiss();
                }
            }
           
        }

        [Test]
        public void Duplicate_Book_Issuance()
        {
            driver.Url = "https://localhost:44313/issueBook.aspx";

            Assert.AreEqual("Issue Book", driver.Title);

            String bookID = null;
            String memberID = null;
            IWebElement issuanceTable = driver.FindElement(By.Id("ContentPlaceHolder1_GridView1"));
            IList<IWebElement> tableRow = issuanceTable.FindElements(By.TagName("tr"));
            
            var td = tableRow[1].FindElements(By.TagName("td"));
            if (!td[0].Text.Equals(""))
            {
                bookID = td[0].Text;
                memberID = td[2].Text;
            }

            driver.FindElement(By.Id("ContentPlaceHolder1_TextBox2"))
            .SendKeys(memberID);
            driver.FindElement(By.Id("ContentPlaceHolder1_TextBox1"))
            .SendKeys(bookID);


            driver.FindElement(By.Id("ContentPlaceHolder1_Button2")).Click();
            IAlert alert = driver.SwitchTo().Alert();
            string errMsg = alert.Text;
            if (errMsg.Equals("This Member already has this book"))
            {
                alert.Dismiss();
            }

        }


        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}

