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
        public List<ProductCart> lista_agregados { get; set; }
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

                    SupplierController proveedores_negocio = new SupplierController();
                    ddlproveedor.DataSource = proveedores_negocio.GetAll();
                    ddlproveedor.DataValueField = "cuit";
                    ddlproveedor.DataTextField = "name";
                    ddlproveedor.DataBind();

                    ProductController producto_negocio = new ProductController();
                    ddlproductos.DataSource = producto_negocio.GetAll();
                    ddlproductos.DataValueField = "code";
                    ddlproductos.DataTextField = "name";
                    ddlproductos.DataBind();

                    ddlcondicion.Items.Add("EFECTIVO");
                    ddlcondicion.Items.Add("15 DIAS");
                    ddlcondicion.Items.Add("30 DIAS");
                    ddlcondicion.Items.Add("60 DIAS");
                }

                if (Session["agregados"] == null)
                {
                    lista_agregados = new List<ProductCart>();
                    Session.Add("agregados", lista_agregados);
                }

                gvAgregados.DataSource = Session["agregados"];
                gvAgregados.DataBind();

                txtfecha.Text = DateTime.Now.ToShortDateString();

                //TOTAL SUMA
                lista_agregados = (List<ProductCart>)Session["agregados"];
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
                    ProductCart aux = new ProductCart();
                    aux.code = ddlproductos.SelectedItem.Value;
                    aux.name = ddlproductos.SelectedItem.Text;
                    aux.quantity = int.Parse(cantidades.Text);
                    aux.price = decimal.Parse(precio.Text);

                    lista_agregados = (List<ProductCart>)Session["agregados"];

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

                }

                cantidades.Text = "";
                precio.Text = "";

                valueproveedor = ddlproveedor.SelectedValue;
                string cond = ddlcondicion.SelectedValue;
                string obs = observaciones.Text;
                Response.Redirect("Compras.aspx?value=" + valueproveedor + "&condicion=" + cond + "&observacion=" + obs,false);
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

                lista_agregados = (List<ProductCart>)Session["agregados"];
                ProductCart aux = lista_agregados.Find(x => x.code == codigoSelected);
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
                PurchaseController negocio = new PurchaseController();
                Purchase aux = new Purchase();
                aux.supplier = new Supplier();
                aux.date = DateTime.Now;
                aux.supplier.cuit = ddlproveedor.SelectedValue;
                aux.total = decimal.Parse(txtsuma.Text);
                aux.paymentCondition = ddlcondicion.SelectedValue;
                aux.observations = observaciones.Text;

                //INSERTAR COMPRA Y DETALLE_COMPRA}
                negocio.Add(aux);


                lista_agregados = (List<ProductCart>)Session["agregados"];
                foreach (ProductCart agregado in lista_agregados)
                {
                    negocio.AddDetail(aux, agregado);
                    negocio.AddStock(agregado);
                    negocio.SetPrice(agregado);
                    negocio.SetSalesPrice(agregado);
                }
                //negocio.agregarDetalle(aux,agregado);

                //actualizar el total de compras para mostrarlo en el grafico
                Session.Add("compras", negocio.GetTotalSumPurchases());

                //limpiar lista agregados
                lista_agregados = new List<ProductCart>();
                Session.Add("agregados", lista_agregados);

                Response.Redirect("ListadoCompras.aspx",false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}