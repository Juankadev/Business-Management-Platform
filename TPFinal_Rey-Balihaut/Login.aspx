<%@ Page Title="" Language="C#" MasterPageFile="/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinal_Rey_Balihaut.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="CSS/login.css" rel="stylesheet" />


    <div class="row justify-content-center" style="margin-top:70px">

        <div class="col-6" style="overflow: hidden;background-image:url(https://www.100plandenegocios.com/wp-content/uploads/2021/01/como-emprender-una-tienda-de-ropa-min-scaled.jpg);background-attachment:scroll;background-position:center;background-repeat:no-repeat;background-size:cover;">
<%--            <img style="border-radius: 10px; position: center" src="https://images.unsplash.com/photo-1567401893414-76b7b1e5a7a5?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=870&q=80" />--%>
        </div>


        <div class="col-4" style="border-radius: 10px; margin-left: -30px; background-color: rgb(27, 30, 31)">

            <h1 class="title" style="font-size:2rem;margin-bottom:15px;margin-top:10px">¡Comenzá a controlar tu Negocio!</h1>

            <div class="col-9 gradient centrar login" style="padding: 25px; border-radius: 10px">

                <div class="mb-3">
                    <h3>
                        <i style="color: #fff; margin-right: 5px" class="fa-solid fa-circle-user"></i>Iniciar Sesion
                    </h3>
                </div>

                <div class="mb-3">
                    <label for="email" class="form-label">
                        <i style="color: #fff; margin-right: 5px" class="fa-solid fa-envelope"></i>Email</label>
                    <asp:TextBox ID="email" class="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label for="pass" class="form-label">
                        <i style="color: #fff; margin-right: 5px" class="fa-solid fa-key"></i>Password</label>
                    <asp:TextBox ID="pass" type="password" class="form-control" runat="server"></asp:TextBox>
                </div>

                <asp:Button ID="login" class="btn btn-ingresar btn-lg btnlogin" runat="server" Text="Ingresar" OnClick="login_Click" />



                <a href="Login.aspx?reset=1" class="text-white" style="text-align: center; text-decoration: none; display: block; margin-top: 15px">Olvidé mi Password</a>



                <div>

                    <asp:TextBox ID="resetuser" class="form-control" runat="server" Style="display: inline-block; margin: 15px 0" placeholder="Ingresa tu Email"></asp:TextBox>

                    <asp:Button ID="resetbtn" OnClick="resetbtn_Click" class="btn btn-ingresar btn-sm btnlogin" runat="server" Text="OK" />

                    <%--                <asp:Button ID="enviado" class="btn btn-success btn-sm btnlogin" runat="server" Text="Envio exitoso" />--%>

                    <asp:Label ID="myLabel" CssClass="bg-success" runat="server" Style="border-radius: 5px; width: 100%; display: block; text-align: center; margin-top: 10px" Text="Envio exitoso" />

                </div>

            </div>


        </div>

    </div>


</asp:Content>
