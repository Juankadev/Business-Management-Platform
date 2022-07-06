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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnsalir_Click(object sender, EventArgs e)
        {
            if(Session["usuario"]!=null)
            {
                Session.Remove("usuario");
                Session.Remove("tipo");
                Response.Redirect("Login.aspx");
            }
        }
    }
}