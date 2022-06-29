<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPFinal_Rey_Balihaut.AltaCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <h1>Clientes</h1>
        <div class="col-2">

            <div class="mb-3">
                <label for="dni" class="form-label">DNI/CUIT</label>
                <asp:TextBox ID="dni" MaxLength="10" type="number" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="nombre" class="form-label">Nombre/Razón Social</label>
                <asp:TextBox ID="nombre" MaxLength="50" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="apellido" class="form-label">Apellido</label>
                <asp:TextBox ID="apellido" MaxLength="50" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="telefono" class="form-label">Teléfono</label>
                <asp:TextBox ID="telefono" MaxLength="15" type="number" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="mail" class="form-label">Mail</label>
                <asp:TextBox ID="mail" MaxLength="50" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="direccion" class="form-label">Calle y numero</label>
                <asp:TextBox ID="direccion" MaxLength="50" class="form-control" runat="server"></asp:TextBox>
            </div>

        </div>



        <%--<div class="col-2">
            <div class="mb-3">
                <label for="TextBox3" class="form-label">Calle y numero</label>
                <asp:TextBox ID="TextBox4" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TextBox3" class="form-label">Localidad</label>
                <asp:TextBox ID="TextBox6" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TextBox3" class="form-label">Pais</label>
                <asp:TextBox ID="TextBox7" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>--%>
    </div>

    <!--AGREGAR-->
    <div class="row">
        <div class="col-2">
            <asp:Button ID="altaCliente" OnClick="altaCliente_Click" class="btn btn-primary btn-lg btnlogin" runat="server" Text="Agregar" />
        </div>
    </div>


</asp:Content>
