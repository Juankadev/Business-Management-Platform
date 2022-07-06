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
    public partial class Listado_Marca_Categoria : System.Web.UI.Page
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

            MarcaNegocio marca_negocio = new MarcaNegocio();
            gvMarcas.DataSource = marca_negocio.listar();
            gvMarcas.DataBind();
        }

        protected void gvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var codigoSelected = gvMarcas.SelectedDataKey.Value.ToString();
            Response.Redirect("Marcas.aspx?id=" + codigoSelected);
        }
    }
}