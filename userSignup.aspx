<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="userSignup.aspx.cs" Inherits="eLibrary_Website.userSignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
      <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="images/girl.png"/>
                        </center>
                     </div>
                  </div>
                    <div class="col">
                        <center>
                           <h3>Member Sign Up</h3>
                        </center>
                     </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Full Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="fullName" runat="server" placeholder="Full Name"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Date of Birth</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="birthdate" runat="server" placeholder="Date of Birth" TextMode="Date"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Phone number</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="phoneNum" runat="server" placeholder="Contact No" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Email Address</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="email" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                    <div class="row">
                     <div class="col-md-4">
                        <label>Username</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="username" runat="server" placeholder="Username"></asp:TextBox>
                        </div>
                     </div>
                       <div class="col-md-4">
                        <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox TextMode="Password" class="form-control" ID="password" runat="server" placeholder="Password"></asp:TextBox>
                        </div>
                     </div>
                         <div class="col-md-4">
                        <label>Password Confirmation</label>
                        <div class="form-group">
                           <asp:TextBox TextMode="Password" class="form-control" ID="passwordConf" runat="server" placeholder="Password Confirmation"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>City</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="city" runat="server" placeholder="City"></asp:TextBox>
                        </div>
                     </div>
                       <div class="col-md-6">
                        <label>State</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="state" runat="server" placeholder="State"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <label>Full Address</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="address" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                 <div class="row">
                     <div class="col-8 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="signupBtn" runat="server" Text="Sign Up" OnClick="signupBtn_Click1" />
                           </div>
                        </center>
                     </div>
                  </div>
               </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br><br>
         </div>
      </div>
   </div>
</asp:Content>
