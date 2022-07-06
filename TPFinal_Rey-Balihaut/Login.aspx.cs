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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            resetuser.Visible = false;
            resetbtn.Visible = false;
            myLabel.Visible = false;

            if (Request.QueryString["reset"]!=null)
            {
                resetuser.Visible = true;
                resetbtn.Visible = true;
            }
            if (Request.QueryString["mail"] != null)
            {
                myLabel.Visible = true;
            }

        }

        protected void resetbtn_Click(object sender, EventArgs e)
        {
            EmailService emailservice = new EmailService();
            //emailservice.armarCorreoSimple(resetuser.Text);
            try
            {
                //emailservice.enviarEmail();
                Response.Redirect("Login.aspx?mail=1");
            }
            catch(Exception ex)
            {
                //Session.Add("error", ex);
                throw ex;
            }
        }
    }
}