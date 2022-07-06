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
    public partial class ListadoProveedores : System.Web.UI.Page
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

            ProveedorNegocio proveedor_negocio = new ProveedorNegocio();
            gvProveedores.DataSource = proveedor_negocio.listar();
            gvProveedores.DataBind();
        }

        protected void gvProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            var codigoSelected = gvProveedores.SelectedDataKey.Value.ToString();
            Response.Redirect("Proveedores.aspx?id=" + codigoSelected);
        }
    }
}