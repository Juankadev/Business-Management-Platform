using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPFinal_Rey_Balihaut
{
    public partial class Altas1 : System.Web.UI.Page
    {
        protected bool existe(ListItem li, List<String> listaAsociados)
        {
            string liString = li.Text;
            for (int i = 0; i < listaAsociados.Count; i++)
            {
                if (listaAsociados[i] == liString)
                {
                    return true;
                }
            }
            return false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            codigo.MaxLength = 10;
            precio.CssClass = "form-control";


            if (!IsPostBack)
            {
                MarcaNegocio marca_negocio = new MarcaNegocio();
                ddlmarca.DataSource = marca_negocio.listar();
                ddlmarca.DataValueField = "IDMarca";
                ddlmarca.DataTextField = "DescripcionMarca";
                ddlmarca.DataBind();

                CategoriaNegocio categoria_negocio = new CategoriaNegocio();
                ddlcategoria.DataSource = categoria_negocio.listar();
                ddlcategoria.DataValueField = "IDCategoria";
                ddlcategoria.DataTextField = "DescripcionCategoria";
                ddlcategoria.DataBind();

                ProveedorNegocio proveedor_negocio = new ProveedorNegocio();
                //ddlproveedor.DataSource = proveedor_negocio.listar();
                //ddlproveedor.DataValueField = "CUIT";
                //ddlproveedor.DataTextField = "Nombre";
                //ddlproveedor.DataBind();

                btn_articulo.Text = "Agregar";

                if (Request.QueryString["id"] != null)
                {
                    btn_eliminar.Enabled = true;
                    
                    codigo.ReadOnly = true;
                    string codigoURL = Request.QueryString["id"].ToString();
                    btn_articulo.Text = "Modificar";
                    ProductoNegocio negocio = new ProductoNegocio();
                    List<_Producto> lista = negocio.listar();
                    _Producto producto = lista.Find(x => x.Codigo == codigoURL);

                    codigo.Text = producto.Codigo;
                    nombre.Text = producto.Nombre;
                    ddlmarca.SelectedIndex = producto.Marca.IDMarca - 1;
                    ddlcategoria.SelectedIndex = producto.Categoria.IDCategoria - 1;
                    //ddlproveedor.SelectedValue = producto.Proveedor.CUIT;
                    //precio.Text = producto.Precio.ToString();

                    CompraNegocio negocio_compra = new CompraNegocio();
                    if (negocio_compra.existeCompra(producto.Codigo))
                    {
                        precio.Text = producto.Precio.ToString();
                    }
                    else
                    {
                        precio.Text = "No hay Compras del articulo";
                    }
                    
                    stockactual.Text = producto.StockActual.ToString();
                    stockminimo.Text = producto.StockMinimo.ToString();
                    ganancia.Text = producto.PorcentajeGanancia.ToString();

                    //CheckBoxList.Visible = false;


                    CheckBoxList.DataSource = proveedor_negocio.listarProveedores();
                    CheckBoxList.DataBind();
                    List<String> listaAsociados = proveedor_negocio.listarProveedoresAsociados(codigo.Text);

                    foreach (ListItem li in CheckBoxList.Items)
                    {
                        if (existe(li, listaAsociados))
                            li.Selected = true;
                    } 
                }
                else
                {
                    precio.Text = "0";
                    CheckBoxList.DataSource = proveedor_negocio.listarProveedores();
                    CheckBoxList.DataBind();
                    //btn_eliminar.Visible = false;
                    btn_eliminar.Enabled = false;
                    btn_eliminar.CssClass = "btn btn-danger btn-lg btnlogin";
                }
            }
        }


        protected void altaArticulo_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if(!Page.IsValid)
                return;

            //solo se puede agregar o modificar si:
            if (codigo.Text != "" && nombre.Text != "")
            {
                ProductoNegocio producto_negocio = new ProductoNegocio();
                _Producto aux = new _Producto();
                aux.Marca = new _Marca();
                aux.Categoria = new _Categoria();

                ProveedorNegocio proveedor_negocio = new ProveedorNegocio();
                List<_Proveedor2> lista = proveedor_negocio.listar();

                aux.Codigo = codigo.Text;
                aux.Nombre = nombre.Text;
                aux.Marca.IDMarca = ddlmarca.SelectedIndex + 1;
                aux.Categoria.IDCategoria = ddlcategoria.SelectedIndex + 1;


                if (precio.Text == "No hay Compras del articulo")
                {
                    aux.Precio = 0;
                }
                else
                {
                    aux.Precio = decimal.Parse(precio.Text);
                }
  
                aux.StockActual = decimal.Parse(stockactual.Text);
                aux.StockMinimo = decimal.Parse(stockminimo.Text);
                aux.PorcentajeGanancia = decimal.Parse(ganancia.Text);



                if (Request.QueryString["id"] != null) //se esta modificando un prod.
                {
                    producto_negocio.modificar(aux);

                    //Modificar proveedores_x_producto
                    foreach (ListItem li in CheckBoxList.Items)
                    {
                        if (li.Selected == false)
                        {
                            _Proveedor2 proveedor = lista.Find(x => x.Nombre == li.Text);
                            proveedor_negocio.eliminarProveedoresAsociados(proveedor.CUIT, aux.Codigo);
                        }
                        else
                        {
                            _Proveedor2 proveedor = lista.Find(x => x.Nombre == li.Text);
                            producto_negocio.agregarProveedores(proveedor.CUIT, aux.Codigo);
                        }
                    }
                }

                else //se esta agregando un producto
                {
                    producto_negocio.agregar(aux);

                    //Agregar proveedores_x_producto
                    foreach (ListItem li in CheckBoxList.Items)
                    {
                        if (li.Selected)
                        {
                            _Proveedor2 proveedor = lista.Find(x => x.Nombre == li.Text);
                            producto_negocio.agregarProveedores(proveedor.CUIT, aux.Codigo);
                        }
                    }
                }

                Response.Redirect("ListadoArticulos.aspx");
            }


            //validar
            if (codigo.Text == "")
            {
                //codigo.BackColor = System.Drawing.Color.IndianRed;
                codigo.CssClass = "form-control is-invalid";
            }
            else
            {
                //codigo.BorderColor = System.Drawing.Color.White;
                codigo.CssClass = "form-control is-valid";
            }

            if (nombre.Text == "")
            {
                //nombre.BackColor = System.Drawing.Color.IndianRed;
                nombre.CssClass = "form-control is-invalid";
            }
            else
            {
                //nombre.BackColor = System.Drawing.Color.White;
                nombre.CssClass = "form-control is-valid";
            }

        }


        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            ProductoNegocio producto_negocio = new ProductoNegocio();
            if (Request.QueryString["id"] != null)
            {
                string codigoURL = Request.QueryString["id"].ToString();
                producto_negocio.eliminar(codigoURL);
                Response.Redirect("ListadoArticulos.aspx");
            }
        }
    }
}