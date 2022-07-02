<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListadoMarcas.aspx.cs" Inherits="TPFinal_Rey_Balihaut.Listado_Marca_Categoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="text-align: center">Listado de Marcas</h1>

    <a href="Marcas.aspx" class="btn btn-success bg-gradient btn-lg btnlogin" style="width: 20%; margin: 20px auto">Nueva Marca</a>

    <asp:GridView ID="gvMarcas" CssClass="table table-dark table-hover" Style="color: #fff" AutoGenerateColumns="false" OnSelectedIndexChanged="gvMarcas_SelectedIndexChanged" DataKeyNames="IDMarca" runat="server">
        <Columns>

<%--            <asp:BoundField HeaderText="ID" DataField="IDMarca">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>--%>

            <asp:BoundField HeaderText="Nombre" DataField="DescripcionMarca">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>
              
          
            <asp:CommandField HeaderText="Detalle" ShowSelectButton="true" SelectText="Detalle">
                <ItemStyle CssClass="text-warning" />
                <HeaderStyle CssClass="bg-warning bg-gradient"></HeaderStyle>
                <ControlStyle CssClass="select" />
            </asp:CommandField>


            <%--<asp:LinkButton id="lbtnServerSelect" runat="server" text="Select" commandname="Select"  />--%>

            </Columns>
    </asp:GridView>

</asp:Content>
