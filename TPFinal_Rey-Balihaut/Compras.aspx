<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="TPFinal_Rey_Balihaut.Compras1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <h1 class="title">Compras</h1>
        <div class="col-5">
            <%--            <div class="mb-3">
                <label for="codigo" class="form-label">Codigo</label>
                <asp:TextBox ID="codigo" class="form-control" runat="server"></asp:TextBox>
            </div>--%>

            <div class="mb-3 proveedor">
                <label for="ddlproveedor" class="form-label">Proveedor</label>
                <asp:DropDownList CssClass="form-select" ID="ddlproveedor" runat="server"></asp:DropDownList>
            </div>




            <%--            <%if (cantidad == 0)
                { %>

            <div class="mb-3">
                <label for="txtcant" class="form-label" style="display: block">Cantidad de Productos</label>

                <div style="display: inline-block">
                    <asp:TextBox ID="txtcant" type="number" min="1" class="form-control" runat="server"></asp:TextBox>
                </div>

                <div style="display: inline-block">
                    <asp:Button ID="btncant" OnClick="btncant_Click" runat="server" CssClass="btn btn-primary" Text="Agregar" />
                </div>

<%--                <label for="" class="form-label">Si vuelves a cambiar el valor,<%-- se resetearan los campos</label>
            </div>--%>



            <!---->
            <%--            <%for (int i = 0; i < cantidad; i++)
                { %>

            <%string val = i.ToString(); %>

            <div>
                <div class="mb-3" style="width: 41%; display: inline-block">
                    <label for="ddlproducto" class="form-label">Producto</label>

                    <asp:DropDownList CssClass="form-select dropProd" ID="ddlproductos" runat="server"></asp:DropDownList>
                </div>

                <div class="mb-3" style="width: 30%; display: inline-block">
                    <label for="cantidades" class="form-label">Cantidad</label>
                    <asp:TextBox ID="hola" class="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="mb-3" style="width: 26%; display: inline-block">
                    <label for="precio" class="form-label">Precio Unit.</label>
                    <asp:TextBox ID="precio" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>

            <%} %>--%>





            <div>
                <div class="mb-3" style="width: 45%; display: inline-block">
                    <label for="ddlproducto" class="form-label">Producto</label>

                    <asp:DropDownList CssClass="form-select dropProd" ID="ddlproductos" runat="server"></asp:DropDownList>
                </div>

                <div class="mb-3" style="width: 20%; display: inline-block">
                    <label for="cantidades" class="form-label">Cantidad</label>
                    <asp:TextBox ID="cantidades" class="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="mb-3" style="width: 20%; display: inline-block">
                    <label for="precio" class="form-label">Precio Unit.</label>
                    <asp:TextBox ID="precio" class="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="mb-3" style="width: 12%; display: inline-block">
                    <asp:Button ID="btn_nuevo_producto" class="btn btn-primary  btnlogin" OnClick="btn_nuevo_producto_Click" runat="server" Text="OK" />
                </div>

            </div>
        </div>



        <div class="col-4">
            <asp:GridView ID="gvAgregados" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="gvSeleccionados_SelectedIndexChanged" DataKeyNames="Codigo" CssClass="table table-dark table-hover" Style="color: #fff">
                <Columns>
                    <asp:BoundField HeaderText="Producto" DataField="Codigo" />
                    <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                    <asp:BoundField HeaderText="Precio" DataFormatString="{0:C}" DataField="Precio" />

                    <asp:CommandField HeaderText="Eliminar" ShowSelectButton="true" SelectText="Eliminar">
                        <ItemStyle CssClass="text-warning" />
                        <HeaderStyle CssClass="bg-warning bg-gradient"></HeaderStyle>
                        <ControlStyle CssClass="select" />
                    </asp:CommandField>
                </Columns>
            </asp:GridView>

            <div class="bg-dark" style="display: flex; justify-content: flex-end; column-gap: 20px; font-size: 1.2rem; margin-bottom: 15px">
                <asp:Label ID="total" Style="font-weight: bold" runat="server" Text="Total:"></asp:Label>
                <asp:Label ID="suma" Style="font-weight: bold" runat="server" Text="$0"></asp:Label>
            </div>

            <!--AGREGAR-->
            <asp:Button ID="altaArticulo" class="btn btn-success btn-lg btnlogin" runat="server" Text="Registrar Compra" />

        </div>


    </div>






</asp:Content>
