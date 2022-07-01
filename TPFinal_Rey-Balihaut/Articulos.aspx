<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="TPFinal_Rey_Balihaut.Altas1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        function validar() {
            var nombre = document.getElementById("nombre").value;
            //var nombre = document.getElementById("<% = nombre.ClientID %>").value;

            if (nombre === "") {
                $("#nombre").addClass("is-invalid");
            }
            else {
                $("#nombre").addClass("is-invalid");
            }
            return false;
            //else {
            //    $("#codigo").removeClass("is-invalid");
            //    $("#codigo").addClass("is-valid");
            //    alert("Codigo Lleno");
            //}
            //return false;

        }
    </script>



    <div class="row">
        <h1 class="title">Articulos</h1>
        <%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
        <div class="col-2">

            <div class="mb-3">
                <label for="codigo" class="form-label">Codigo</label>
                <asp:TextBox ID="codigo" ClientIDMode="Static" MaxLength="10" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="nombre" class="form-label">Nombre</label>
                <asp:TextBox ID="nombre" ClientIDMode="Static" MaxLength="50" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="ganancia" class="form-label">Porcentaje de Ganancia</label>
                <asp:TextBox ID="ganancia" type="number" min="0 class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="precio" class="form-label">Precio</label>
                <asp:TextBox ID="precio" class="form-control" runat="server"></asp:TextBox>
            </div>

        </div>

        <div class="col-2">

            <div class="mb-3">
                <label for="ddlmarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlmarca" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <label for="ddlcategoria" class="form-label">Categoria</label>
                <asp:DropDownList ID="ddlcategoria" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

            <%--            <div class="mb-3">
                <label for="ddlproveedor" class="form-label">Proveedor</label>
                <asp:DropDownList ID="ddlproveedor" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>--%>

            <div class="mb-3">
                <label for="stockactual" class="form-label">Stock Actual</label>
                <asp:TextBox ID="stockactual" type="number" min="0" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">

                <label for="stockminimo" class="form-label">Stock Minimo</label>
                <asp:TextBox ID="stockminimo" type="number" min="0" class="form-control" runat="server"></asp:TextBox>

<%--                <asp:RangeValidator
                    ErrorMessage="El valor debe ser mayor o igual a 0"
                    MaximumValue="1000000000000"
                    MinimumValue="0"
                    ControlToValidate="stockminimo"
                    runat="server" />--%>
            </div>

        </div>

        <!--GV PROVEEDORES-->
        <div class="col-3">
            <%--            <asp:GridView ID="gvProveedores" runat="server" CssClass="table table-bordered" Style="color: #fff" AutoGenerateColumns="false">

                <Columns>
                    <asp:BoundField HeaderText="Proveedores" DataField="Nombre">
                        <ItemStyle CssClass="" />
                        <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Añadir">
                        <ItemTemplate>
                            <asp:CheckBox ID="check" runat="server"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>


            </asp:GridView>--%>

            <asp:Label ID="feedback" runat="server" Text="Selecciona Proveedores del Articulo"></asp:Label>

            <asp:CheckBoxList ID="CheckBoxList" class="form-check" runat="server">
            </asp:CheckBoxList>


            <asp:CheckBoxList ID="CheckBoxListAsociados" runat="server">
            </asp:CheckBoxList>

        </div>



        <!--GV PROVEEDORES ASOCIADOS-->

        <%--            <asp:GridView ID="gvAsociados" runat="server" CssClass="table table-bordered" Style="color: #fff" AutoGenerateColumns="false">

                <%--<Columns>
                    <asp:BoundField HeaderText="Proveedores Vinculados" DataField="Nombre">
                        <ItemStyle CssClass="" />
                        <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
                    </asp:BoundField>
                </Columns>

            </asp:GridView>--%>
    </div>



    <!--AGREGAR-->
    <div class="row">
        <div class="col-2">
            <asp:Button ID="btn_articulo" OnClientClick="return validar()" OnClick="altaArticulo_Click" autopostback="false" class="btn btn-success btn-lg btnlogin" runat="server" Text="Agregar" />
        </div>

        <div class="col-2">
            <asp:Button ID="btn_eliminar" OnClick="btn_eliminar_Click" class="btn btn-danger btn-lg btnlogin" runat="server" Text="Eliminar" />
        </div>

        <div class="col-3">
        </div>






        <%--        <!-- Button trigger modal -->
<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
  Launch demo modal
</button>

<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" style="color:#000" id="exampleModalLabel">Codigo Existente</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Entendido"></button>
      </div>
      <div class="modal-body" style="color:#000">
        Ya existe un producto con este código.
      <div class="modal-footer" style="color:#000">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Entendido</button>
      </div>
    </div>
  </div>
</div>--%>
    </div>
</asp:Content>




