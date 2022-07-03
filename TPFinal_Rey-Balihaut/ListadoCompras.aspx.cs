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
    public partial class ListadoCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CompraNegocio compra_negocio = new CompraNegocio();
            gvCompras.DataSource = compra_negocio.listar();
            gvCompras.DataBind();
        }

        protected void gvCompras_SelectedIndexChanged(object sender, EventArgs e)
        {
            var codigoSelected = gvCompras.SelectedDataKey.Value.ToString();
            Response.Redirect("Compras.aspx?id=" + codigoSelected);
        }
    }
}