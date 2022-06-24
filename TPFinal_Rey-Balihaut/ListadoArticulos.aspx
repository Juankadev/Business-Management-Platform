<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListadoArticulos.aspx.cs" Inherits="TPFinal_Rey_Balihaut.ListadoArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="text-align: center">Tus Articulos</h1>

    <a href="Articulos.aspx" class="btn btn-success bg-gradient btn-lg btnlogin" style="width: 20%; margin: 20px auto">Nuevo Articulo</a>

    <asp:GridView ID="gvArticulos" OnSelectedIndexChanged="gvArticulos_SelectedIndexChanged" CssClass="table table-bordered" DataKeyNames="Codigo" Style="color: #fff" AutoGenerateColumns="false" runat="server">
        <Columns>

            <asp:BoundField HeaderText="Código" DataField="Codigo">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>

            <asp:BoundField HeaderText="Nombre" DataField="Nombre">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>


            <asp:BoundField HeaderText="Marca" DataField="Marca.DescripcionMarca">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>


            <asp:BoundField HeaderText="Categoria" DataField="Categoria.DescripcionCategoria">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>

            <asp:BoundField HeaderText="Proveedor" DataField="Proveedor.Nombre">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>

            <asp:BoundField HeaderText="Precio" DataField="Precio">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>

            <asp:BoundField HeaderText="Porcentaje Ganancia" DataField="PorcentajeGanancia">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>

            <asp:BoundField HeaderText="Stock Minimo" DataField="StockMinimo">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>

            <asp:BoundField HeaderText="Stock Actual" DataField="StockActual">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>

            <asp:CommandField ShowSelectButton="true" SelectText="Modificar" HeaderText="Modificar">
                <ItemStyle CssClass="text-warning" />
                <HeaderStyle CssClass="bg-warning bg-gradient"></HeaderStyle>
                <ControlStyle CssClass="select" />
            </asp:CommandField>

            <asp:CommandField ShowDeleteButton="true" SelectText="Eliminar" HeaderText="Eliminar">
                <ItemStyle CssClass="text-danger" />
                <HeaderStyle CssClass="bg-danger bg-gradient"></HeaderStyle>
                <ControlStyle CssClass="select" />
            </asp:CommandField>


        </Columns>
    </asp:GridView>

</asp:Content>
