using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPFinal_Rey_Balihaut
{
    public partial class AltaCliente : System.Web.UI.Page
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

            dni.MaxLength = 10; //contar cantidad de caracteres de la caja de texto con length

            if (!IsPostBack)
            {
                btn_alta.Text = "Agregar";

                if (Request.QueryString["id"] != null)
                {
                    string codigoURL = Request.QueryString["id"].ToString();
                    btn_alta.Text = "Modificar";

                    ClienteNegocio negocio = new ClienteNegocio();
                    List<_Cliente> lista = negocio.listar();
                    _Cliente aux = lista.Find(x => x.DNI == codigoURL);

                    dni.Text = aux.DNI;
                    nombre.Text = aux.Nombre;
                    apellido.Text = aux.Apellido;
                    telefono.Text = aux.Telefono;
                    mail.Text = aux.Mail;
                    direccion.Text = aux.Direccion;
                }
                else
                {
                    btn_eliminar.Enabled = false;
                    btn_eliminar.CssClass = "btn btn-danger btn-lg btnlogin";
                }
            }
        }


        protected void btn_alta_Click(object sender, EventArgs e)
        {
            try
            {
                if(dni.Text != "" && nombre.Text != "" && dni.Text.Length == 8)
                {
                    ClienteNegocio cliente_negocio = new ClienteNegocio();
                    _Cliente aux = new _Cliente();
                    aux.DNI = dni.Text;
                    aux.Nombre = nombre.Text;
                    aux.Apellido = apellido.Text;
                    aux.Telefono = telefono.Text;
                    aux.Mail = mail.Text;
                    aux.Direccion = direccion.Text;

                    if (Request.QueryString["id"] != null) //se esta editando un cliente.
                        cliente_negocio.modificar(aux);

                    else
                        cliente_negocio.agregar(aux);

                    Response.Redirect("ListadoClientes.aspx");
                }


                if (dni.Text == "" || dni.Text.Length != 8)
                {
                    dni.CssClass = "form-control is-invalid";
                }
                else
                {
                    dni.CssClass = "form-control is-valid";
                }

                if (nombre.Text == "")
                {
                    nombre.CssClass = "form-control is-invalid";
                }
                else
                {
                    nombre.CssClass = "form-control is-valid";
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            ClienteNegocio cliente_negocio = new ClienteNegocio();
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    string codigoURL = Request.QueryString["id"].ToString();
                    cliente_negocio.eliminar(codigoURL);
                    Response.Redirect("ListadoClientes.aspx");
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}