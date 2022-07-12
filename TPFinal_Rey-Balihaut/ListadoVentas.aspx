<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ListadoVentas.aspx.cs" Inherits="TPFinal_Rey_Balihaut.ListadoVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="text-align: center">Listado de Ventas</h1>


    <div style="display: flex; justify-content: center">
        <div style="">

            <div class="card text-white bg-primary bg-gradient mb-3 centrar" style="max-width: 18rem; display: inline-block">
                <div class="card-header">Total Ventas</div>
                <div class="card-body">
                    <%--            <h5 class="card-title"></h5>--%>
                    <asp:Label ID="total" class="card-text" Style="font-weight: bold; font-size: 1.3rem" runat="server" Text=""></asp:Label>
                </div>
            </div>


            <div class="card text-white bg-secondary bg-gradient mb-3 centrar" style="max-width: 18rem; display: inline-block">
                <div class="card-header">Promedio Ventas</div>
                <div class="card-body">
                    <%--            <h5 class="card-title"></h5>--%>
                    <asp:Label ID="promedio" class="card-text" Style="font-weight: bold; font-size: 1.3rem" runat="server" Text=""></asp:Label>
                </div>
            </div>


            <div class="card text-white bg-success bg-gradient mb-3 centrar" style="max-width: 18rem; display: inline-block">
                <div class="card-header">Total Ganancia</div>
                <div class="card-body">
                    <%--            <h5 class="card-title"></h5>--%>
                    <asp:Label ID="ganancia" class="card-text" Style="font-weight: bold; font-size: 1.3rem" runat="server" Text=""></asp:Label>
                </div>
            </div>

        </div>
    </div>



    <a href="Ventas.aspx" class="btn btn-success bg-gradient btn-lg btnlogin" style="width: 20%; margin: 20px auto">Nueva Venta</a>


    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <!--Filtros-->
            <form>
                <div class="row">

                    <div class="col">
                        <label for="ddlclientes">Clientes</label>
                        <asp:DropDownList ID="ddlclientes" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddlclientes_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>

                    <div class="col-2">
                        <label for="tboxmin">Min</label>
                        <asp:TextBox ID="tboxmin" CssClass="form-control" type="number" runat="server" min="0" placeholder="$0"></asp:TextBox>
                    </div>


                    <div class="col-2">
                        <label for="tboxmax">Max</label>
                        <asp:TextBox ID="tboxmax" CssClass="form-control" type="number" runat="server" min="0" placeholder="$150000"></asp:TextBox>
                    </div>


                    <div class="col-1" style="">
                        <label for="btnfiltro" style="display: block">Filtrar</label>
                        <asp:Button ID="btnfiltro" CssClass="btn btn-primary bajar" OnClick="btnfiltro_Click" Style="display: block" runat="server" Text="Buscar" />
                    </div>


                </div>
            </form>


            <asp:GridView ID="gvVentas" OnSelectedIndexChanged="gvVentas_SelectedIndexChanged" CssClass="table table-dark table-hover" DataKeyNames="numventa" Style="color: #fff" AutoGenerateColumns="false" runat="server" OnPageIndexChanging="gvVentas_PageIndexChanging" PageSize="10" AllowPaging="true">
                <Columns>

                    <%--            <asp:BoundField HeaderText="Código" DataField="Codigo">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>--%>

                    <asp:BoundField HeaderText="Numero Venta" DataField="numventa">
                        <ItemStyle CssClass="" />
                        <HeaderStyle CssClass="bg-success bg-gradient"></HeaderStyle>
                    </asp:BoundField>


                    <asp:BoundField HeaderText="Cliente" DataField="Cliente.Apellido">
                        <ItemStyle CssClass="" />
                        <HeaderStyle CssClass="bg-success bg-gradient"></HeaderStyle>
                    </asp:BoundField>


                    <asp:BoundField HeaderText="Total" DataField="Total" DataFormatString="{0:C}">
                        <ItemStyle CssClass="" />
                        <HeaderStyle CssClass="bg-success bg-gradient"></HeaderStyle>
                    </asp:BoundField>

                    <asp:BoundField HeaderText="Fecha" DataField="Fecha">
                        <ItemStyle CssClass="" />
                        <HeaderStyle CssClass="bg-success bg-gradient"></HeaderStyle>
                    </asp:BoundField>


                    <asp:CommandField HeaderText="Detalle" ShowSelectButton="true" SelectText="Ver">
                        <ItemStyle CssClass="text-warning fa-solid fa-eye" />
                        <HeaderStyle CssClass="bg-success bg-gradient"></HeaderStyle>
                        <ControlStyle CssClass="select" />
                    </asp:CommandField>

                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>

    
    <div class="col-3" style="margin-left: 10px; margin-bottom: 10px; display: inline-block">
        <asp:Image ID="excel" ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/Microsoft_Excel_2013-2019_logo.svg/2086px-Microsoft_Excel_2013-2019_logo.svg.png" runat="server" Height="50px" />

        <asp:Button ID="btnExcel" runat="server" Text="Exportar a Excel" OnClick="btnExcel_Click" CssClass="btn btn-success" />
    </div>
</asp:Content>
