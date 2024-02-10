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
        public List<ProductCart> lista_agregados { get; set; }
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

                    CustomerController cliente_negocio = new CustomerController();
                    ddlclientes.DataSource = cliente_negocio.GetAll();
                    ddlclientes.DataValueField = "id";
                    ddlclientes.DataTextField = "name";
                    ddlclientes.DataBind();

                    ProductController producto_negocio = new ProductController();
                    List<Product> lista = producto_negocio.GetAll();
                    Product pvacio = new Product();
                    pvacio.code = "";
                    pvacio.name = "";
                    lista.Add(pvacio);
                    int index = lista.Count() - 1;
                    ddlproductos.DataSource = lista;
                    ddlproductos.DataValueField = "code";
                    ddlproductos.DataTextField = "name";
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
                    lista_agregados = new List<ProductCart>();
                    Session.Add("agregadosVenta", lista_agregados);
                }

                ddlcondicion.SelectedValue = Session["condicion"].ToString();

                gvAgregados.DataSource = Session["agregadosVenta"];
                gvAgregados.DataBind();


                //TOTAL SUMA
                lista_agregados = (List<ProductCart>)Session["agregadosVenta"];
                if (lista_agregados.Count > 0)
                {
                    decimal suma = 0;
                    foreach (Dominio.ProductCart aux in lista_agregados)
                    {
                        suma += aux.price * aux.quantity;
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
                ProductController negocio = new ProductController();
                if (cantidades.Text != "")
                {
                    ProductCart aux = new ProductCart();
                    aux.code = ddlproductos.SelectedItem.Value;
                    aux.name = ddlproductos.SelectedItem.Text;

                    if (negocio.ExistStock(decimal.Parse(cantidades.Text), aux.code))
                    {
                        aux.quantity = decimal.Parse(cantidades.Text);
                    }
                    else
                    {
                        lblstock.Visible = true;
                        return;
                    }

                    aux.price = negocio.GetSalePrice(aux.code);

                    lista_agregados = (List<ProductCart>)Session["agregadosVenta"];

                    //si el producto ya existe en la lista:
                    ProductCart reemplazo = lista_agregados.Find(x => x.code == aux.code);

                    //lo modifica
                    if (reemplazo != null)
                    {
                        int index = lista_agregados.IndexOf(reemplazo);

                        lista_agregados[index].quantity += aux.quantity;
                        lista_agregados[index].price = aux.price;
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

                lista_agregados = (List<ProductCart>)Session["agregadosVenta"];
                ProductCart aux = lista_agregados.Find(x => x.code == codigoSelected);
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
                Sale aux = new Sale();
                aux.customer = new Customer();
                aux.customer.id = ddlclientes.SelectedValue;
                aux.date = DateTime.Now;
                aux.total = decimal.Parse(txtsuma.Text);
                aux.paymentCondition = ddlcondicion.SelectedValue;
                aux.observations = observaciones.Text;

                ////INSERTAR VENTA Y DETALLE_VENTA
                SaleController negocio = new SaleController();
                /*int r =*/
                negocio.Add(aux);
                //if (r == 1)
                //    Response.Redirect("Error.aspx");


                lista_agregados = (List<ProductCart>)Session["agregadosVenta"];
                foreach (ProductCart agregado in lista_agregados)
                {
                    negocio.AddDetail(aux, agregado);
                    negocio.discountStock(agregado);
                }
                ////negocio.agregarDetalle(aux,agregado);

                //agregar el nuevo total de ventas
                Session.Add("ventas", negocio.GetTotalSumSales());

                ////limpiar lista agregados
                lista_agregados = new List<ProductCart>();
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
            ProductController negocio = new ProductController();
            //myLabel.Text = (negocio.stockxproducto(ddlproductos.SelectedValue)).ToString();
            //Response.Redirect("Ventas.aspx?stock="+myLabel.Text);
        }

        protected void ddlproductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ProductController negocio = new ProductController();
                myLabel.Text = (negocio.GetCurrentStock(ddlproductos.SelectedValue)).ToString();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            } 
        }
    }
}