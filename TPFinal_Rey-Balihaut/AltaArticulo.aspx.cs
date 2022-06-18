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
    public partial class AltaArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                MarcaNegocio marca_negocio = new MarcaNegocio();
                ddlmarca.DataSource = marca_negocio.listar();
                ddlmarca.DataValueField = "IDMarca";
                ddlmarca.DataTextField = "DescripcionMarca";
                ddlmarca.DataBind();

                CategoriaNegocio categoria_negocio = new CategoriaNegocio();
                ddlcategoria.DataSource = categoria_negocio.listar();
                ddlcategoria.DataValueField = "IDCategoria";
                ddlcategoria.DataTextField = "DescripcionCategoria";
                ddlcategoria.DataBind();
            }
        }
    }
}