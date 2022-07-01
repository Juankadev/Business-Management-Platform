<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="TPFinal_Rey_Balihaut.Altas1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        function validar() {


            if (codigo === "") {
                //document.getElementById('codigo').classList.remove('is-valid')
                document.getElementById('codigo').classList.add('is-valid')

            }
            else {
                //document.getElementById('codigo').classList.remove('is-invalid')
                //document.getElementById('codigo').classList.add('is-valid')
                //return true;
            }
            return true;

        }
    </script>



    <div class="row">
        <h1>Articulos</h1>
        <%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
        <div class="col-2">

            <div class="mb-3">
                <label for="codigo" class="form-label">Codigo</label>
                <asp:TextBox ID="codigo" ClientIDMode="Static" MaxLength="10" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="nombre" class="form-label">Nombre</label>
                <asp:TextBox ID="nombre" MaxLength="50" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">
                <label for="ganancia" class="form-label">Porcentaje de Ganancia</label>
                <asp:TextBox ID="ganancia" type="number" class="form-control" runat="server"></asp:TextBox>
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
                <asp:TextBox ID="stockactual" type="number" class="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="mb-3">

                <label for="stockminimo" class="form-label">Stock Minimo</label>
                <asp:TextBox ID="stockminimo" type="number" class="form-control" runat="server"></asp:TextBox>
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


            <asp:CheckBoxList ID="CheckBoxList" runat="server">
            </asp:CheckBoxList>

        </div>



        <!--GV PROVEEDORES ASOCIADOS-->
        <div class="col-3">
            <%--            <asp:GridView ID="gvAsociados" runat="server" CssClass="table table-bordered" Style="color: #fff" AutoGenerateColumns="false">

                <%--<Columns>
                    <asp:BoundField HeaderText="Proveedores Vinculados" DataField="Nombre">
                        <ItemStyle CssClass="" />
                        <HeaderStyle CssClass="bg-primary bg-gradient"></HeaderStyle>
                    </asp:BoundField>
                </Columns>

            </asp:GridView>--%>


            <asp:CheckBoxList ID="CheckBoxListAsociados" runat="server">
            </asp:CheckBoxList>

        </div>
    </div>



    <!--AGREGAR-->
    <div class="row">
        <div class="col-2">
            <asp:Button ID="btn_articulo" OnClientClick="return validar()" OnClick="altaArticulo_Click" class="btn btn-primary btn-lg btnlogin" runat="server" Text="Agregar" />
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
