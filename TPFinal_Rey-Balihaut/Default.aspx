<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinal_Rey_Balihaut.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="title" style="margin-bottom:0">Bienvenido al INICIO!</h1>
    <h3 class="title">Estas son tus Estadisticas</h3>

    <div class="grafico" style="display:flex;justify-content:center">
        <div id="piechart" style="width: 500px; height: 300px;"></div>
    </div>
</asp:Content>
