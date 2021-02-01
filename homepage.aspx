<%@ Page Title="Homepage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="eLibrary_Website.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!--homepage background section -->
	 <section>
      <img src="images/home.jpg" class="img-fluid"/>
   </section>
    <section>
      <div class="container">
         <div class="row">
            <div class="col-12">
               <center>
                  <h2>Our Features</h2>
                </center>
            </div>
         </div>
         <div class="row">
            <div class="col-md-4">
               <center>
                  <img width="150px" src="images/studying.png"/>
                  <h4>Digital Book Inventory</h4>
                  <p class="text-justify">editable library catalog, building towards a web page for every book ever published.</p>
               </center>
            </div>
            <div class="col-md-4">
               <center>
                  <img width="150px" src="images/reading.png"/>
                  <h4>Search Books</h4>
                  <p class="text-justify">Search the book you want from a huge collection of books</p>
               </center>
            </div>
            <div class="col-md-4">
               <center>
                  <img width="150px" src="images/laptop.png"/>
                  <h4>Issue Book</h4>
                  <p class="text-justify">Borrow and read free ebooks, and magazines from your library using your computer, phone or tablet.</p>
               </center>
            </div>
         </div>
      </div>
   </section>
   
</asp:Content>
