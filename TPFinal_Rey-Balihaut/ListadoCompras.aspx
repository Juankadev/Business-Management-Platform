<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListadoCompras.aspx.cs" Inherits="TPFinal_Rey_Balihaut.ListadoCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="text-align: center">Listado de Compras</h1>


    <div class="card text-white bg-primary bg-gradient mb-3 centrar" style="max-width: 18rem;">
        <div class="card-header">Total Compras</div>
        <div class="card-body">
            <%--            <h5 class="card-title"></h5>--%>
            <asp:Label ID="total" class="card-text" Style="font-weight: bold; font-size: 1.3rem" runat="server" Text=""></asp:Label>
        </div>
    </div>


    <a href="Compras.aspx" class="btn btn-success bg-gradient btn-lg btnlogin" style="width: 20%; margin: 20px auto">Nueva Compra</a>


    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>


    <asp:GridView ID="gvCompras" OnSelectedIndexChanged="gvCompras_SelectedIndexChanged" CssClass="table table-dark table-hover" DataKeyNames="numcompra" Style="color: #fff" AutoGenerateColumns="false" runat="server" OnPageIndexChanging="gvCompras_PageIndexChanging"
        PageSize="3" AllowPaging="true">
        <Columns>

            <%--            <asp:BoundField HeaderText="Código" DataField="Codigo">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>--%>

            <asp:BoundField HeaderText="Numero Compra" DataField="numcompra">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>


            <asp:BoundField HeaderText="Proveedor" DataField="Proveedor.Nombre">
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
