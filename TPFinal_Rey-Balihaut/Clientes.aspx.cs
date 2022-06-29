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
            }
        }


        protected void btn_alta_Click(object sender, EventArgs e)
        {
            try
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
                {
                    cliente_negocio.modificar(aux);
                }

                else
                {
                    cliente_negocio.agregar(aux);

                    dni.Text = "";
                    nombre.Text = "";
                    apellido.Text = "";
                    telefono.Text = "";
                    mail.Text = "";
                    direccion.Text = "";
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