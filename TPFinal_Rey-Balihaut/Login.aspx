<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinal_Rey_Balihaut.Compras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <h1>Ingresá a tu Negocio!</h1>

        <div class="col-2">

<%--            <img src="https://d2v1hpltdjq1rf.cloudfront.net/static/account/assets/images/ic-login.png" width="500"/>--%>
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Usuario</label>
                <input type="text" class="form-control" id="exampleFormControlInput1" placeholder="name@example.com">
            </div>

            <div class="mb-3 row">
                <label for="inputPassword" class="form-label">Password</label>
                <input type="password" class="form-control" id="inputPassword" placeholder="********">
            </div>

            <asp:Button ID="login" class="btn btn-primary btn-lg btnlogin" runat="server" Text="Login" />

        </div>
    </div>

</asp:Content>
