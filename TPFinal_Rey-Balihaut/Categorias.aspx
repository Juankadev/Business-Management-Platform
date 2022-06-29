<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="TPFinal_Rey_Balihaut.Alta_Marca_Categoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="row">
        <h1>Categorias</h1>
        <div class="col-2">

            <div class="mb-3">
                <label for="nombre" class="form-label">Nombre</label>
                <asp:TextBox ID="nombre" MaxLength="200" class="form-control" runat="server"></asp:TextBox>
            </div>

            <%--            <p>Es una:</p>
            <asp:RadioButton ID="rdbmarca" Text="Marca" GroupName="es" runat="server" />
            <asp:RadioButton ID="rdbcategoria" Text="Categoria" GroupName="es" runat="server" />
            
            <asp:Label ID="ninguno" runat="server" Text="Selecciona el tipo"></asp:Label>--%>
        </div>
    </div>

    <!--AGREGAR-->
    <div class="row">
        <div class="col-2">
            <asp:Button ID="btn_alta" OnClick="btn_alta_Click" class="btn btn-primary btn-lg btnlogin alta" runat="server" Text="Agregar" />
        </div>

        <div class="col-2">
            <asp:Button ID="btn_eliminar" OnClick="btn_eliminar_Click" class="btn btn-danger btn-lg btnlogin" runat="server" Text="Eliminar" />
        </div>
    </div>


</asp:Content>
