<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegistroCompra.aspx.cs" Inherits="TPFinal_Rey_Balihaut.FacturaCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-6 centrar">


        <h1 class="title">Registro de Compra</h1>

        <div>

            <div>
                <div class="" style="display: flex; justify-content: space-between; align-content: center; align-items: center">

                    <div>
                        <h3 class="title2">NUMERO DE COMPRA: </h3>
                        <asp:Label ID="txtnum" class="title2" runat="server" Text=""></asp:Label>
                    </div>

                    <div>
                        <h3 class="title2">PROVEEDOR: </h3>
                        <asp:Label ID="txtproveedor" class="title2" runat="server" Text="Proveedor"></asp:Label>
                    </div>




                </div>
            </div>




            <div>
                <div class="" style="display: flex; justify-content: space-between; align-content: center">

                    <div>
                        <h3 class="title2">FECHA: </h3>
                        <asp:Label ID="txtfecha" class="title2" runat="server" Text="Fecha"></asp:Label>
                    </div>

                    <div>
                        <h3 class="title2">CONDICION: </h3>
                        <asp:Label ID="txtcondicion" class="title2" runat="server" Text="Condicion de Pago"></asp:Label>
                    </div>

                </div>
            </div>

        </div>

        <asp:GridView ID="gvArticulos" CssClass="table table-dark" runat="server" AutoGenerateColumns="false">

            <Columns>
                <asp:BoundField HeaderText="Producto" DataField="Nombre">
                    <ItemStyle CssClass="" />
                    <HeaderStyle CssClass=""></HeaderStyle>
                </asp:BoundField>


                <asp:BoundField HeaderText="Cantidad" DataField="Cantidad">
                    <ItemStyle CssClass="rigth" />
                    <HeaderStyle CssClass="rigth"></HeaderStyle>
                </asp:BoundField>


                <asp:BoundField HeaderText="Precio" DataField="Precio" DataFormatString="{0:C}">
                    <ItemStyle CssClass="rigth" />
                    <HeaderStyle CssClass="rigth"></HeaderStyle>
                </asp:BoundField>


<%--                <asp:BoundField HeaderText="Total" DataField="" DataFormatString="{0:C}">
                    <ItemStyle CssClass="rigth" />
                    <HeaderStyle CssClass="rigth"></HeaderStyle>
                </asp:BoundField>--%>
            </Columns>

        </asp:GridView>

        <div style="display: flex; justify-content: space-between">
            <div>
                <h3 class="title2">OBSERVACIONES: </h3>
                <asp:Label ID="txtobservaciones" class="title2" runat="server" Text="Observaciones"></asp:Label>
            </div>

            <div>
                <h3 class="title2">TOTAL: $</h3>
                <asp:Label ID="txttotal" class="title2" runat="server" Text="Total"></asp:Label>
            </div>
        </div>




    </div>

</asp:Content>
