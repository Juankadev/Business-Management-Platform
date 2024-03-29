﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ListadoArticulos.aspx.cs" Inherits="TPFinal_Rey_Balihaut.ListadoArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="text-align: center">Listado de Articulos</h1>


    <div class="card text-white bg-danger bg-gradient mb-3 centrar" style="max-width: 18rem;">
        <div class="card-header">Stock Critico (Debajo del minimo)</div>
        <div class="card-body">

            <asp:Label ID="nombreArt" class="card-text" Style="font-weight: bold; font-size: 1.1rem" runat="server" Text=""></asp:Label>

            <asp:Label ID="stockArt" class="card-text" Style="font-weight: bold; font-size: 1.1rem" runat="server" Text=""></asp:Label>
        </div>
    </div>


    <a href="Articulos.aspx" class="btn success3 btn-lg btnlogin" style="width: 20%; margin: 20px auto">Nuevo Articulo</a>




    <asp:ScriptManager ID="script" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <div class="col-3 centrar">
                <label for="buscador">Buscador de Productos</label>
                <asp:TextBox ID="buscador" CssClass="form-control" OnTextChanged="buscador_TextChanged" AutoPostBack="true" runat="server"></asp:TextBox>
            </div>

            <asp:GridView ID="gvArticulos" OnSelectedIndexChanged="gvArticulos_SelectedIndexChanged" CssClass="table table-dark table-hover" DataKeyNames="code" Style="color: #fff" AutoGenerateColumns="false" runat="server" HeaderStyle-CssClass="gradient">
                <Columns>

                    <%--            <asp:BoundField HeaderText="Código" DataField="Codigo">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>--%>

                    <asp:BoundField HeaderText="Nombre" DataField="name">
                        <ItemStyle CssClass="" />
                        <HeaderStyle CssClass=""></HeaderStyle>
                    </asp:BoundField>


                    <asp:BoundField HeaderText="Marca" DataField="brand.description">
                        <ItemStyle CssClass="" />
                        <HeaderStyle CssClass=""></HeaderStyle>
                    </asp:BoundField>


                    <asp:BoundField HeaderText="Categoria" DataField="category.description">
                        <ItemStyle CssClass="" />
                        <HeaderStyle CssClass=""></HeaderStyle>
                    </asp:BoundField>

                    <%--            <asp:BoundField HeaderText="Proveedor" DataField="Proveedor.Nombre">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>--%>

                    <asp:BoundField HeaderText="Precio Venta" DataField="price" DataFormatString="{0:C}">
                        <ItemStyle CssClass="" />
                        <HeaderStyle CssClass=""></HeaderStyle>
                    </asp:BoundField>

                    <%--            <asp:BoundField HeaderText="Porcentaje Ganancia" DataField="PorcentajeGanancia" DataFormatString="{0:0}%">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>--%>

                    <%--            <asp:BoundField HeaderText="Stock Minimo" DataField="StockMinimo">
                <ItemStyle CssClass="" />
                <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
            </asp:BoundField>--%>

                    <asp:BoundField HeaderText="Stock Actual" DataField="currentStock">
                        <ItemStyle CssClass="" />
                        <HeaderStyle CssClass=""></HeaderStyle>
                    </asp:BoundField>



                    <asp:CommandField HeaderText="Detalle" ShowSelectButton="true" SelectText="Ver">
                        <ItemStyle CssClass="" />
                        <HeaderStyle CssClass=""></HeaderStyle>
                        <ControlStyle CssClass="fa-solid fa-eye success2" />
                    </asp:CommandField>


                    <%--            <asp:LinkButton id="lbtnServerSelect" runat="server" text="Select" commandname="Select"  />--%>
                </Columns>
            </asp:GridView>

        </ContentTemplate>
    </asp:UpdatePanel>


    <div class="col-3" style="margin-left: 10px; margin-bottom: 10px; display: inline-block">
        <asp:Image ID="excel" ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/Microsoft_Excel_2013-2019_logo.svg/2086px-Microsoft_Excel_2013-2019_logo.svg.png" runat="server" Height="50px" />

        <asp:Button ID="btnExcel" runat="server" Text="Exportar a Excel" OnClick="btnExcel_Click" CssClass="btn btn-success" />
    </div>

</asp:Content>
