<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AltaArticulos.aspx.cs" Inherits="TPFinal_Rey_Balihaut.Altas1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <h1>Alta de Articulos</h1>
        <%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
        <div class="col-2">

            <div class="mb-3">
                <label for="codigo" class="form-label">Codigo</label>
                <asp:TextBox ID="codigo" maxlength="10" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="nombre" class="form-label">Nombre</label>
                <asp:TextBox ID="nombre" maxlength="50" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="ganancia" class="form-label">Porcentaje de Ganancia</label>
                <asp:TextBox ID="ganancia" type="number" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="precio" class="form-label">Precio</label>
                <asp:TextBox ID="precio" type="number" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="ddlmarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlmarca" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

        </div>

        <div class="col-2">

            <div class="mb-3">
                <label for="ddlcategoria" class="form-label">Categoria</label>
                <asp:DropDownList ID="ddlcategoria" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <label for="ddlproveedor" class="form-label">Proveedor</label>
                <asp:DropDownList ID="ddlproveedor" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <label for="stockactual" class="form-label">Stock Actual</label>
                <asp:TextBox ID="stockactual" type="number" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">

                <label for="stockminimo" class="form-label">Stock Minimo</label>
                <asp:TextBox ID="stockminimo" type="number" class="form-control" runat="server"></asp:TextBox>
            </div>

        </div>
    </div>

    <!--AGREGAR-->
    <div class="row">
        <div class="col-2">
            <asp:Button ID="altaArticulo" OnCLick="altaArticulo_Click" class="btn btn-primary btn-lg btnlogin" runat="server" Text="Agregar" />
        </div>
    </div>
</asp:Content>
