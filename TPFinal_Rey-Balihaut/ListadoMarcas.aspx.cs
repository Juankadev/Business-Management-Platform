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
            MarcaNegocio marca_negocio = new MarcaNegocio();
            gvmarcas.DataSource = marca_negocio.listar();
            gvmarcas.DataBind();
        }
    }
}