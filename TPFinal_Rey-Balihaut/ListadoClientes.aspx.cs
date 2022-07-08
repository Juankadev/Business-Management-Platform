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
    public partial class ListadoClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }

            if(!IsPostBack)
            {
                ClienteNegocio cliente_negocio = new ClienteNegocio();
                gvClientes.DataSource = cliente_negocio.listar();
                gvClientes.DataBind();
            }
        }

        protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var codigoSelected = gvClientes.SelectedDataKey.Value.ToString();
            Response.Redirect("Clientes.aspx?id=" + codigoSelected);
        }


        protected void buscador_TextChanged(object sender, EventArgs e)
        {
            ClienteNegocio cliente_negocio = new ClienteNegocio();
            if (buscador.Text != "")
            {
                gvClientes.DataSource = cliente_negocio.listarxtexto(buscador.Text);
            }
            else
            {
                gvClientes.DataSource = cliente_negocio.listar();
            }
            gvClientes.DataBind();
        }
    }
}