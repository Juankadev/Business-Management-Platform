<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ListadoCategorias.aspx.cs" Inherits="TPFinal_Rey_Balihaut.ListadoCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="text-align: center">Listado de Categorias</h1>

    <a href="Categorias.aspx" class="btn success3 btn-lg btnlogin" style="width: 20%; margin: 20px auto">Nueva Categoria</a>




    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <div class="col-3 centrar">
                <label for="buscador">Buscador de Categorias</label>
                <asp:TextBox ID="buscador" CssClass="form-control" OnTextChanged="buscador_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
            </div>


            <asp:GridView ID="gvCategorias" OnSelectedIndexChanged="gvCategorias_SelectedIndexChanged" DataKeyNames="IDCategoria" CssClass="table table-dark table-hover" Style="color: #fff" AutoGenerateColumns="false" runat="server" HeaderStyle-CssClass="gradient">
                <Columns>

                    <%--            <asp:BoundField HeaderText="ID" DataField="IDCategoria">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>--%>

                    <asp:BoundField HeaderText="Nombre" DataField="DescripcionCategoria">
                        <ItemStyle CssClass="" />
                        <HeaderStyle CssClass=""></HeaderStyle>
                    </asp:BoundField>


                    <asp:CommandField HeaderText="Detalle" ShowSelectButton="true" SelectText="Ver">
                        <ItemStyle CssClass="" />
                        <HeaderStyle CssClass=""></HeaderStyle>
                        <ControlStyle CssClass="fa-solid fa-eye success2" />
                    </asp:CommandField>


                    <%--<asp:LinkButton id="lbtnServerSelect" runat="server" text="Select" commandname="Select"  />--%>
                </Columns>
            </asp:GridView>

        </ContentTemplate>
    </asp:UpdatePanel>


        <div class="col-3" style="margin-left: 10px; margin-bottom: 10px; display: inline-block">
        <asp:Image ID="excel" ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/Microsoft_Excel_2013-2019_logo.svg/2086px-Microsoft_Excel_2013-2019_logo.svg.png" runat="server" Height="50px" />

        <asp:Button ID="btnExcel" runat="server" Text="Exportar a Excel" OnClick="btnExcel_Click" CssClass="btn btn-success" />
    </div>

</asp:Content>
