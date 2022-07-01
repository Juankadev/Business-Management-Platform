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
    public partial class Ventas2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteNegocio cliente_negocio = new ClienteNegocio();
            ddlclientes.DataSource = cliente_negocio.listar();
            ddlclientes.DataValueField = "DNI";
            ddlclientes.DataTextField = "Nombre";
            ddlclientes.DataBind();
        }
    }
}