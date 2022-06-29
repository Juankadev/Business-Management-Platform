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

        }

        protected void altaCliente_Click(object sender, EventArgs e)
        {
            ClienteNegocio cliente_negocio = new ClienteNegocio();
            _Cliente aux = new _Cliente();
            aux.DNI = dni.Text;
            aux.Nombre = nombre.Text;
            aux.Apellido = apellido.Text;
            aux.Telefono = telefono.Text;
            aux.Mail = mail.Text;
            aux.Direccion = direccion.Text;

            cliente_negocio.agregar(aux);

            dni.Text = "";
            nombre.Text = "";
            apellido.Text = "";
            telefono.Text = "";
            mail.Text = "";
            direccion.Text = "";
        }
    }
}