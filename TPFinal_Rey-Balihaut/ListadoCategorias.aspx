<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListadoCategorias.aspx.cs" Inherits="TPFinal_Rey_Balihaut.ListadoCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="text-align: center">Listado de Categorias</h1>

    <a href="Categorias.aspx" class="btn btn-success bg-gradient btn-lg btnlogin" style="width: 20%; margin: 20px auto">Nueva Categoria</a>

    <asp:GridView ID="gvCategorias" CssClass="table table-bordered" Style="color: #fff" AutoGenerateColumns="false" runat="server">
        <Columns>

<%--            <asp:BoundField HeaderText="ID" DataField="IDCategoria">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>--%>

            <asp:BoundField HeaderText="Nombre" DataField="DescripcionCategoria">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>
              
          
            <asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="Editar">
                <ItemStyle CssClass="text-warning" />
                <HeaderStyle CssClass="bg-warning bg-gradient"></HeaderStyle>
                <ControlStyle CssClass="select" />
            </asp:CommandField>


            <%--<asp:LinkButton id="lbtnServerSelect" runat="server" text="Select" commandname="Select"  />--%>

            </Columns>
    </asp:GridView>


</asp:Content>
