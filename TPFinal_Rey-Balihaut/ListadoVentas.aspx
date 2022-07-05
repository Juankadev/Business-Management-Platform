<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListadoVentas.aspx.cs" Inherits="TPFinal_Rey_Balihaut.ListadoVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="text-align: center">Listado de Ventas</h1>

    <a href="Compras.aspx" class="btn btn-success bg-gradient btn-lg btnlogin" style="width: 20%; margin: 20px auto">Nueva Compra</a>

    <asp:GridView ID="gvVentas" OnSelectedIndexChanged="gvVentas_SelectedIndexChanged" CssClass="table table-dark table-hover" DataKeyNames="" Style="color: #fff" AutoGenerateColumns="false" runat="server">
        <Columns>

            <%--            <asp:BoundField HeaderText="Código" DataField="Codigo">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>--%>

            <asp:BoundField HeaderText="Numero Venta" DataField="numventa">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>


            <asp:BoundField HeaderText="Cliente" DataField="Cliente.Apellido">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>


            <asp:BoundField HeaderText="Total" DataField="Total" DataFormatString="{0:C}">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>

            <asp:BoundField HeaderText="Fecha" DataField="Fecha">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>


            <asp:CommandField HeaderText="Detalle" ShowSelectButton="true" SelectText="Detalle">
                <ItemStyle CssClass="text-warning" />
                <HeaderStyle CssClass="bg-warning bg-gradient"></HeaderStyle>
                <ControlStyle CssClass="select" />
            </asp:CommandField>

        </Columns>
    </asp:GridView>

</asp:Content>
