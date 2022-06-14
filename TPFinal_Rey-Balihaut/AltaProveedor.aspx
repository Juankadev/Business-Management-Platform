<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AltaProveedor.aspx.cs" Inherits="TPFinal_Rey_Balihaut.Compras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <h1>Alta de Proveedor</h1>
        <div class="col-2">

            <div class="mb-3">
                <label for="TextBox1" class="form-label">CUIT/CUIL</label>
                <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TextBox2" class="form-label">Nombre/Razón Social</label>
                <asp:TextBox ID="TextBox2" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="TextBox3" class="form-label">Teléfono</label>
                <asp:TextBox ID="TextBox3" class="form-control" runat="server"></asp:TextBox>
            </div>


        </div>



        <div class="col-2">
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
        </div>
    </div>

    <!--AGREGAR-->
    <div class="row">
        <div class="col-2">
            <asp:Button ID="altaArticulo" class="btn btn-primary btn-lg btnlogin" runat="server" Text="Agregar" />
        </div>
    </div>




</asp:Content>
