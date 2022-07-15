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
    public partial class Compras1 : System.Web.UI.Page
    {
        public int cantidad { get; set; }
        //public int contador { get; set; }
        public string elegido { get; set; }
        public string valueproveedor { get; set; }
        public string val { get; set; }
        public List<Agregados> lista_agregados { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("Login.aspx", false);
                }
                else if (Session["tipo"].ToString() != "ADMIN")
                {
                    Response.Redirect("Default.aspx", false);
                }


                if (!IsPostBack)
                {
                    cantidad = 0;
                    //contador = 1;

                    ProveedorNegocio proveedores_negocio = new ProveedorNegocio();
                    ddlproveedor.DataSource = proveedores_negocio.listar();
                    ddlproveedor.DataValueField = "CUIT";
                    ddlproveedor.DataTextField = "NOMBRE";
                    ddlproveedor.DataBind();

                    ProductoNegocio producto_negocio = new ProductoNegocio();
                    ddlproductos.DataSource = producto_negocio.listar();
                    ddlproductos.DataValueField = "CODIGO";
                    ddlproductos.DataTextField = "NOMBRE";
                    ddlproductos.DataBind();

                    ddlcondicion.Items.Add("EFECTIVO");
                    ddlcondicion.Items.Add("15 DIAS");
                    ddlcondicion.Items.Add("30 DIAS");
                    ddlcondicion.Items.Add("60 DIAS");
                }

                if (Session["agregados"] == null)
                {
                    lista_agregados = new List<Agregados>();
                    Session.Add("agregados", lista_agregados);
                }

                gvAgregados.DataSource = Session["agregados"];
                gvAgregados.DataBind();

                txtfecha.Text = DateTime.Now.ToShortDateString();

                //TOTAL SUMA
                lista_agregados = (List<Agregados>)Session["agregados"];
                if (lista_agregados.Count > 0)
                {
                    decimal suma = 0;
                    foreach (Dominio.Agregados aux in lista_agregados)
                    {
                        suma += aux.Precio * aux.Cantidad;
                    }
                    //txtsuma.Text = String.Format("{0:0.00}", suma);
                    txtsuma.Text = suma.ToString();
                }
                else
                {
                    txtsuma.Text = "0";
                }

                //if (Session["contador"] != null)
                //{
                //    contador = int.Parse(Session["contador"].ToString());
                //}

                //para que empiece con este proveedor al recargar
                if (Request.QueryString["value"] != null)
                {
                    ddlproveedor.Enabled = false;
                    ddlproveedor.SelectedValue = Request.QueryString["value"].ToString();
                }

                if (Request.QueryString["condicion"] != null)
                {
                    ddlcondicion.SelectedValue = Request.QueryString["condicion"].ToString();
                }

                if (Request.QueryString["observacion"] != null)
                {
                    observaciones.Text = Request.QueryString["observacion"].ToString();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btncant_Click(object sender, EventArgs e)
        {
            //if(txtcant.Text!="")
            //{
            //    int ingresado = int.Parse(txtcant.Text);
            //    cantidad = ingresado;
            //}


            //cantidades.Text = "";
            //precio.Text = "";

            //contador += 1;
            //Session.Add("contador", contador);
            //Response.Redirect("Compras.aspx");
        }

        protected void btn_nuevo_producto_Click(object sender, EventArgs e)
        {
            try
            {
                if (cantidades.Text != "" && precio.Text != "")
                {
                    Agregados aux = new Agregados();
                    aux.Codigo = ddlproductos.SelectedItem.Value;
                    aux.Nombre = ddlproductos.SelectedItem.Text;
                    aux.Cantidad = int.Parse(cantidades.Text);
                    aux.Precio = decimal.Parse(precio.Text);

                    lista_agregados = (List<Agregados>)Session["agregados"];

                    //si el producto ya existe en la lista:
                    Agregados reemplazo = lista_agregados.Find(x => x.Codigo == aux.Codigo);

                    //lo modifica
                    if (reemplazo != null)
                    {
                        int index = lista_agregados.IndexOf(reemplazo);

                        lista_agregados[index].Cantidad += aux.Cantidad;
                        lista_agregados[index].Precio = aux.Precio;
                    }
                    //y si no, lo agrega
                    else
                    {
                        lista_agregados.Add(aux);
                    }

                }

                cantidades.Text = "";
                precio.Text = "";

                valueproveedor = ddlproveedor.SelectedValue;
                string cond = ddlcondicion.SelectedValue;
                string obs = observaciones.Text;
                Response.Redirect("Compras.aspx?value=" + valueproveedor + "&condicion=" + cond + "&observacion=" + obs);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void gvSeleccionados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string codigoSelected = gvAgregados.SelectedDataKey.Value.ToString();

                lista_agregados = (List<Agregados>)Session["agregados"];
                Agregados aux = lista_agregados.Find(x => x.Codigo == codigoSelected);
                lista_agregados.Remove(aux);

                cantidades.Text = "";
                precio.Text = "";

                valueproveedor = ddlproveedor.SelectedValue;
                string cond = ddlcondicion.SelectedValue;
                string obs = observaciones.Text;
                Response.Redirect("Compras.aspx?value=" + valueproveedor + "&condicion=" + cond + "&observacion=" + obs);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void altaCompra_Click(object sender, EventArgs e)
        {
            try
            {
                //INSERTAR COMPRA
                CompraNegocio negocio = new CompraNegocio();
                _Compra aux = new _Compra();
                aux.Proveedor = new _Proveedor2();
                aux.Fecha = DateTime.Now;
                aux.Proveedor.CUIT = ddlproveedor.SelectedValue;
                aux.Total = decimal.Parse(txtsuma.Text);
                aux.Condicion = ddlcondicion.SelectedValue;
                aux.Observaciones = observaciones.Text;

                //INSERTAR COMPRA Y DETALLE_COMPRA}
                negocio.agregar(aux);


                lista_agregados = (List<Agregados>)Session["agregados"];
                foreach (Agregados agregado in lista_agregados)
                {
                    negocio.agregarDetalle(aux, agregado);
                    negocio.aumentarStock(agregado);
                    negocio.setearPrecio(agregado);
                    negocio.setearPrecioVenta(agregado);
                }
                //negocio.agregarDetalle(aux,agregado);

                //actualizar el total de compras para mostrarlo en el grafico
                Session.Add("compras", negocio.total());

                //limpiar lista agregados
                lista_agregados = new List<Agregados>();
                Session.Add("agregados", lista_agregados);

                Response.Redirect("ListadoCompras.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}