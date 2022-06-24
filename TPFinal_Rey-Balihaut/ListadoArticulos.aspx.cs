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
    public partial class ListadoArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio producto_negocio = new ProductoNegocio();
            gvArticulos.DataSource = producto_negocio.listar();
            gvArticulos.DataBind();
        }

        protected void gvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var codigoSelected = gvArticulos.SelectedDataKey.Value.ToString();
            //Session.Add("codigoSelected", codigoSelected);
            Response.Redirect("Articulos.aspx?id="+codigoSelected);
        }

        protected void gvArticulos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //var codigoSelected = gvArticulos.SelectedDataKey.Value.ToString();
            //string cod = Session["codigoSelected"].ToString();

            //gvArticulos.SelectedDataKey.Value.ToString();

            if (e.CommandName == "Eliminar")
            {          
                //Response.Redirect("ListadoArticulos.aspx"+cod);
            }
            if (e.CommandName == "Modificar")
            {
                //Response.Redirect("Articulos.aspx"+cod);
            }
        }
    }
}