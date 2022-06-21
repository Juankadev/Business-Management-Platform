<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListadoArticulos.aspx.cs" Inherits="TPFinal_Rey_Balihaut.ListadoArticulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="gvArticulos" CssClass="table table-bordered" style="color:#fff" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Código" DataField="Codigo"/>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
            <asp:BoundField HeaderText="Marca" DataField="Marca.DescripcionMarca"/>
<%--            <asp:BoundField HeaderText="Categoria" DataField="Categoria.DescripcionCategoria"/>
            <asp:BoundField HeaderText="Proveedor" DataField="Proveedor.Nombre"/>--%>
            <asp:BoundField HeaderText="Stock Minimo" DataField="StockMinimo"/>
            <asp:BoundField HeaderText="Stock Actual" DataField="StockActual"/>
            <asp:BoundField HeaderText="Porcentaje Ganancia" DataField="PorcentajeGanancia"/>
            <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion" />
        </Columns>
    </asp:GridView>

</asp:Content>
