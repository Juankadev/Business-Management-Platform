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
    public partial class ListadoArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio producto_negocio = new ProductoNegocio();
            gvArticulos.DataSource = producto_negocio.listar();
            gvArticulos.DataBind();
        }

        protected void gvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var codigoSelected = gvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("Articulos.aspx?id="+codigoSelected);
        }
    }
}