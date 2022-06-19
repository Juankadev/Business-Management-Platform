<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Alta-Marca-Categoria.aspx.cs" Inherits="TPFinal_Rey_Balihaut.Alta_Marca_Categoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

    <div class="row">
        <h1>Alta de Marcas/Categorias</h1>
        <div class="col-2">

            <div class="mb-3">
                <label for="nombre" class="form-label">Nombre</label>
                <asp:TextBox ID="nombre" class="form-control" runat="server"></asp:TextBox>
            </div>

            <p>Es una:</p>
            <asp:RadioButton ID="rdbmarca" Text="Marca" GroupName="es" runat="server" />
            <asp:RadioButton ID="rdbcategoria" Text="Categoria" GroupName="es" runat="server" />
            
            <asp:Label ID="ninguno" runat="server" Text="Selecciona el tipo"></asp:Label>
        </div>
    </div>

    <!--AGREGAR-->
    <div class="row">
        <div class="col-2">
            <asp:Button ID="altaMarcaCategoria" OnClick="altaMarcaCategoria_Click" class="btn btn-primary btn-lg btnlogin alta" runat="server" Text="Agregar" />
        </div>
    </div>

</asp:Content>
