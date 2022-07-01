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
    public partial class AltaProveedor : System.Web.UI.Page
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

                    ProveedorNegocio negocio = new ProveedorNegocio();
                    List<_Proveedor2> lista = negocio.listar();
                    _Proveedor2 aux = lista.Find(x => x.CUIT == codigoURL);

                    cuit.Text = aux.CUIT;
                    nombre.Text = aux.Nombre;
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
                ProveedorNegocio proveedor_negocio = new ProveedorNegocio();
                _Proveedor2 aux = new _Proveedor2();
                aux.CUIT = cuit.Text;
                aux.Nombre = nombre.Text;
                aux.Telefono = telefono.Text;
                aux.Mail = mail.Text;
                aux.Direccion = direccion.Text;

                if (Request.QueryString["id"] != null) //se esta editando un proveedor.
                {
                    proveedor_negocio.modificar(aux);
                }

                else
                {
                    proveedor_negocio.agregar(aux);
                    cuit.Text = "";
                    nombre.Text = "";
                    telefono.Text = ""; ;
                    mail.Text = ""; ;
                    direccion.Text = "";
                }

                Response.Redirect("ListadoProveedores.aspx");
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            ProveedorNegocio proveedor_negocio = new ProveedorNegocio();
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    string codigoURL = Request.QueryString["id"].ToString();
                    proveedor_negocio.eliminar(codigoURL);
                    Response.Redirect("ListadoProveedores.aspx");
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}