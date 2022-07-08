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
    public partial class ListadoCategorias : System.Web.UI.Page
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


            if(!IsPostBack)
            {
                CategoriaNegocio categoria_negocio = new CategoriaNegocio();
                gvCategorias.DataSource = categoria_negocio.listar();
                gvCategorias.DataBind();
            }
        }

        protected void gvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            var codigoSelected = gvCategorias.SelectedDataKey.Value.ToString();
            Response.Redirect("Categorias.aspx?id=" + codigoSelected);
        }


        protected void buscador_TextChanged(object sender, EventArgs e)
        {
            CategoriaNegocio categoria_negocio = new CategoriaNegocio();
            if (buscador.Text != "")
            {
                gvCategorias.DataSource = categoria_negocio.listarxtexto(buscador.Text);
            }
            else
            {
                gvCategorias.DataSource = categoria_negocio.listar();
            }
            gvCategorias.DataBind();
        }
    }
}