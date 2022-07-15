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
            try
            {
                resetuser.Visible = false;
                resetbtn.Visible = false;
                myLabel.Visible = false;

                if (Request.QueryString["reset"] != null)
                {
                    resetuser.Visible = true;
                    resetbtn.Visible = true;
                }
                if (Request.QueryString["mail"] != null)
                {
                    myLabel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void resetbtn_Click(object sender, EventArgs e)
        {
            //emailservice.armarCorreoSimple(resetuser.Text);
            try
            {
                EmailService emailservice = new EmailService();
                //emailservice.enviarEmail();
                Response.Redirect("Login.aspx?mail=1");
            }
            catch(Exception ex)
            {
                //Session.Add("error", ex);
                throw ex;
            }
        }

        protected void login_Click(object sender, EventArgs e)
        {
            try
            {
                _Usuario usuario;
                UsuarioNegocio negocio = new UsuarioNegocio();
                usuario = new _Usuario(email.Text,pass.Text,false);
                if(negocio.loguear(usuario))
                {
                    Session.Add("usuario",usuario);
                    Session.Add("tipo",usuario.TipoUsuario.ToString());

                    CompraNegocio compra_negocio = new CompraNegocio();
                    Session.Add("compras", compra_negocio.total());
                    VentaNegocio venta_negocio = new VentaNegocio();
                    Session.Add("ventas", venta_negocio.total());
                    //decimal total = decimal.Parse(Session["compras"].ToString());

                    Response.Redirect("Default.aspx",false);
                }
                else
                {
                    Session.Add("error", "'Usuario' o 'contraseña' incorrectos");
                    Response.Redirect("Error.aspx",false);
                }
            }
            catch(Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}