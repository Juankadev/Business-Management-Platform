﻿<%@ Page Title="" Language="C#" MasterPageFile="/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinal_Rey_Balihaut.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <h1 class="title">Controlá tu Negocio!</h1>

        <div class="col-3">

            <%--            <img src="https://d2v1hpltdjq1rf.cloudfront.net/static/account/assets/images/ic-login.png" width="500"/>--%>
            <div class="mb-3">
                <label for="TextBox1" class="form-label">Usuario</label>
                <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TextBox2" class="form-label">Password</label>
                <asp:TextBox ID="TextBox2" class="form-control" runat="server"></asp:TextBox>
            </div>

            <asp:Button ID="login" class="btn btn-primary btn-lg btnlogin" runat="server" Text="Login" />

            <a href="Login.aspx?reset=1" class="text-primary" style="text-align: center; text-decoration: none; display: block; margin-top: 15px">Olvidé mi Password</a>



            <div>

                <asp:TextBox ID="resetuser" class="form-control" runat="server" Style="display: inline-block;margin:15px 0" placeholder="Ingresa tu usuario"></asp:TextBox>

                <asp:Button ID="resetbtn" OnClick="resetbtn_Click" class="btn btn-primary btn-sm btnlogin" runat="server" Text="OK" />
            </div>

        </div>

    </div>


</asp:Content>
