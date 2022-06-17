<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="TPFinal_Rey_Balihaut.Compras1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="row">
        <h1>Ingresar Compra</h1>
        <div class="col-4">
            <div class="mb-3">
                <label for="TextBox1" class="form-label">Codigo</label>
                <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="DropDownList1" class="form-label">Proveedor</label>
                <asp:DropDownList CssClass="form-select" ID="DropDownList1" runat="server"></asp:DropDownList>
            </div>



            <div class="mb-3" style="width: 41%; display: inline-block">
                <label for="DropDownList2" class="form-label">Producto</label>
                <asp:DropDownList CssClass="form-select dropProd" ID="DropDownList2" runat="server"></asp:DropDownList>
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
