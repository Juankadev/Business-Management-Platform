<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="ListadoProveedores.aspx.cs" Inherits="TPFinal_Rey_Balihaut.ListadoProveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="text-align: center">Listado de Proveedores</h1>

    <a href="Proveedores.aspx" class="btn btn-success bg-gradient btn-lg btnlogin" style="width: 20%; margin: 20px auto">Nuevo Proveedor</a>



    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <div class="col-3 centrar">
                <label for="buscador">Buscador de Proveedores</label>
                <asp:TextBox ID="buscador" CssClass="form-control" OnTextChanged="buscador_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
            </div>

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

        </ContentTemplate>
    </asp:UpdatePanel>


        <div class="col-3" style="margin-left: 10px; margin-bottom: 10px; display: inline-block">
        <asp:Image ID="excel" ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/Microsoft_Excel_2013-2019_logo.svg/2086px-Microsoft_Excel_2013-2019_logo.svg.png" runat="server" Height="50px" />

        <asp:Button ID="btnExcel" runat="server" Text="Exportar a Excel" OnClick="btnExcel_Click" CssClass="btn btn-success" />
    </div>

</asp:Content>
