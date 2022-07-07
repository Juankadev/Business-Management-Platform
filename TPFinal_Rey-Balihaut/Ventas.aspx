<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="TPFinal_Rey_Balihaut.Ventas2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <h1 class="title">Ventas</h1>

        <div class="col-5">

            <div>
                <label for="txtfecha" class="form-label">Fecha</label>
                <asp:TextBox ID="txtfecha" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>

                <div style="width: 49%; display: inline-block">
                    <label for="ddlclientes" class="form-label">Cliente</label>
                    <asp:DropDownList CssClass="form-select" ID="ddlclientes" runat="server"></asp:DropDownList>
                </div>

                <div style="width: 49%; display: inline-block">
                    <label for="ddlcondicion" class="form-label">Condición</label>
                    <asp:DropDownList CssClass="form-select" ID="ddlcondicion" runat="server"></asp:DropDownList>
                </div>


            </div>


            <div>
                <label style="display: block" for="observaciones" class="form-label">Observaciones</label>
                <%--                <textarea style="display:block" name="observaciones" maxlength="300" id="observaciones" cols="31" class="form-control" rows="2"></textarea>--%>
                <asp:TextBox ID="observaciones" MaxLength="300" class="form-control" runat="server"></asp:TextBox>
            </div>


            <!--Requerido para Update Panel-->
            <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>

            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div>
                        <div class="mb-3" style="width: 45%; display: inline-block">
                            <label for="ddlproducto" class="form-label">Producto</label>

                            <asp:DropDownList CssClass="form-select dropProd" ID="ddlproductos" AutoPostBack="true" OnSelectedIndexChanged="ddlproductos_SelectedIndexChanged" runat="server"></asp:DropDownList>
                        </div>

                        <div class="mb-3" style="width: 40%; display: inline-block">
                            <label for="cantidades">Cantidad Disponible: </label>

                            <asp:Label ID="myLabel" CssClass="bg-success" runat="server" Style="border-radius: 20px" />

                            <asp:Button ID="verstock" runat="server" Text="Ver Stock" CssClass="btn btn-secondary btn-sm" OnClick="verstock_Click" Style="color: #fff" />

                            <asp:TextBox ID="cantidades" class="form-control" runat="server" type="number" min="1"></asp:TextBox>
                        </div>


                        <%--                <div class="mb-3" style="width: 20%; display: inline-block">
                    <label for="precio" class="form-label">Precio Unit.</label>
                    <asp:TextBox ID="precio" class="form-control" runat="server"></asp:TextBox>
                </div>--%>

                        <div class="mb-3" style="width: 12%; display: inline-block">
                            <asp:Button ID="btn_nuevo_producto" class="btn btn-primary  btnlogin" OnClick="btn_nuevo_producto_Click" runat="server" Text="OK" />
                        </div>

                        <asp:Label ID="lblstock" CssClass="text-danger" runat="server" Text="Stock Insuficiente" />

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>



        <div class="col-5">
            <asp:GridView ID="gvAgregados" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvAgregados_SelectedIndexChanged" DataKeyNames="Codigo" CssClass="table table-dark table-hover" Style="color: #fff">
                <Columns>
                    <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                    <asp:BoundField HeaderText="Producto" DataField="Nombre" />
                    <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                    <asp:BoundField HeaderText="Precio" DataFormatString="{0:C}" DataField="Precio" />

                    <asp:CommandField HeaderText="Eliminar" ShowSelectButton="true" SelectText="Eliminar">
                        <ItemStyle CssClass="text-warning" />
                        <HeaderStyle CssClass="bg-warning bg-gradient"></HeaderStyle>
                        <ControlStyle CssClass="select" />
                    </asp:CommandField>
                </Columns>
            </asp:GridView>

            <div class="bg-dark" style="display: flex; justify-content: flex-end; column-gap: 10px; font-size: 1.2rem; margin-bottom: 15px">
                <asp:Label ID="total" Style="font-weight: bold" runat="server" Text="Total: $"></asp:Label>
                <asp:Label ID="txtsuma" Style="font-weight: bold" runat="server" Text="$0"></asp:Label>
            </div>

            <!--AGREGAR-->
            <asp:Button ID="altaVenta" CssClass="btn btn-success btn-lg btnlogin" OnClick="altaVenta_Click" runat="server" Text="Registrar Venta" />

        </div>


    </div>





</asp:Content>
