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

        }

        protected void altaProveedor_Click(object sender, EventArgs e)
        {
            ProveedorNegocio proveedor_negocio = new ProveedorNegocio();
            _Proveedor2 aux = new _Proveedor2();

            aux.CUIT = cuit.Text;
            aux.Nombre = nombre.Text;
            aux.Telefono = telefono.Text;
            aux.Mail = mail.Text;
            aux.Direccion = direccion.Text;

            proveedor_negocio.agregar(aux);
            cuit.Text = "";
            nombre.Text = "";
            telefono.Text = ""; ;
            mail.Text = ""; ;
            direccion.Text = "";
        }
    }
}