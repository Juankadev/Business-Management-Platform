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
    public partial class Ventas2 : System.Web.UI.Page
    {
        public List<Agregados> lista_agregados { get; set; }
        public string condicion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                verstock.Visible = false;

                if (Session["usuario"] == null)
                {
                    Response.Redirect("Login.aspx", false);
                }


                lblstock.Visible = false;


                //List<_Producto> lista = producto_negocio.listar();
                if (!IsPostBack)
                {
                    //cantidad = 0;

                    ClienteNegocio cliente_negocio = new ClienteNegocio();
                    ddlclientes.DataSource = cliente_negocio.listar();
                    ddlclientes.DataValueField = "DNI";
                    ddlclientes.DataTextField = "Nombre";
                    ddlclientes.DataBind();

                    ProductoNegocio producto_negocio = new ProductoNegocio();
                    List<_Producto> lista = producto_negocio.listar();
                    _Producto pvacio = new _Producto();
                    pvacio.Codigo = "";
                    pvacio.Nombre = "";
                    lista.Add(pvacio);
                    int index = lista.Count() - 1;
                    ddlproductos.DataSource = lista;
                    ddlproductos.DataValueField = "CODIGO";
                    ddlproductos.DataTextField = "NOMBRE";
                    ddlproductos.DataBind();
                    ddlproductos.SelectedIndex = index;

                    ddlcondicion.Items.Add("EFECTIVO");
                    ddlcondicion.Items.Add("15 DIAS");
                    ddlcondicion.Items.Add("30 DIAS");
                    ddlcondicion.Items.Add("60 DIAS");


                    if (Session["condicion"] == null)
                    {
                        Session.Add("condicion", ddlcondicion.SelectedValue);
                        condicion = Session["condicion"].ToString();
                    }
                    txtfecha.Text = DateTime.Now.ToShortDateString();
                    //ProductoNegocio negocio = new ProductoNegocio();
                    //myLabel.Text = (negocio.stockxproducto(ddlproductos.SelectedValue)).ToString();
                }

                //else //si no es postback
                //{ 
                //    _Producto aux = lista.Find(x => x.Nombre == "");
                //    lista.Remove(aux);
                //}


                if (Session["agregadosVenta"] == null)
                {
                    lista_agregados = new List<Agregados>();
                    Session.Add("agregadosVenta", lista_agregados);
                }

                ddlcondicion.SelectedValue = Session["condicion"].ToString();

                gvAgregados.DataSource = Session["agregadosVenta"];
                gvAgregados.DataBind();


                //TOTAL SUMA
                lista_agregados = (List<Agregados>)Session["agregadosVenta"];
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

                //para que empiece con este CLIENTE al recargar
                if (Request.QueryString["value"] != null)
                {
                    ddlclientes.Enabled = false;
                    ddlclientes.SelectedValue = Request.QueryString["value"].ToString();
                }

                if (Request.QueryString["pr"] != null)
                {
                    ddlproductos.SelectedValue = Request.QueryString["pr"].ToString();
                }

                if (Request.QueryString["observacion"] != null)
                {
                    observaciones.Text = Request.QueryString["observacion"].ToString();
                }

                if (Request.QueryString["stock"] != null)
                {
                    myLabel.Text = Request.QueryString["stock"].ToString();
                }
                else
                {
                    myLabel.Text = "0";
                }


                //ddlcondicion.SelectedValue = condicion;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btn_nuevo_producto_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                if (cantidades.Text != "")
                {
                    Agregados aux = new Agregados();
                    aux.Codigo = ddlproductos.SelectedItem.Value;
                    aux.Nombre = ddlproductos.SelectedItem.Text;

                    if (negocio.hayStock(decimal.Parse(cantidades.Text), aux.Codigo))
                    {
                        aux.Cantidad = decimal.Parse(cantidades.Text);
                    }
                    else
                    {
                        lblstock.Visible = true;
                        return;
                    }

                    aux.Precio = negocio.buscarPrecioVenta(aux.Codigo);

                    lista_agregados = (List<Agregados>)Session["agregadosVenta"];

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


                    //int index = lista_agregados.IndexOf(aux);
                    //if(index != -1)
                    //{
                    //}



                }

                cantidades.Text = "";


                condicion = ddlcondicion.SelectedValue;
                Session.Add("condicion", condicion);
                string condicion2 = Session["condicion"].ToString();

                string valuecliente = ddlclientes.SelectedValue;
                string cond = ddlcondicion.SelectedValue;
                //string pr = ddlproductos.SelectedValue;
                string obs = observaciones.Text;
                Response.Redirect("Ventas.aspx?value=" + valuecliente + "&condicion=" + cond + "&observacion=" + obs,false);
                //Response.Redirect("Ventas.aspx");

            }
            catch(Exception ex)
            {
                //throw ex;
                Session.Add("error", ex);
                Response.Redirect("Error.aspx",false);
            }
        }

        protected void gvAgregados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string codigoSelected = gvAgregados.SelectedDataKey.Value.ToString();

                lista_agregados = (List<Agregados>)Session["agregadosVenta"];
                Agregados aux = lista_agregados.Find(x => x.Codigo == codigoSelected);
                lista_agregados.Remove(aux);

                cantidades.Text = "";

                string valuecliente = ddlclientes.SelectedValue;
                string cond = ddlcondicion.SelectedValue;
                string obs = observaciones.Text;
                Response.Redirect("Ventas.aspx?value=" + valuecliente + "&condicion=" + cond + "&observacion=" + obs);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void altaVenta_Click(object sender, EventArgs e)
        {
            try
            {
                ////INSERTAR VENTA
                _Venta aux = new _Venta();
                aux.Cliente = new _Cliente();
                aux.Cliente.DNI = ddlclientes.SelectedValue;
                aux.Fecha = DateTime.Now;
                aux.Total = decimal.Parse(txtsuma.Text);
                aux.Condicion = ddlcondicion.SelectedValue;
                aux.Observaciones = observaciones.Text;

                ////INSERTAR VENTA Y DETALLE_VENTA
                VentaNegocio negocio = new VentaNegocio();
                /*int r =*/
                negocio.agregar(aux);
                //if (r == 1)
                //    Response.Redirect("Error.aspx");


                lista_agregados = (List<Agregados>)Session["agregadosVenta"];
                foreach (Agregados agregado in lista_agregados)
                {
                    negocio.agregarDetalle(aux, agregado);
                    negocio.descontarStock(agregado);
                }
                ////negocio.agregarDetalle(aux,agregado);

                //agregar el nuevo total de ventas
                Session.Add("ventas", negocio.total());

                ////limpiar lista agregados
                lista_agregados = new List<Agregados>();
                Session.Add("agregadosVenta", lista_agregados);

                Response.Redirect("ListadoVentas.aspx",false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void verstock_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            //myLabel.Text = (negocio.stockxproducto(ddlproductos.SelectedValue)).ToString();
            //Response.Redirect("Ventas.aspx?stock="+myLabel.Text);
        }

        protected void ddlproductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                myLabel.Text = (negocio.stockxproducto(ddlproductos.SelectedValue)).ToString();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            } 
        }
    }
}