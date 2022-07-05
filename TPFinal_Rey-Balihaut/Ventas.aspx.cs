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
        public string valuecliente { get; set; }
        public List<Agregados> lista_agregados { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //cantidad = 0;

                ClienteNegocio cliente_negocio = new ClienteNegocio();
                ddlclientes.DataSource = cliente_negocio.listar();
                ddlclientes.DataValueField = "DNI";
                ddlclientes.DataTextField = "Nombre";
                ddlclientes.DataBind();

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


            if (Session["agregadosVenta"] == null)
            {
                lista_agregados = new List<Agregados>();
                Session.Add("agregadosVenta", lista_agregados);
            }

            gvAgregados.DataSource = Session["agregadosVenta"];
            gvAgregados.DataBind();
            txtfecha.Text = DateTime.Now.ToShortDateString();

            //TOTAL SUMA
            lista_agregados = (List<Agregados>)Session["agregadosVenta"];
            if (lista_agregados.Count > 0)
            {
                decimal suma = 0;
                foreach (Dominio.Agregados aux in lista_agregados)
                {
                    suma += aux.Precio * aux.Cantidad;
                }
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

            if (Request.QueryString["condicion"] != null)
            {
                ddlcondicion.SelectedValue = Request.QueryString["condicion"].ToString();
            }

            if (Request.QueryString["observacion"] != null)
            {
                observaciones.Text = Request.QueryString["observacion"].ToString();
            }
        }

        protected void btn_nuevo_producto_Click(object sender, EventArgs e)
        {
            if (cantidades.Text != "" && precio.Text != "")
            {
                Agregados aux = new Agregados();
                aux.Codigo = ddlproductos.SelectedItem.Value;
                aux.Nombre = ddlproductos.SelectedItem.Text;
                aux.Cantidad = int.Parse(cantidades.Text);
                aux.Precio = decimal.Parse(precio.Text);

                lista_agregados = (List<Agregados>)Session["agregadosVenta"];
                lista_agregados.Add(aux);
            }

            cantidades.Text = "";
            precio.Text = "";

            valuecliente = ddlclientes.SelectedValue;
            string cond = ddlcondicion.SelectedValue;
            string obs = observaciones.Text;
            Response.Redirect("Ventas.aspx?value=" + valuecliente + "&condicion=" + cond + "&observacion=" + obs);
        }

        protected void gvAgregados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codigoSelected = gvAgregados.SelectedDataKey.Value.ToString();

            lista_agregados = (List<Agregados>)Session["agregadosVenta"];
            Agregados aux = lista_agregados.Find(x => x.Codigo == codigoSelected);
            lista_agregados.Remove(aux);


            cantidades.Text = "";
            precio.Text = "";

            valuecliente = ddlclientes.SelectedValue;
            string cond = ddlcondicion.SelectedValue;
            string obs = observaciones.Text;
            Response.Redirect("Ventas.aspx?value=" + valuecliente + "&condicion=" + cond + "&observacion=" + obs);
        }

        protected void altaVenta_Click(object sender, EventArgs e)
        {
            ////INSERTAR COMPRA
            _Venta aux = new _Venta();
            aux.Cliente = new _Cliente();
            aux.Cliente.DNI = ddlclientes.SelectedValue;
            aux.Fecha = DateTime.Now;
            aux.Total = decimal.Parse(txtsuma.Text);
            aux.Condicion = ddlcondicion.SelectedValue;
            aux.Observaciones = observaciones.Text;

            ////INSERTAR VENTA Y DETALLE_VENTA
            VentaNegocio negocio = new VentaNegocio();
            //negocio.agregar(aux);


            //lista_agregados = (List<Agregados>)Session["agregados"];
            //foreach (Agregados agregado in lista_agregados)
            //{
            //    negocio.agregarDetalle(aux, agregado);
            //    negocio.aumentarStock(agregado);
            //    negocio.setearPrecio(agregado);
            //    negocio.setearPrecioVenta(agregado);
            //}
            ////negocio.agregarDetalle(aux,agregado);

            ////limpiar lista agregados
            //lista_agregados = new List<Agregados>();
            //Session.Add("agregados", lista_agregados);

            //Response.Redirect("ListadoCompras.aspx");
        }
    }
}