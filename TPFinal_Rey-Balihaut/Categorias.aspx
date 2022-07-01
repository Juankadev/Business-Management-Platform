<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="TPFinal_Rey_Balihaut.Alta_Marca_Categoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="row">
        <h1 class="title">Categorias</h1>
        <div class="col-4">

            <div class="mb-4">
                <label for="nombre" class="form-label">Nombre</label>
                <asp:TextBox ID="nombre" MaxLength="50" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>


    <!--AGREGAR-->
    <div class="row">
        <div class="col-2">
            <asp:Button ID="btn_alta" OnClick="btn_alta_Click" class="btn btn-success btn-lg btnlogin" runat="server" Text="Agregar" />
        </div>

        <div class="col-2">
            <asp:Button ID="btn_eliminar" OnClick="btn_eliminar_Click" class="btn btn-danger btn-lg btnlogin" runat="server" Text="Eliminar" />
        </div>
    </div>


</asp:Content>
