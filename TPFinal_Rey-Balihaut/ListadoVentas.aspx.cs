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
            VentaNegocio negocio = new VentaNegocio();
            gvVentas.DataSource = negocio.listar();
            gvVentas.DataBind();
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



