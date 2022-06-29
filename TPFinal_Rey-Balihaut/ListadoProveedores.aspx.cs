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
            ProveedorNegocio proveedor_negocio = new ProveedorNegocio();
            gvProveedores.DataSource = proveedor_negocio.listar();
            gvProveedores.DataBind();
        }
    }
}