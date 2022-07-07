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
    public partial class ListadoVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }

            if(!IsPostBack)
            {
                VentaNegocio negocio_venta = new VentaNegocio();
                gvVentas.DataSource = negocio_venta.listar();
                gvVentas.DataBind();

                ClienteNegocio negocio_cliente = new ClienteNegocio();
                ddlclientes.DataSource = negocio_cliente.listar();
                ddlclientes.DataTextField = "Apellido";
                ddlclientes.DataValueField = "DNI";
                ddlclientes.DataBind();

                total.Text = "$" + String.Format("{0:0.00}", negocio_venta.total());

                promedio.Text = "$" + String.Format("{0:0.00}", negocio_venta.promedio());

                CompraNegocio negocio_compra = new CompraNegocio();
                ganancia.Text = "$" + String.Format("{0:0.00}", negocio_venta.total() - negocio_compra.total());
            }
            
        }

        protected void gvVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var numSelected = gvVentas.SelectedDataKey.Value.ToString();
            Response.Redirect("RegistroVenta.aspx?num=" + numSelected);
        }

        protected void gvVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVentas.PageIndex = e.NewPageIndex;
            gvVentas.DataBind();
        }

        protected void ddlclientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            VentaNegocio negocio_venta = new VentaNegocio();
            gvVentas.DataSource = negocio_venta.listarxcliente(ddlclientes.SelectedValue);
            gvVentas.DataBind();
        }
    }
}



