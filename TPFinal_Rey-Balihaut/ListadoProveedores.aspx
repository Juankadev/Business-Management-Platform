<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListadoProveedores.aspx.cs" Inherits="TPFinal_Rey_Balihaut.ListadoProveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="text-align: center">Listado de Proveedores</h1>

    <a href="Proveedores.aspx" class="btn btn-success bg-gradient btn-lg btnlogin" style="width: 20%; margin: 20px auto">Nuevo Proveedor</a>

    <asp:GridView ID="gvProveedores" OnSelectedIndexChanged="gvProveedores_SelectedIndexChanged" CssClass="table table-dark table-hover" DataKeyNames="CUIT" Style="color: #fff" AutoGenerateColumns="false" runat="server">
        <Columns>

<%--            <asp:BoundField HeaderText="CUIT" DataField="CUIT">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>--%>

            <asp:BoundField HeaderText="Nombre" DataField="Nombre">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>


            <asp:BoundField HeaderText="Telefono" DataField="Telefono">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>


            <asp:BoundField HeaderText="Mail" DataField="Mail">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>

<%--            <asp:BoundField HeaderText="Direccion" DataField="Direccion">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>   --%>        
          
            <asp:CommandField HeaderText="Detalle" ShowSelectButton="true" SelectText="Detalle">
                <ItemStyle CssClass="text-warning" />
                <HeaderStyle CssClass="bg-warning bg-gradient"></HeaderStyle>
                <ControlStyle CssClass="select" />
            </asp:CommandField>


            <%--<asp:LinkButton id="lbtnServerSelect" runat="server" text="Select" commandname="Select"  />--%>

            </Columns>
    </asp:GridView>
</asp:Content>
