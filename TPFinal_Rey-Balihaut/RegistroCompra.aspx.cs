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
    public partial class FacturaCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["num"]!=null)
            {
                int buscado = int.Parse(Request.QueryString["num"]);
                CompraNegocio negocio = new CompraNegocio();
                _Compra aux = negocio.listarxnum(buscado);

                txtnum.Text = aux.numcompra.ToString();
                txtfecha.Text = aux.Fecha.ToString();
                txtobservaciones.Text = aux.Observaciones;
                txtproveedor.Text = aux.Proveedor.Nombre;
                txttotal.Text = String.Format("{0:0.00}", aux.Total);
                txtcondicion.Text = aux.Condicion;
            }

            CompraNegocio compra_negocio = new CompraNegocio();
            gvArticulos.DataSource = compra_negocio.listarDetalleProducto(int.Parse(txtnum.Text));
            gvArticulos.DataBind();

        }
    }
}