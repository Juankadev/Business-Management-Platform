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
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }
            else if (Session["tipo"].ToString() != "ADMIN")
            {
                Response.Redirect("Default.aspx", false);
            }

            CompraNegocio compra_negocio = new CompraNegocio();
            gvCompras.DataSource = compra_negocio.listar();
            gvCompras.DataBind();

            total.Text = "$" + String.Format("{0:0.00}", compra_negocio.total());

        }

        protected void gvCompras_SelectedIndexChanged(object sender, EventArgs e)
        {
            var numSelected = gvCompras.SelectedDataKey.Value.ToString();
            Response.Redirect("RegistroCompra.aspx?num=" + numSelected);
        }

        protected void gvCompras_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCompras.PageIndex = e.NewPageIndex;
            gvCompras.DataBind();
        }
    }
}