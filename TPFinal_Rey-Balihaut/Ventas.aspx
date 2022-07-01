<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="TPFinal_Rey_Balihaut.Ventas2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="row">
        <h1>Ventas</h1>
        <div class="col-4">
<%--            <div class="mb-3">
                <label for="codigo" class="form-label">Codigo</label>
                <asp:TextBox ID="codigo" class="form-control" runat="server"></asp:TextBox>
            </div>--%>

            <div class="mb-3">
                <label for="ddlclientes" class="form-label">Cliente</label>
                <asp:DropDownList CssClass="form-select" ID="ddlclientes" runat="server"></asp:DropDownList>
            </div>



            <div class="mb-3" style="width: 41%; display: inline-block">
                <label for="ddlproductos" class="form-label">Producto</label>
                <asp:DropDownList CssClass="form-select dropProd" ID="ddlproductos" runat="server"></asp:DropDownList>
            </div>

            <div class="mb-3" style="width: 30%; display: inline-block">
                <label for="TextBox3" class="form-label">Cantidad</label>
                <asp:TextBox ID="TextBox3" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3" style="width: 26%; display: inline-block">
                <label for="TextBox4" class="form-label">Precio Unit.</label>
                <asp:TextBox ID="TextBox4" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>






    </div>





    <!--AGREGAR-->
    <div class="row">
        <div class="col-4">
            <asp:Button ID="altaArticulo" class="btn btn-primary btn-lg btnlogin" runat="server" Text="Agregar" />
        </div>
    </div>
</asp:Content>
