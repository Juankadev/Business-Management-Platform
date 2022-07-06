﻿using System;
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

            ClienteNegocio cliente_negocio = new ClienteNegocio();
            gvClientes.DataSource = cliente_negocio.listar();
            gvClientes.DataBind();
        }

        protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var codigoSelected = gvClientes.SelectedDataKey.Value.ToString();
            Response.Redirect("Clientes.aspx?id=" + codigoSelected);
        }
    }
}