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
    public partial class RegistroVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }

            if (Request.QueryString["num"] != null)
            {
                int buscado = int.Parse(Request.QueryString["num"]);
                VentaNegocio negocio = new VentaNegocio();
                _Venta aux = negocio.listarxnum(buscado);

                txtnum.Text = aux.numventa.ToString();
                txtfecha.Text = aux.Fecha.ToString();
                txtobservaciones.Text = aux.Observaciones;
                txtcliente.Text = aux.Cliente.Nombre;
                txttotal.Text = String.Format("{0:0.00}", aux.Total);
                txtcondicion.Text = aux.Condicion;
            }

            VentaNegocio venta_negocio = new VentaNegocio();
            gvArticulos.DataSource = venta_negocio.listarDetalleProducto(int.Parse(txtnum.Text));
            gvArticulos.DataBind();
        }
    }
}