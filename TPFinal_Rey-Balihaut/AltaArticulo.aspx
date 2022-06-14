<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AltaArticulo.aspx.cs" Inherits="TPFinal_Rey_Balihaut.Compras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="row">
        <h1>Alta de Articulos</h1>
        <div class="col-2">

            <div class="mb-3">
                <label for="TextBox1" class="form-label">Codigo</label>
                <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TextBox2" class="form-label">Nombre</label>
                <asp:TextBox ID="TextBox2" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TextBox3" class="form-label">Porcentaje de Ganancia</label>
                <asp:TextBox ID="TextBox3" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TextBox4" class="form-label">Precio</label>
                <asp:TextBox ID="TextBox4" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="DropDownList1" class="form-label">Marca</label>
                <asp:DropDownList ID="DropDownList4" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

        </div>

        <div class="col-2">

            <div class="mb-3">
                <label for="DropDownList2" class="form-label">Categoria</label>
                <asp:DropDownList ID="DropDownList5" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <label for="DropDownList3" class="form-label">Proveedor</label>
                <asp:DropDownList ID="DropDownList6" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <label for="TextBox5" class="form-label">Stock Actual</label>
                <asp:TextBox ID="TextBox11" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">

                <label for="TextBox6" class="form-label">Stock Minimo</label>
                <asp:TextBox ID="TextBox12" class="form-control" runat="server"></asp:TextBox>
            </div>

        </div>
    </div>

    <!--AGREGAR-->
    <div class="row">
        <div class="col-2">
            <asp:Button ID="altaArticulo" class="btn btn-primary btn-lg btnlogin" runat="server" Text="Agregar" />
        </div>
    </div>




</asp:Content>
