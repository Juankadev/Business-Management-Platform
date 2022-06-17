<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Alta-Marca-Categoria.aspx.cs" Inherits="TPFinal_Rey_Balihaut.Alta_Marca_Categoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

    <div class="row">
        <h1>Alta de Marcas/Categorias</h1>
        <div class="col-2">

            <div class="mb-3">
                <label for="TextBox1" class="form-label">ID</label>
                <asp:TextBox ID="TextBox5" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="DropDownList1" class="form-label">Nombre</label>
                <asp:DropDownList ID="DropDownList1" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

            <p>Es una:</p>
            <asp:RadioButton ID="RadioButton1" Text="Marca" GroupName="es" runat="server" />
            <asp:RadioButton ID="RadioButton2" Text="Categoria" GroupName="es" runat="server" />
        </div>
    </div>

    <!--AGREGAR-->
    <div class="row">
        <div class="col-2">
            <asp:Button ID="altaMarcaCategoria" class="btn btn-primary btn-lg btnlogin alta" runat="server" Text="Agregar" />
        </div>
    </div>

</asp:Content>
