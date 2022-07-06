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
            VentaNegocio negocio_venta = new VentaNegocio();
            gvVentas.DataSource = negocio_venta.listar();
            gvVentas.DataBind();

            total.Text = "$" + String.Format("{0:0.00}", negocio_venta.total());

            CompraNegocio negocio_compra = new CompraNegocio();
            ganancia.Text = "$" + String.Format("{0:0.00}", negocio_venta.total() - negocio_compra.total());
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
    }
}



